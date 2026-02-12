using System.Linq.Expressions;
using WEB.Models.Entities;
using WEB.Models.ViewModels.Filtro;

namespace WEB.Helpers.Builder.Filtro
{
    public class FiltroRegiaoBuilder
    {
        public static Expression<Func<RegiaoVm, bool>>? Construir(FiltroRegiaoVm filtro)
        {
            if (filtro is null)
            {
                return null;
            }

            return ConstruirLambda(filtro);
        }

        public static Expression<Func<RegiaoVm, bool>> ConstruirLambda(FiltroRegiaoVm filter)
        {
            return new DiaconatoExpressionBuilder<RegiaoVm>(nameof(Regiao))
                .BuscarEmTudo(filter.Search)
                .Construir();
        }

    }
}
