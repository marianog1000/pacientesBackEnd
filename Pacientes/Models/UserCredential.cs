using System.ComponentModel.DataAnnotations;

namespace medical_health_history.Models
{
    public class UserCredential
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}