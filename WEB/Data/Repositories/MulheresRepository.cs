using WEB.Data.Repositories.Interfaces;

namespace WEB.Data.Repositories
{
    public class MulheresRepository : IMulheresRepository
    {
        private readonly DataContext _dataContext;

        public MulheresRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
