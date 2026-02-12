using System.Linq.Expressions;
using WEB.Models.Entities;
using WEB.Models.ViewModels;
using WEB.Models.ViewModels.Filtro;

namespace WEB.Helpers.Builder.Filtro
{
    public class FiltroHomensBuilder
    {
        public static Expression<Func<HomensVm, bool>>? Construir(FiltroHomensVm filtro)
        {
            if (filtro is null)
            {
                return null;
            }

            return ConstruirLambda(filtro);
        }

        public static Expression<Func<HomensVm, bool>> ConstruirLambda(FiltroHomensVm filter)
        {
            return new DiaconatoExpressionBuilder<HomensVm>(nameof(Homens))
                .BuscarEmTudo(filter.Search)
                .Construir();
        }

    }
}