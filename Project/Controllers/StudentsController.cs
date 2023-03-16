using Core.Dtos;
using Core.Services;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private StudentService studentService { get; set; }


        public StudentsController(StudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet("/get-all")]
        public ActionResult<List<Student>> GetAll()
        {
            var results = studentService.GetAll();

            return Ok(results);
        }

        [HttpGet("/get/{studentId}")]
        public ActionResult<Student> GetById(int studentId)
        {
            var result = studentService.GetById(studentId);

            if(result == null)
            {
                return BadRequest("Student not fount");
            }

            return Ok(result);
        }

        [HttpPatch("edit-name")]
        public ActionResult<bool> GetById([FromBody] StudentUpdateDto studentUpdateModel)
        {
            var result = studentService.EditName(studentUpdateModel);

            if (!result)
            {
                return BadRequest("Student could not be updated.");
            }

            return result;
        }

        [HttpGet("grades-by-course/{studentId}/{courseType}")]
        public ActionResult GetGradesByCourseByStudentId([FromRoute] CourseType courseType, [FromRoute] int studentId)
        {
            var result = studentService.Get_WithFilteredGrades_GetById(studentId, courseType);
            return Ok(result);
        }


    }
}
