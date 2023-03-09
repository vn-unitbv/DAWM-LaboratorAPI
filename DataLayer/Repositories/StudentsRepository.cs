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
    }
}
