using DataLayer.Entities;
using DataLayer.Enums;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class ProfessorsRepository : RepositoryBase<Student>
    {
        public ProfessorsRepository(AppDbContext dbContext) : base(dbContext) 
        {
        }
    }
}
