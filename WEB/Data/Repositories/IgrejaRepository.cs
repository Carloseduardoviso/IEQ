using WEB.Data.Repositories.Interfaces;

namespace WEB.Data.Repositories
{
    public class IgrejaRepository : IIgrejaRepository
    {
        private readonly DataContext _dataContext;

        public IgrejaRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
    }
}