using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WEB.Data.Repositories.Interfaces;

namespace WEB.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly DataContext _db;
        protected readonly DbSet<TEntity> _dbSet;

        protected BaseRepository(DataContext db)
        {
            _db = db;
            _dbSet = db.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            _db?.Dispose();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null, params Expression<Func<TEntity, object>>[]? includes)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();

            if (includes is not null && includes.Length != 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(PropertyPath(include));
                }
            }

            var result = expression == null
                ? await query.AsNoTracking().ToListAsync()
                : await query.AsNoTracking().Where(expression).ToListAsync();

            return result;
        }

        public async Task<TEntity?> GetFirstAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object?>>[]? includes)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();

            if (includes is not null && includes.Length != 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(PropertyPath(include));
                }
            }

            return await query.FirstOrDefaultAsync(expression);
        }

        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            var entity = await _db.Set<TEntity>().FindAsync(id);
            return entity;
        }

        public async Task SaveChanges()
        {
            await _db.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.Update(entity);
        }

        public static string PropertyPath<TSource, TProperty>(Expression<Func<TSource, TProperty>> expression)
        {
            return GetFullPropertyPath(expression.Body);
        }
        private static string GetFullPropertyPath(Expression? expression)
        {
            if (expression is MemberExpression memberExpression)
            {
                // Permite a inclusão (includes) de propriedades aninhadas que não são listas,
                // Exemplo: Participante.EventoDetalhe.Evento
                //Qualquer dúvida, falar com Wesley
                var parentPath = GetFullPropertyPath(memberExpression.Expression);
                return string.IsNullOrEmpty(parentPath) ? memberExpression.Member.Name : $"{parentPath}.{memberExpression.Member.Name}";
            }

            if (expression is UnaryExpression unaryExpression)
            {
                return GetFullPropertyPath(unaryExpression.Operand);
            }

            if (expression is MethodCallExpression methodCallExpression)
            {
                return ExtractSelectMemberPath(methodCallExpression);
            }

            return string.Empty;
        }

        public static string ExtractSelectMemberPath(MethodCallExpression methodCallExpression)
        {
            if (methodCallExpression.Method.Name == "Select" && methodCallExpression.Arguments.Count == 2)
            {
                var lambdaExpression = ExtractLambdaExpression(methodCallExpression.Arguments[1]);
                if (lambdaExpression != null)
                {
                    var selectPart = GetFullPropertyPath(lambdaExpression.Body);
                    var pathBeforeSelect = GetFullPropertyPath(methodCallExpression.Arguments[0]);

                    //includes de tabelas meios
                    return $"{pathBeforeSelect}.{selectPart}";
                }
            }

            return GetFullPropertyPath(methodCallExpression.Arguments[0]);
        }
        private static LambdaExpression? ExtractLambdaExpression(Expression expression)
        {
            if (expression is LambdaExpression lambdaExpression)
            {
                return lambdaExpression;
            }

            if (expression is UnaryExpression unaryExpression && unaryExpression.Operand is LambdaExpression innerLambdaExpression)
            {
                return innerLambdaExpression;
            }

            return null;

        }

    }
}
