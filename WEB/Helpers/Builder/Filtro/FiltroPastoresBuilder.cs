using System.Linq.Expressions;
using WEB.Models.Entities;
using WEB.Models.ViewModels.Filtro;

namespace WEB.Helpers.Builder.Filtro
{
    public class FiltroPastoresBuilder
    {
        public static Expression<Func<PastoresVm, bool>>? Construir(FiltroPastoresVm filtro)
        {
            if (filtro is null)
            {
                return null;
            }

            return ConstruirLambda(filtro);
        }

        public static Expression<Func<PastoresVm, bool>> ConstruirLambda(FiltroPastoresVm filter)
        {
            return new PastoresExpressionBuilder<PastoresVm>(nameof(Pastores))
                .BuscarEmTudo(filter.Search)
                .Construir();
        }

    }
}
