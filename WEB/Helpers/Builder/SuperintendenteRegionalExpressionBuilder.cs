using System.Linq.Expressions;
using System.Reflection;
using WEB.Models.ViewModels;

namespace WEB.Helpers.Builder
{
    public class SuperintendenteRegionalExpressionBuilder<T> where T : class
    {
        public ParameterExpression View { get; set; }
        public Expression Body { get; set; }
        public MethodInfo? MethodInfoContains { get; set; }

        private MethodInfo _toLowerMethod;

        public SuperintendenteRegionalExpressionBuilder(string obj)
        {
            View = Expression.Parameter(typeof(T), obj);
            Body = Expression.Equal(Expression.Constant(true), Expression.Constant(true)).Reduce();

            MethodInfoContains = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            _toLowerMethod = typeof(string).GetMethod("ToLower", Type.EmptyTypes)!;
        }

        public SuperintendenteRegionalExpressionBuilder<T> BuscarEmTudo(string? search)
        {
            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();
                Body = Expression.AndAlso(Body, Expression.Call(Expression.Property(View, nameof(SuperintendenteRegionalVm.Nome)), MethodInfoContains!, Expression.Constant(search)));
            }

            return this;
        }

        public Expression<Func<T, bool>> Construir()
        {
            return Expression.Lambda<Func<T, bool>>(Body, View);
        }
    }
}
