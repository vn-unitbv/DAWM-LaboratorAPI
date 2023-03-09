using DataLayer.Entities;
using DataLayer.Repositories;
using Logic.Dtos;
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

        public bool EditName(StudentUpdateDto payload)
        {
            if (payload == null || payload.FirstName == null || payload.LastName == null)
            {
                return false;
            }

            var result = studentsRepository.GetById(payload.Id);
            if(result == null) return false;

            result.FirstName = payload.FirstName;
            result.LastName = payload.LastName;

            return true;
        }
    }
}
