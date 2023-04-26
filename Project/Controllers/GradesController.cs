using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    [ApiController]
    [Route("api/grades")]
    [Authorize]
    public class GradesController : ControllerBase
    {
        private GradeService gradeService { get; set; }


        public GradesController(GradeService gradeService)
        {
            this.gradeService = gradeService;
        }
    }
}
