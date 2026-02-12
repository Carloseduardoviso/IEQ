using WEB.Data.Repositories.Interfaces;

namespace WEB.Data.Repositories
{
    public class HomensRepository : IHomensRepository
    {
        private readonly DataContext _dataContext;

        public HomensRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
