using System.Collections.Generic;
using System.Linq;
using medical_health_history.Repositories;
using medical_health_history.Models;


namespace Pacientes.Services
{
    public class HealthHistoryService
    {
        private readonly HealthHistoryRepository _repository;
        private readonly HealthHistoryChangeRepository _changeRepository;

        public HealthHistoryService(HealthHistoryRepository repository, HealthHistoryChangeRepository changeRepository)
        {
            _repository = repository;
            _changeRepository = changeRepository;
        }

        public IEnumerable<HealthHistory> GetHealthHistories()
        {
            return _repository.GetAll();
        }

        public HealthHistory GetHealthHistoryById(int id)
        {
            return _repository.GetById(id);
        }

        public HealthHistory AddHealthHistory(HealthHistory healthHistory)
        {
            _repository.Add(healthHistory);
            return healthHistory;
        }

        public void UpdateHealthHistory(HealthHistory healthHistory)
        {
            var existingHealthHistory = _repository.GetByIdAsNoTracking(healthHistory.Id);
            if (existingHealthHistory != null)
            {
                LogChanges(existingHealthHistory, healthHistory);
                _repository.Update(healthHistory);
            }
        }

        public void DeleteHealthHistory(int id) => _repository.Delete(id);

        private void LogChanges(HealthHistory oldHistory, HealthHistory newHistory)
        {
            var properties = typeof(HealthHistory).GetProperties();
            foreach (var property in properties)
            {
                var oldValue = property.GetValue(oldHistory)?.ToString();
                var newValue = property.GetValue(newHistory)?.ToString();

                if (oldValue != newValue)
                {
                    saveHistoryChanges(property.Name, oldValue!, newValue!, oldHistory.Id);
                }
            }            
        }
        private void saveHistoryChanges(string field, string oldValue, string newValue, int id)
        {
            _changeRepository.AddChange(new HealthHistoryChange
            {
                HealthHistoryId = id,
                ChangeDate = DateTime.Now,
                FieldName = field,
                OldValue = oldValue,
                NewValue = newValue
            });
            
        }
    }
}