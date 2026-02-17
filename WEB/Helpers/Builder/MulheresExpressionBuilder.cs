using System.Linq.Expressions;
using System.Reflection;
using WEB.Models.Enuns;
using WEB.Models.ViewModels;

namespace WEB.Helpers.Builder
{
    public class MulheresExpressionBuilder<T> where T : class
    {
        public ParameterExpression View { get; set; }
        public Expression Body { get; set; }
        public MethodInfo? MethodInfoContains { get; set; }

        private MethodInfo _toLowerMethod;

        public MulheresExpressionBuilder(string obj)
        {
            View = Expression.Parameter(typeof(T), obj);
            Body = Expression.Equal(Expression.Constant(true), Expression.Constant(true)).Reduce();

            MethodInfoContains = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            _toLowerMethod = typeof(string).GetMethod("ToLower", Type.EmptyTypes)!;
        }

        public MulheresExpressionBuilder<T> BuscarEmTudo(string? search)
        {
            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();

                var nomeProperty = Expression.Property(View, nameof(MulheresVm.NomeCompleto));
                var nome = Expression.Call(nomeProperty, MethodInfoContains!, Expression.Constant(search));

                var regiaoProperty = Expression.Property(View, nameof(MulheresVm.Regiao));
                var regiaoNome = Expression.Property(regiaoProperty, nameof(RegiaoVm.Nome));
                var regiaoContains = Expression.Call(regiaoNome, MethodInfoContains!, Expression.Constant(search));

                var igrejaProperty = Expression.Property(View, nameof(MulheresVm.Igreja));
                var igrejaNome = Expression.Property(igrejaProperty, nameof(IgrejaVm.Nome));
                var igrejaContains = Expression.Call(igrejaNome, MethodInfoContains!, Expression.Constant(search));

                Expression filtroCombinado = Expression.OrElse(nome, regiaoContains);
                filtroCombinado = Expression.OrElse(filtroCombinado, igrejaContains);

                if (Enum.TryParse(typeof(CargoLocal), search, true, out var cargoLocalEnum))
                {
                    var cargoLocalProperty = Expression.Property(View, nameof(MulheresVm.CargoLocal));
                    var cargoLocalEquals = Expression.Equal(cargoLocalProperty, Expression.Constant(cargoLocalEnum));
                    filtroCombinado = Expression.OrElse(filtroCombinado, cargoLocalEquals);
                }

                if (Enum.TryParse(typeof(CargoRegional), search, true, out var cargoRegionalEnum))
                {
                    var cargoRegionalProperty = Expression.Property(View, nameof(MulheresVm.CargoRegional));
                    var cargoRegionalEquals = Expression.Equal(cargoRegionalProperty, Expression.Constant(cargoRegionalEnum));
                    filtroCombinado = Expression.OrElse(filtroCombinado, cargoRegionalEquals);
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
