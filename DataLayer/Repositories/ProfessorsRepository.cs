﻿using DataLayer.Entities;
using DataLayer.Enums;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class ProfessorsRepository : RepositoryBase<Professor>
    {
        public ProfessorsRepository(AppDbContext dbContext) : base(dbContext) 
        {
        }

        public Professor GetByEmail(string email)
        {
            return GetRecords().FirstOrDefault(s => s.Email == email);
        }
    }
}
