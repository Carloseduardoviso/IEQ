using WEB.Data.Repositories.Interfaces;

namespace WEB.Data.Repositories
{
    public class LouvorRepository : ILouvorRepository
    {
        private readonly DataContext _dataContext;

        public LouvorRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
