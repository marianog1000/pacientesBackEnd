using System;

namespace medical_health_history.Models
{
    public class HealthHistoryChange
    {
        public int Id { get; set; }
        public int HealthHistoryId { get; set; }
        public DateTime ChangeDate { get; set; }
        public string FieldName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
    }
}