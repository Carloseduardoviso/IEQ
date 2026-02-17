using System.Linq.Expressions;
using WEB.Models.Entities;
using WEB.Models.ViewModels;
using WEB.Models.ViewModels.Filtro;

namespace WEB.Helpers.Builder.Filtro
{
    public class FiltroDancaBuilder
    {
        public static Expression<Func<DancaVm, bool>>? Construir(FiltroDancaVm filtro)
        {
            if (filtro is null)
            {
                return null;
            }

            return ConstruirLambda(filtro);
        }

        public static Expression<Func<DancaVm, bool>> ConstruirLambda(FiltroDancaVm filter)
        {
            return new DancaExpressionBuilder<DancaVm>(nameof(Danca))
                .BuscarEmTudo(filter.Search)
                .Construir();
        }
    }
}
