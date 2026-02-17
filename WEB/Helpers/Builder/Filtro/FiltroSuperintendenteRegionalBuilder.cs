using System.Linq.Expressions;
using WEB.Models.Entities;
using WEB.Models.ViewModels;
using WEB.Models.ViewModels.Filtro;

namespace WEB.Helpers.Builder.Filtro
{
    public class FiltroSuperintendenteRegionalBuilder
    {
        public static Expression<Func<SuperintendenteRegionalVm, bool>>? Construir(FiltroSuperintendenteRegionalVm filtro)
        {
            if (filtro is null)
            {
                return null;
            }

            return ConstruirLambda(filtro);
        }

        public static Expression<Func<SuperintendenteRegionalVm, bool>> ConstruirLambda(FiltroSuperintendenteRegionalVm filter)
        {
            return new SuperintendenteRegionalExpressionBuilder<SuperintendenteRegionalVm>(nameof(SuperintendenteRegional))
                .BuscarEmTudo(filter.Search)
                .Construir();
        }

    }
}
