using WEB.Data.Repositories.Interfaces;

namespace WEB.Data.Repositories
{
    public class JovemAdolescenteRepository : IJovemAdolescenteRepository
    {
        private readonly DataContext _dataContext;

        public JovemAdolescenteRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
