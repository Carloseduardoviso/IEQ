using WEB.Data.Repositories.Interfaces;

namespace WEB.Data.Repositories
{
    public class MidiaRepository : IMidiaRepository
    {
        private readonly DataContext _dataContext;

        public MidiaRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
