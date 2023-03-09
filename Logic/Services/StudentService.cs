using DataLayer.Entities;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
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

        public Student GetById(int studentId)
        {
            var result = studentsRepository.GetById(studentId);

            return result;
        }

    }
}
