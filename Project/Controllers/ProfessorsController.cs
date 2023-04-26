using Core.Dtos;
using Core.Services;
using DataLayer.Dtos;
using DataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Project.Controllers
{
    [ApiController]
    [Route("api/professors")]
    [Authorize]
    public class ProfessorsController : ControllerBase
    {
        private ProfessorService professorService { get; set; }


        public ProfessorsController(ProfessorService professorService)
        {
            this.professorService = professorService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public IActionResult Register(RegisterDto payload)
        {
            professorService.Register(payload);
            return Ok();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(LoginDto payload)
        {
            var jwtToken = professorService.Validate(payload);

            return Ok(new {token = jwtToken});
        }
    }
}
