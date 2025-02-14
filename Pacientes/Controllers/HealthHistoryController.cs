using Microsoft.AspNetCore.Mvc;
using Pacientes.Services;
using System.Collections.Generic;
using medical_health_history.Models;

namespace MedicalHealthHistory.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthHistoryController : ControllerBase
    {
        private readonly HealthHistoryService _healthHistoryService;

        public HealthHistoryController(HealthHistoryService healthHistoryService)
        {
            _healthHistoryService = healthHistoryService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<HealthHistory>> GetHealthHistory()
        {
            var healthHistories = _healthHistoryService.GetHealthHistories();
            return Ok(healthHistories);
        }

        [HttpGet("{id}")]
        public ActionResult<HealthHistory> GetHealthHistoryById(int id)
        {
            var healthHistory = _healthHistoryService.GetHealthHistoryById(id);
            if (healthHistory == null)
            {
                return NotFound();
            }
            return Ok(healthHistory);
        }

        [HttpPost]
        public ActionResult<HealthHistory> AddHealthHistory([FromBody] HealthHistory healthHistory)
        {
            var createdHealthHistory = _healthHistoryService.AddHealthHistory(healthHistory);
            return CreatedAtAction(nameof(GetHealthHistory), new { id = createdHealthHistory.Id }, createdHealthHistory);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateHealthHistory(int id, [FromBody] HealthHistory healthHistory)
        {
            if (id != healthHistory.Id)
            {
                return BadRequest();
            }

            _healthHistoryService.UpdateHealthHistory(healthHistory);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteHealthHistory(int id)
        {
            _healthHistoryService.DeleteHealthHistory(id);
            return NoContent();
        }
    }
}