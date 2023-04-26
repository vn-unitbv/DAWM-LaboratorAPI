using Core.Dtos;
using DataLayer;
using DataLayer.Mapping;
using GradeDto = DataLayer.Dtos.GradeDto;

namespace Core.Services
{
    public class GradeService
    {
        private readonly UnitOfWork unitOfWork;

        public GradeService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<GradeDto> GetGradesForStudent(int studentId)
        {
            var student = unitOfWork.Students.GetById(studentId);

            if (student == null) return new();

            return student.Grades.ToGradeDtos();
        }

        public List<GradesByStudent> GetGradesForAllStudents()
        {
            return unitOfWork.Students
                .GetAll()
                .Select(e => new GradesByStudent(e))
                .ToList();
        }
    }
}
