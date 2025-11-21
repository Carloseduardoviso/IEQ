using System.Linq.Expressions;
using System.Reflection;
using WEB.Models.ViewModels;

namespace WEB.Helpers.Builder
{
    public class DiaconatoExpressionBuilder<T> where T : class
    {
        public ParameterExpression View { get; set; }
        public Expression Body { get; set; }
        public MethodInfo? MethodInfoContains { get; set; }
        public DiaconatoExpressionBuilder(string obj)
        {
            View = Expression.Parameter(typeof(T), obj);
            Body = Expression.Equal(Expression.Constant(true), Expression.Constant(true)).Reduce();
            MethodInfoContains = typeof(string).GetMethod("Contains", new[] { typeof(string) });
        }

        public DiaconatoExpressionBuilder<T> BuscarEmTudo(string? search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return this;

            // Lista das propriedades que queremos buscar
            var props = new[]
            {
                nameof(DiaconatoVm.NomeCompleto),
                nameof(DiaconatoVm.Igreja),
                nameof(DiaconatoVm.Regiao),
                nameof(DiaconatoVm.Cargo)
            };

            Expression? expressaoOr = null;

            foreach (var prop in props)
            {
                var propriedade = Expression.Property(View, prop);
                var notNull = Expression.NotEqual(propriedade, Expression.Constant(null));
                var contains = Expression.Call(propriedade, MethodInfoContains!, Expression.Constant(search));
                var condicao = Expression.AndAlso(notNull, contains);

                expressaoOr = expressaoOr == null
                    ? condicao
                    : Expression.OrElse(expressaoOr, condicao);
            }

            // Adiciona ao Body final via AND
            Body = Expression.AndAlso(Body, expressaoOr);

            return this;
        }


        public Expression<Func<T, bool>> Construir() => Expression.Lambda<Func<T, bool>>(Body, View);
    }
}
