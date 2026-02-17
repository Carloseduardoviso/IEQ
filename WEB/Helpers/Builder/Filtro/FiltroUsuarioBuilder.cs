using System.Linq.Expressions;
using WEB.Models.Entities;
using WEB.Models.ViewModels;
using WEB.Models.ViewModels.Filtro;

namespace WEB.Helpers.Builder.Filtro
{
    public class FiltroUsuarioBuilder
    {
        public static Expression<Func<UsuarioVm, bool>>? Construir(FiltroUsuarioVm filtro)
        {
            if (filtro is null)
            {
                return null;
            }

            return ConstruirLambda(filtro);
        }

        public static Expression<Func<UsuarioVm, bool>> ConstruirLambda(FiltroUsuarioVm filter)
        {
            return new UsuarioExpressionBuilder<UsuarioVm>(nameof(Usuario))
                .BuscarEmTudo(filter.Search)
                .Construir();
        }
    }
}
