using System.Linq.Expressions;
using System.Reflection;
using WEB.Models.Enuns;
using WEB.Models.ViewModels;

namespace WEB.Helpers.Builder
{
    public class UsuarioExpressionBuilder<T> where T : class
    {
        public ParameterExpression View { get; set; }
        public Expression Body { get; set; }
        public MethodInfo? MethodInfoContains { get; set; }

        private MethodInfo _toLowerMethod;

        public UsuarioExpressionBuilder(string obj)
        {
            View = Expression.Parameter(typeof(T), obj);
            Body = Expression.Equal(Expression.Constant(true), Expression.Constant(true)).Reduce();

            MethodInfoContains = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            _toLowerMethod = typeof(string).GetMethod("ToLower", Type.EmptyTypes)!;
        }

        public UsuarioExpressionBuilder<T> BuscarEmTudo(string? search)
        {
            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();
                var nomeProperty = Expression.Property(View, nameof(UsuarioVm.Nome));
                var nomeContains = Expression.Call(nomeProperty, MethodInfoContains!, Expression.Constant(search));
                Expression filtroCombinado = nomeContains;

                if (Enum.TryParse(typeof(Role), search, true, out var roleEnum))
                {
                    var roleProperty = Expression.Property(View, nameof(UsuarioVm.Role));
                    var roleEquals = Expression.Equal(roleProperty, Expression.Constant(roleEnum));
                    filtroCombinado = Expression.OrElse(filtroCombinado, roleEquals);
                }

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
