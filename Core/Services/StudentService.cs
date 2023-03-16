using Core.Dtos;
using DataLayer.Dtos;
using DataLayer.Entities;
using DataLayer.Mapping;
using DataLayer.Repositories;

namespace Core.Services
{
    public class StudentService
    {
        private StudentsRepository studentsRepository { get; set; }

        public StudentService(StudentsRepository studentsRepository)
        {
            this.studentsRepository = studentsRepository;
        }

        public List<Student> GetAll()
        {
            var results = studentsRepository.GetAll();

            return results;
        }

        public StudentDto GetById(int studentId)
        {
            var student = studentsRepository.GetById(studentId);

            var result = student.ToStudentDto();

            return result;
        }

        public bool EditName(StudentUpdateDto payload)
        {
            if (payload == null || payload.FirstName == null || payload.LastName == null)
            {
                return false;
            }

            var result = studentsRepository.GetById(payload.Id);
            if (result == null) return false;

            result.FirstName = payload.FirstName;
            result.LastName = payload.LastName;

            return true;
        }

        public GradesByStudent GetGradesById(int studentId, CourseType courseType)
        {
            var studentWithGrades = studentsRepository.GetByIdWithGrades(studentId, courseType);
            
            var result = new GradesByStudent(studentWithGrades);

            return result;
        }
    }
}
