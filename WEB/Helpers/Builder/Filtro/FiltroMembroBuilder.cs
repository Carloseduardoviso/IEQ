using System.Linq.Expressions;
using WEB.Models.Entities;
using WEB.Models.ViewModels;
using WEB.Models.ViewModels.Filtro;

namespace WEB.Helpers.Builder.Filtro
{
    public class FiltroMembroBuilder
    {
        public static Expression<Func<MembroVm, bool>>? Construir(FiltroMembroVm filtro)
        {
            if (filtro is null)
            {
                return null;
            }

            return ConstruirLambda(filtro);
        }

        public static Expression<Func<MembroVm, bool>> ConstruirLambda(FiltroMembroVm filter)
        {
            return new MembroExpressionBuilder<MembroVm>(nameof(Membro))
                .BuscarEmTudo(filter.Search)
                .Construir();
        }

    }
}
