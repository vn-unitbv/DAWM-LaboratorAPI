using DataLayer.Entities;

namespace DataLayer.Repositories
{
    public class StudentsRepository
    {
        public List<Student> GetAll()
        {
            var results = DbContext.Students;

            return results;
        }

        public Student GetById(int studentId)
        {
            var result = DbContext.Students
                .Where(e => e.Id == studentId)
                .FirstOrDefault();

            return result;
        }

        public Student GetByIdWithGrades(int studentId, CourseType type)
        {
            var result = DbContext.Students
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
