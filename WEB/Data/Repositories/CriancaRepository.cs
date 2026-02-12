using WEB.Data.Repositories.Interfaces;

namespace WEB.Data.Repositories
{
    public class CriancaRepository : ICriancaRepository
    {
        private readonly DataContext _dataContext;

        public CriancaRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
