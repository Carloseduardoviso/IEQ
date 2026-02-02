
using System.Linq.Expressions;
using WEB.Models.ViewModels;

namespace WEB.Services.Interfaces
{
    public interface IGerenciamentoService
    {
        Task<RegiaoVm?> GetByIdRegiaoAsync(Guid regiaoId, params Expression<Func<RegiaoVm, object?>>[]? includes);
        Task<IgrejaVm?> GetByIdIgrejaAsync(Guid igrejaId, params Expression<Func<IgrejaVm, object?>>[]? includes);
        Task<PastoresVm?> GetByIdPastoresAsync(Guid pasteresId, params Expression<Func<PastoresVm, object?>>[]? includes);
        Task<SuperintendenteEstadualVm?> GetByIdSuperintendenteEstadualAsync(Guid superintendenteEstadualId, params Expression<Func<SuperintendenteEstadualVm, object?>>[]? includes);
        Task<SuperintendenteRegionalVm?> GetByIdSuperintendenteRegionalAsync(Guid superintendenteRegionalid, params Expression<Func<SuperintendenteRegionalVm, object?>>[]? includes);
    }
}
