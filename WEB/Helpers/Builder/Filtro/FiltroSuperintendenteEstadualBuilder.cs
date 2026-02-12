using System.Linq.Expressions;
using WEB.Models.Entities;
using WEB.Models.ViewModels;
using WEB.Models.ViewModels.Filtro;

namespace WEB.Helpers.Builder.Filtro
{
    public class FiltroSuperintendenteEstadualBuilder
    {
        public static Expression<Func<SuperintendenteEstadualVm, bool>>? Construir(FiltroSuperintendenteEstadualVm filtro)
        {
            if (filtro is null)
            {
                return null;
            }

            return ConstruirLambda(filtro);
        }

        public static Expression<Func<SuperintendenteEstadualVm, bool>> ConstruirLambda(FiltroSuperintendenteEstadualVm filter)
        {
            return new DiaconatoExpressionBuilder<SuperintendenteEstadualVm>(nameof(SuperintendenteEstadual))
                .BuscarEmTudo(filter.Search)
                .Construir();
        }

    }
}
