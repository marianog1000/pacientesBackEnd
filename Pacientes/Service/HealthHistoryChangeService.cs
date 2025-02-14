using System.Collections.Generic;
using System.Linq;
using medical_health_history.Repositories;
using medical_health_history.Models;


namespace Pacientes.Services
{
    public class HealthHistoryChangeService
    {        
        private readonly HealthHistoryChangeRepository _changeRepository;

        public HealthHistoryChangeService(HealthHistoryChangeRepository changeRepository)
        {            
            _changeRepository = changeRepository;
        }

        public IEnumerable<HealthHistoryChange> GetHealthHistoryChanges()
        {
            return _changeRepository.GetAll();
        }

        public HealthHistoryChange GetHealthHistoryChangesById(int id)
        {
            return _changeRepository.GetById(id);
        }

        public HealthHistoryChange AddHealthHistoryChange(HealthHistoryChange healthHistoryChange)
        {
            _changeRepository.AddChange(healthHistoryChange);
            return healthHistoryChange;
        }
    }
}