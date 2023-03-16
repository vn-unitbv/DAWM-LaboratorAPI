using DataLayer.Entities;
using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
    public class StudentGradesRequest
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public CourseType CourseType { get; set; }
    }
}
