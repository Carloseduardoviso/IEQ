using System.Linq.Expressions;
using System.Reflection;
using WEB.Models.Enuns;
using WEB.Models.ViewModels;

namespace WEB.Helpers.Builder
{
    public class IgrejaExpressionBuilder<T> where T : class
    {
        public ParameterExpression View { get; set; }
        public Expression Body { get; set; }
        public MethodInfo? MethodInfoContains { get; set; }

        private MethodInfo _toLowerMethod;

        public IgrejaExpressionBuilder(string obj)
        {
            View = Expression.Parameter(typeof(T), obj);
            Body = Expression.Equal(Expression.Constant(true), Expression.Constant(true)).Reduce();

            MethodInfoContains = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            _toLowerMethod = typeof(string).GetMethod("ToLower", Type.EmptyTypes)!;
        }

        public IgrejaExpressionBuilder<T> BuscarEmTudo(string? search)
        {
            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();

                var nomeProperty = Expression.Property(View, nameof(IgrejaVm.Nome));
                var nome = Expression.Call(nomeProperty, MethodInfoContains!, Expression.Constant(search));

                var regiaoProperty = Expression.Property(View, nameof(IgrejaVm.Regiao));
                var regiaoNome = Expression.Property(regiaoProperty, nameof(RegiaoVm.Nome));
                var regiaoContains = Expression.Call(regiaoNome, MethodInfoContains!, Expression.Constant(search));               

                Expression filtroCombinado = Expression.OrElse(nome, regiaoContains);               

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
