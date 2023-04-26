using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace DataLayer.Repositories
{
    public class GradesRepository : RepositoryBase<Grade>
    {
        public GradesRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
