using System.Linq.Expressions;
using WEB.Models.Entities;
using WEB.Models.ViewModels;
using WEB.Models.ViewModels.Filtro;

namespace WEB.Helpers.Builder.Filtro
{
    public class FiltroCasalBuilder
    {
        public static Expression<Func<CasalVm, bool>>? Construir(FiltroCasalVm filtro)
        {
            if (filtro is null)
            {
                return null;
            }

            return ConstruirLambda(filtro);
        }

        public static Expression<Func<CasalVm, bool>> ConstruirLambda(FiltroCasalVm filter)
        {
            return new CasalExpressionBuilder<CasalVm>(nameof(Casal))
                .BuscarEmTudo(filter.Search)
                .Construir();
        }
    }
}