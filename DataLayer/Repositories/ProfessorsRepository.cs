using DataLayer.Entities;
using DataLayer.Enums;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class ProfessorsRepository : RepositoryBase<Professor>
    {
        public ProfessorsRepository(AppDbContext dbContext) : base(dbContext) 
        {
        }
    }
}
