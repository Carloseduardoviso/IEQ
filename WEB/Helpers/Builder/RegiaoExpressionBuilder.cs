using System.Linq.Expressions;
using System.Reflection;
using WEB.Models.Enuns;
using WEB.Models.ViewModels;

namespace WEB.Helpers.Builder
{
    public class RegiaoExpressionBuilder<T> where T : class
    {
        public ParameterExpression View { get; set; }
        public Expression Body { get; set; }
        public MethodInfo? MethodInfoContains { get; set; }

        private MethodInfo _toLowerMethod;

        public RegiaoExpressionBuilder(string obj)
        {
            View = Expression.Parameter(typeof(T), obj);
            Body = Expression.Equal(Expression.Constant(true), Expression.Constant(true)).Reduce();

            MethodInfoContains = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            _toLowerMethod = typeof(string).GetMethod("ToLower", Type.EmptyTypes)!;
        }

        public RegiaoExpressionBuilder<T> BuscarEmTudo(string? search)
        {
            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();

                var nomeProperty = Expression.Property(View, nameof(RegiaoVm.Nome));
                var nome = Expression.Call(nomeProperty, MethodInfoContains!, Expression.Constant(search));           

                var igrejaRegProperty = Expression.Property(View, nameof(RegiaoVm.SuperintendenteRegional));
                var igrejaRegNome = Expression.Property(igrejaRegProperty, nameof(SuperintendenteRegionalVm.Nome));
                var igrejaRegContains = Expression.Call(igrejaRegNome, MethodInfoContains!, Expression.Constant(search));

                var igrejaEstProperty = Expression.Property(View, nameof(RegiaoVm.SuperintendenteEstadual));
                var igrejaEstNome = Expression.Property(igrejaEstProperty, nameof(SuperintendenteEstadualVm.Nome));
                var igrejaEstContains = Expression.Call(igrejaEstNome, MethodInfoContains!, Expression.Constant(search));

                Expression filtroCombinado = Expression.OrElse(nome, igrejaRegContains);
                filtroCombinado = Expression.OrElse(filtroCombinado, igrejaEstContains);
              
                Body = Expression.AndAlso(Body, filtroCombinado);
            }

            return this;
        }

        public Expression<Func<T, bool>> Construir()
        {
            return Expression.Lambda<Func<T, bool>>(Body, View);
        }
    }
}
