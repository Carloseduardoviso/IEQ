using System.Linq.Expressions;
using WEB.Models.Entities;
using WEB.Models.ViewModels;
using WEB.Models.ViewModels.Filtro;

namespace WEB.Helpers.Builder.Filtro
{
    public class FiltroTeatroBuilder
    {
        public static Expression<Func<TeatroVm, bool>>? Construir(FiltroTeatroVm filtro)
        {
            if (filtro is null)
            {
                return null;
            }

            return ConstruirLambda(filtro);
        }

        public static Expression<Func<TeatroVm, bool>> ConstruirLambda(FiltroTeatroVm filter)
        {
            return new DiaconatoExpressionBuilder<TeatroVm>(nameof(Teatro))
                .BuscarEmTudo(filter.Search)
                .Construir();
        }

    }
}
