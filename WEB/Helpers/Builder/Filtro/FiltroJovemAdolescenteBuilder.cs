using System.Linq.Expressions;
using WEB.Models.Entities;
using WEB.Models.ViewModels;
using WEB.Models.ViewModels.Filtro;

namespace WEB.Helpers.Builder.Filtro
{
    public class FiltroJovemAdolescenteBuilder
    {
        public static Expression<Func<JovemAdolescenteVm, bool>>? Construir(FiltroJovemAdolescenteVm filtro)
        {
            if (filtro is null)
            {
                return null;
            }

            return ConstruirLambda(filtro);
        }

        public static Expression<Func<JovemAdolescenteVm, bool>> ConstruirLambda(FiltroJovemAdolescenteVm filter)
        {
            return new JovemAdolescenteExpressionBuilder<JovemAdolescenteVm>(nameof(JovemAdolescente))
                .BuscarEmTudo(filter.Search)
                .Construir();
        }
    }
}
