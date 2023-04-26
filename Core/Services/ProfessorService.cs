using Core.Dtos;
using DataLayer;
using DataLayer.Dtos;
using DataLayer.Entities;
using DataLayer.Enums;
using DataLayer.Mapping;
using DataLayer.Repositories;

namespace Core.Services
{
    public class ProfessorService
    {
        private readonly UnitOfWork unitOfWork;

        private AuthorizationService authService { get; set; }

        public ProfessorService(UnitOfWork unitOfWork, AuthorizationService authService)
        {
            this.unitOfWork = unitOfWork;
            this.authService = authService;
        }

        public void Register(RegisterDto registerData)
        {
            if (registerData == null)
            {
                return;
            }

            var hashedPassword = authService.HashPassword(registerData.Password);

            var professor = new Professor
            {
                FirstName = registerData.FirstName,
                LastName = registerData.LastName,
                Email = registerData.Email,
                PasswordHash = hashedPassword,
            };

            unitOfWork.Professors.Insert(professor);
            unitOfWork.SaveChanges();
        }

        public string Validate(LoginDto payload)
        {
            var professor = unitOfWork.Professors.GetByEmail(payload.Email);

            var passwordFine = authService.VerifyHashedPassword(professor.PasswordHash, payload.Password);

            if (passwordFine)
            {
                return authService.GetToken(professor);
            }
            else
            {
                return null;
            }

        }
    }
}
