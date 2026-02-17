using System.Linq.Expressions;
using WEB.Models.Entities;
using WEB.Models.ViewModels;
using WEB.Models.ViewModels.Filtro;

namespace WEB.Helpers.Builder.Filtro
{
    public class FiltroMidiaBuilder
    {
        public static Expression<Func<MidiaVm, bool>>? Construir(FiltroMidiaVm filtro)
        {
            if (filtro is null)
            {
                return null;
            }

            return ConstruirLambda(filtro);
        }

        public static Expression<Func<MidiaVm, bool>> ConstruirLambda(FiltroMidiaVm filter)
        {
            return new MidiaExpressionBuilder<MidiaVm>(nameof(Midia))
                .BuscarEmTudo(filter.Search)
                .Construir();
        }

    }
}
