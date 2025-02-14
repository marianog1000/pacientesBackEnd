using System.Collections.Generic;
using System.Linq;
using medical_health_history.Models;
using medical_health_history.Data;

namespace medical_health_history.Repositories
{
    public class HealthHistoryChangeRepository
    {
        private readonly HealthHistoryContext _context;

        public HealthHistoryChangeRepository(HealthHistoryContext context)
        {
            _context = context;
        }

        public IEnumerable<HealthHistoryChange> GetAll()
        {
            return _context.HealthHistoryChanges.OrderByDescending(x => x.Id).ToList();
        }

        public void AddChange(HealthHistoryChange change)
        {
            _context.HealthHistoryChanges.Add(change);
            _context.SaveChanges();
        }

        public HealthHistoryChange GetById(int id)
        {
            return _context.HealthHistoryChanges.Find(id);
        }

        public IEnumerable<HealthHistoryChange> GetChangesByHealthHistoryId(int healthHistoryId)
        {
            return _context.HealthHistoryChanges.Where(c => c.HealthHistoryId == healthHistoryId).ToList();
        }
    }
}