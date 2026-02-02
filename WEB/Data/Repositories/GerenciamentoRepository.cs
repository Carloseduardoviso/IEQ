using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WEB.Data.Repositories.Interfaces;
using WEB.Models.Entities;

namespace WEB.Data.Repositories
{
    public class GerenciamentoRepository : IGerenciamentoRepository
    {
        private readonly DataContext _dataContext;

        public GerenciamentoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Igreja?> GetByIdIgrejaAsync(Guid igrejaId, params Expression<Func<Igreja, object?>>[]? includes)
        {
            var query = _dataContext.Igrejas.AsNoTracking();

            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }

            return await query.Where(x => x.IgrejaId == igrejaId).FirstAsync();
        }

        public Task<Pastores?> GetByIdPastoresAsync(Guid pasteresId, params Expression<Func<Pastores, object?>>[]? includes)
        {
            throw new NotImplementedException();
        }

        public Task<Regiao?> GetByIdRegiaoAsync(Guid regiaoId, params Expression<Func<Regiao, object?>>[]? includes)
        {
            throw new NotImplementedException();
        }

        public Task<SuperintendenteEstadual?> GetByIdSuperintendenteEstadualAsync(Guid superintendenteEstadualId, params Expression<Func<SuperintendenteEstadual, object?>>[]? includes)
        {
            throw new NotImplementedException();
        }

        public Task<SuperintendenteRegional?> GetByIdSuperintendenteRegionalAsync(Guid superintendenteRegionalid, params Expression<Func<SuperintendenteRegional, object?>>[]? includes)
        {
            throw new NotImplementedException();
        }
    }
}
 