using System.Collections.Generic;
using System.Linq;
using medical_health_history.Data;
using medical_health_history.Models;

namespace medical_health_history.Repositories
{
    public class UserCredentialRepository
    {
        private readonly HealthHistoryContext _context;

        public UserCredentialRepository(HealthHistoryContext context)
        {
            _context = context;
        }
       
        public bool ValidateUser(UserCredential credential)
        {
            // Aquí puedes implementar la lógica de validación de usuario y contraseña
            // Por ejemplo, podrías verificar contra una tabla de usuarios en la base de datos
            // Aquí se usa un ejemplo simple con valores hardcoded para ilustrar el concepto

            var user = _context.Credentials.Find(credential.Username);
            var md5password = ComputeMd5Hash(credential.Password);

            return credential.Username == user?.Username && md5password == user?.Password;
        }


        public void CreateUser(UserCredential credential)
        {
            var md5password = ComputeMd5Hash(credential.Password);
            credential.Password = md5password;
            _context.Credentials.Add(credential);
            _context.SaveChanges();
        }

        private string ComputeMd5Hash(string input)
        {
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                var inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                var hashBytes = md5.ComputeHash(inputBytes);

                var sb = new System.Text.StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}