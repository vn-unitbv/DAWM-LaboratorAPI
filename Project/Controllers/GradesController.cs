using Core.Dtos;
using Core.Services;
using DataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    [ApiController]
    [Route("api/grades")]
    [Authorize]
    public class GradesController : ControllerBase
    {
        private GradeService gradeService { get; set; }
        private UserManager<User> userManager { get; set; }
        

        public GradesController(GradeService gradeService)
        {
            this.gradeService = gradeService;
        }

        // Am vrut ca path-urile celor doua endpoint-uri mai jos sa fie
        // aceleasi, dar accesibile cu diferite roluri, dar n-am reusit
        // sa fac

        [HttpGet("get-student")]
        [Authorize(Roles = "Student")]
        public ActionResult<GradesByStudent> GetStudentGrades()
        {
            // nu stiu daca asta e cea mai buna metoda pentru a determina user-ul actual
            // am gasit ceva despre UserManager, IdentityUser etc. dar nu stiu cum sa le folosesc momentan
            var userIdClaim = User.FindFirst(claim => claim.Type.Equals("userId"));
            var userId = Int32.Parse(userIdClaim.Value);
            var result = gradeService.GetGradesForStudent(userId);

            return Ok(result);
        }

        [HttpGet("get-professor")]
        [Authorize(Roles = "Professor")]
        public ActionResult<GradesByStudent> GetAllStudentGrades()
        {
            var result = gradeService.GetGradesForAllStudents();

            return Ok(result);
        }
    }
}
