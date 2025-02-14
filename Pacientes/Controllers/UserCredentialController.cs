using Microsoft.AspNetCore.Mvc;
using Pacientes.Services;
using System.Collections.Generic;
using medical_health_history.Models;

namespace MedicalHealthHistory.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserCredentialController : ControllerBase
    {
        private readonly UserCredentialService _UserCredentialsService;

        public UserCredentialController(UserCredentialService UserCredentialsService)
        {
            _UserCredentialsService = UserCredentialsService;
        }

        [HttpPost]
        public ActionResult<UserCredential> AddUserCredential([FromBody] UserCredential userCredential)
        {
            var createdUserCredential = _UserCredentialsService.AddUser(userCredential);
            return CreatedAtAction(nameof(AddUserCredential), new { id = createdUserCredential.Username }, createdUserCredential);
        }

        [HttpPost("validate")]
        public IActionResult ValidateUser([FromBody] UserCredential credentials)
        {
            var isValid = _UserCredentialsService.ValidateUser(credentials);
            if (!isValid)
            {
                return Unauthorized();
            }
            return Ok();
        }
    }
}