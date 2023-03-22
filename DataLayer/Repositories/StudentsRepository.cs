using DataLayer.Entities;
using DataLayer.Enums;

namespace DataLayer.Repositories
{
    public class StudentsRepository
    {
        private readonly AppDbContext dbContext;

        public StudentsRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Student> GetAll()
        {
            var results = dbContext.Students
                .ToList();

            return results;
        }

        public Student GetById(int studentId)
        {
            var result = dbContext.Students
                .Where(e => e.Id == studentId)
                .FirstOrDefault();

            return result;
        }

        public Student GetByIdWithGrades(int studentId, CourseType type)
        {
            var result = dbContext.Students
               .Select(e => new Student
               {
                    FirstName= e.FirstName,
                    LastName= e.LastName,
                    Id = e.Id,
                    ClassId= e.ClassId,
                    Grades = e.Grades
                        .Where(g => g.Course == type)
                        .OrderByDescending(g => g.Value)
                        .ToList()
               })
               .FirstOrDefault(e => e.Id == studentId);

            return result;
        }
    }
}
