using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class GradeService
    {
        private readonly UnitOfWork unitOfWork;

        public GradeService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
