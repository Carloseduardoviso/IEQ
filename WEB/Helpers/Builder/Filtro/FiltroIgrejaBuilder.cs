using System.Linq.Expressions;
using WEB.Models.Entities;
using WEB.Models.ViewModels.Filtro;

namespace WEB.Helpers.Builder.Filtro
{
    public class FiltroIgrejaBuilder
    {
        public static Expression<Func<IgrejaVm, bool>>? Construir(FiltroIgrejaVm filtro)
        {
            if (filtro is null)
            {
                return null;
            }

            return ConstruirLambda(filtro);
        }

        public static Expression<Func<IgrejaVm, bool>> ConstruirLambda(FiltroIgrejaVm filter)
        {
            return new IgrejaExpressionBuilder<IgrejaVm>(nameof(Igreja))
                .BuscarEmTudo(filter.Search)
                .Construir();
        }

    }
}
