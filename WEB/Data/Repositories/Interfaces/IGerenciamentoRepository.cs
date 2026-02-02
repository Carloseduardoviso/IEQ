using System.Linq.Expressions;
using WEB.Models.Entities;

namespace WEB.Data.Repositories.Interfaces
{
    public interface IGerenciamentoRepository
    {
        Task<Igreja?> GetByIdIgrejaAsync(Guid igrejaId, params Expression<Func<Igreja, object?>>[]? includes);
        Task<Pastores?> GetByIdPastoresAsync(Guid pasteresId, params Expression<Func<Pastores, object?>>[]? includes);
        Task<Regiao?> GetByIdRegiaoAsync(Guid regiaoId, params Expression<Func<Regiao, object?>>[]? includes);
        Task<SuperintendenteEstadual?> GetByIdSuperintendenteEstadualAsync(Guid superintendenteEstadualId, params Expression<Func<SuperintendenteEstadual, object?>>[]? includes);
        Task<SuperintendenteRegional?> GetByIdSuperintendenteRegionalAsync(Guid superintendenteRegionalid, params Expression<Func<SuperintendenteRegional, object?>>[]? includes);
    }
}