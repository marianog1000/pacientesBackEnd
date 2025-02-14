using Microsoft.AspNetCore.Mvc;
using Pacientes.Services;
using System.Collections.Generic;
using medical_health_history.Models;

namespace MedicalHealthHistory.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthHistoryChangeController : ControllerBase
    {
        private readonly HealthHistoryChangeService _healthHistoryChangeService;

        public HealthHistoryChangeController(HealthHistoryChangeService healthHistoryChangeService)
        {
            _healthHistoryChangeService = healthHistoryChangeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<HealthHistoryChange>> GetHealthHistory()
        {
            var healthHistories = _healthHistoryChangeService.GetHealthHistoryChanges();
            return Ok(healthHistories);
        }

        [HttpGet("{id}")]
        public ActionResult<HealthHistoryChange> GetHealthHistoryById(int id)
        {
            var healthHistory = _healthHistoryChangeService.GetHealthHistoryChangesById(id);
            if (healthHistory == null)
            {
                return NotFound();
            }
            return Ok(healthHistory);
        }

        [HttpPost]
        public ActionResult<HealthHistoryChange> AddHealthHistoryChange([FromBody] HealthHistoryChange healthHistoryChange)
        {
            var createdHealthHistory = _healthHistoryChangeService.AddHealthHistoryChange(healthHistoryChange);
            return CreatedAtAction(nameof(GetHealthHistory), new { id = createdHealthHistory.Id }, createdHealthHistory);
        }
    }
}