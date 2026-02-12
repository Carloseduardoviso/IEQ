using System.Linq.Expressions;
using WEB.Models.Entities;
using WEB.Models.ViewModels;
using WEB.Models.ViewModels.Filtro;

namespace WEB.Helpers.Builder.Filtro
{
    public class FiltroMulheresBuilder
    {
        public static Expression<Func<MulheresVm, bool>>? Construir(FiltroMulheresVm filtro)
        {
            if (filtro is null)
            {
                return null;
            }

            return ConstruirLambda(filtro);
        }

        public static Expression<Func<MulheresVm, bool>> ConstruirLambda(FiltroMulheresVm filter)
        {
            return new DiaconatoExpressionBuilder<MulheresVm>(nameof(Mulheres))
                .BuscarEmTudo(filter.Search)
                .Construir();
        }

    }
}
