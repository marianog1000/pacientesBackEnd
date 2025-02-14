using System.Collections.Generic;
using System.Linq;
using medical_health_history.Data;
using medical_health_history.Models;
using Microsoft.EntityFrameworkCore;

namespace medical_health_history.Repositories
{
    public class HealthHistoryRepository
    {
        private readonly HealthHistoryContext _context;

        public HealthHistoryRepository(HealthHistoryContext context)
        {
            _context = context;
        }

        public IEnumerable<HealthHistory> GetAll()
        {
            return _context.HealthHistories.ToList();
        }

        public HealthHistory GetById(int id)
        {
            return _context.HealthHistories.Find(id);
        }

        public HealthHistory GetByIdAsNoTracking(int id)
        {
            return _context.HealthHistories.AsNoTracking().FirstOrDefault(h => h.Id == id);
        }

        public void Add(HealthHistory healthHistory)
        {
            _context.HealthHistories.Add(healthHistory);
            _context.SaveChanges();
        }

        public void Update(HealthHistory healthHistory)
        {
            _context.HealthHistories.Update(healthHistory);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var healthHistory = _context.HealthHistories.Find(id);
            if (healthHistory != null)
            {
                _context.HealthHistories.Remove(healthHistory);
                _context.SaveChanges();
            }
        }

    }
}