using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using WEB.Data.Repositories.Interfaces;
using WEB.Models.Entities;

namespace WEB.Data.Repositories
{
    public class CriancaRepository : ICriancaRepository
    {
        private readonly DataContext _dataContext;

        public CriancaRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(Crianca result)
        {
            await _dataContext.AddAsync(result);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Crianca>> GetAllAsync(Expression<Func<Crianca, bool>> expression, Expression<Func<Crianca, object>>[] expressions)
        {
            IQueryable<Crianca> query = _dataContext.Criancas.AsNoTracking();

            query = IncludeAllProperties(query);

            if (expression is not null)
                query = query.Where(expression);

            return await query
                .OrderBy(c => c.NomeCompleto)
                .ToListAsync();
        }

        public async Task<(IEnumerable<Crianca> lista, int count)> GetAllPaginationAsync(Expression<Func<Crianca, bool>>? expression, int skip)
        {
            var query = _dataContext.Criancas.AsNoTracking();
            query = IncludeAllProperties(query);

            if (expression != null) query = query.Where(expression);
            var lista = await query.Where(x => x.Ativo).OrderBy(x => x.NomeCompleto).Skip(skip).Take(5).ToListAsync();
            var count = await query.CountAsync();

            return (lista, count);
        }

        public async Task<Crianca?> GetByIdAllIncludesAsync(Guid id, Expression<Func<Crianca, bool>>? expression = null)
        {
            IQueryable<Crianca> query = _dataContext.Criancas.AsNoTracking();

            query = IncludeAllProperties(query);

            if (expression is not null)
            {
                query = query.Where(expression);
            }

            var result = await query.FirstOrDefaultAsync(e => e.CriancaId == id);

            return result;
        }

        public async Task<Crianca> GetByIdAsync(Guid id)
        {
            return await IncludeAllProperties(_dataContext.Criancas)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.CriancaId == id);
        }

        public async Task InativarAsync(Guid id)
        {
            var item = await GetByIdAsync(id);

            item.Ativo = false;
            item.DataInativacao = DateTime.Today;

            // Se nunca foi reativado antes, usa DataMinisterio como início
            var inicio = item.DataReativacao ?? item.DataMinisterio;

            if (inicio == null)
                throw new Exception("DataMinisterio não pode ser nula.");

            var fim = DateTime.Today;

            int meses = ((fim.Year - inicio.Value.Year) * 12) + fim.Month - inicio.Value.Month;

            if (fim.Day < inicio.Value.Day)
                meses--;

            item.TempoAcumuladoEmMeses += Math.Max(0, meses);

            // Zera início para o próximo ciclo
            item.DataReativacao = null;

            await Update(item);
        }

        public async Task ReativarAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);

            if (entity != null)
            {
                entity.Ativo = true;
                entity.DataReativacao = DateTime.Today;
                _dataContext.Criancas.Update(entity);
                await _dataContext.SaveChangesAsync();
            }
        }

        public Task Remover(Crianca result)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Crianca result)
        {
            _dataContext.Criancas.Update(result);
            await _dataContext.SaveChangesAsync();
        }

        private IQueryable<Crianca> IncludeAllProperties(IQueryable<Crianca> query)
        {
            return query.Include(x => x.Igreja).Include(x => x.Regiao).Include(x => x.Pastor).Include(x => x.SuperintendenteRegional).Include(x => x.SuperintendenteEstadual);
        }
    }
}
