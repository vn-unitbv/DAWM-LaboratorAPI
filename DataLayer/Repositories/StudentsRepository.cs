using DataLayer.Entities;
using DataLayer.Enums;

namespace DataLayer.Repositories
{
    public class StudentsRepository : RepositoryBase<Student>
    {
        private readonly AppDbContext dbContext;

        public StudentsRepository(AppDbContext dbContext) : base(dbContext) { }

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
