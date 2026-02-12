using WEB.Data.Repositories.Interfaces;

namespace WEB.Data.Repositories
{
    public class TeatroRepository : ITeatroRepository
    {
        private readonly DataContext _dataContext;

        public TeatroRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
