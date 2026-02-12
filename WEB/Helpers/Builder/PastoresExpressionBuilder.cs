using System.Linq.Expressions;
using System.Reflection;
using WEB.Models.ViewModels;

namespace WEB.Helpers.Builder
{
    public class PastoresExpressionBuilder<T> where T : class
    {
        public ParameterExpression View { get; set; }
        public Expression Body { get; set; }
        public MethodInfo? MethodInfoContains { get; set; }

        private MethodInfo _toLowerMethod;

        public PastoresExpressionBuilder(string obj)
        {
            View = Expression.Parameter(typeof(T), obj);
            Body = Expression.Equal(Expression.Constant(true), Expression.Constant(true)).Reduce();

            MethodInfoContains = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            _toLowerMethod = typeof(string).GetMethod("ToLower", Type.EmptyTypes)!;
        }

        public PastoresExpressionBuilder<T> BuscarEmTudo(string? search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return this;

            search = search.ToLower();
            var searchConst = Expression.Constant(search);

            Expression? expressaoOr = null;

            var campos = new List<Expression>
            {
                Expression.Property(View, nameof(DiaconatoVm.NomeCompleto)),
                Expression.Property(View, nameof(DiaconatoVm.CargoLocal)),
                Expression.Property(Expression.Property(View, nameof(DiaconatoVm.Igreja)), nameof(IgrejaVm.Nome)),
                Expression.Property(Expression.Property(View, nameof(DiaconatoVm.Regiao)), nameof(RegiaoVm.Nome)              )
            };

            foreach (var campo in campos)
            {
                var notNull = Expression.NotEqual(campo, Expression.Constant(null, typeof(string)));
                var toLower = Expression.Call(campo, _toLowerMethod);
                var contains = Expression.Call(toLower, MethodInfoContains!, searchConst);
                var condicao = Expression.AndAlso(notNull, contains);

                expressaoOr = expressaoOr == null ? condicao : Expression.OrElse(expressaoOr, condicao);
            }

            if (expressaoOr != null) Body = Expression.AndAlso(Body, expressaoOr);

            return this;
        }

        public Expression<Func<T, bool>> Construir()
        {
            return Expression.Lambda<Func<T, bool>>(Body, View);
        }
    }
}
