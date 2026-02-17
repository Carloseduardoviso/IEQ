using System.Linq.Expressions;
using WEB.Models.Entities;
using WEB.Models.ViewModels;
using WEB.Models.ViewModels.Filtro;

namespace WEB.Helpers.Builder.Filtro
{
    public class FiltroCriancaBuilder
    {
        public static Expression<Func<CriancaVm, bool>>? Construir(FiltroCriancaVm filtro)
        {
            if (filtro is null)
            {
                return null;
            }

            return ConstruirLambda(filtro);
        }

        public static Expression<Func<CriancaVm, bool>> ConstruirLambda(FiltroCriancaVm filter)
        {
            return new CriancaExpressionBuilder<CriancaVm>(nameof(Crianca))
                .BuscarEmTudo(filter.Search)
                .Construir();
        }
    }
}
