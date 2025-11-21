using System.Linq.Expressions;
using WEB.Models.Entities;
using WEB.Models.ViewModels;

namespace WEB.Helpers.Builder.Filtro
{
    public class FiltroDiaconatoBuilder
    {
        public static Expression<Func<DiaconatoVm, bool>>? Construir(FiltroDiaconatoVm filtroDiaconatoVm)
        {
            if (filtroDiaconatoVm is null)
            {
                return null;
            }

            return ConstruirLambda(filtroDiaconatoVm);
        }

        public static Expression<Func<DiaconatoVm, bool>> ConstruirLambda(FiltroDiaconatoVm filter)
        {
            return new DiaconatoExpressionBuilder<DiaconatoVm>(nameof(Diaconato))
                .BuscarEmTudo(filter.Search)
                .Construir();
        }
    }
}
