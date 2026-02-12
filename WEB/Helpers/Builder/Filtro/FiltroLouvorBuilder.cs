using System.Linq.Expressions;
using WEB.Models.Entities;
using WEB.Models.ViewModels;
using WEB.Models.ViewModels.Filtro;

namespace WEB.Helpers.Builder.Filtro
{
    public class FiltroLouvorBuilder
    {
        public static Expression<Func<LouvorVm, bool>>? Construir(FiltroLouvorVm filtro)
        {
            if (filtro is null)
            {
                return null;
            }

            return ConstruirLambda(filtro);
        }

        public static Expression<Func<LouvorVm, bool>> ConstruirLambda(FiltroLouvorVm filter)
        {
            return new DiaconatoExpressionBuilder<LouvorVm>(nameof(Louvor))
                .BuscarEmTudo(filter.Search)
                .Construir();
        }

    }
}
