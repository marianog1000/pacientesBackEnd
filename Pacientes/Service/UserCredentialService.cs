using System.Collections.Generic;
using System.Linq;
using medical_health_history.Repositories;
using medical_health_history.Models;


namespace Pacientes.Services
{
    public class UserCredentialService
    {
        private readonly UserCredentialRepository _repository;

        public UserCredentialService(UserCredentialRepository repository)
        {
            _repository = repository;
        }

        public UserCredential AddUser(UserCredential userCredential)
        {
            _repository.CreateUser(userCredential);
            return userCredential;
        }

        public bool ValidateUser(UserCredential credential)
        {
            return _repository.ValidateUser(credential);
        }
    }
}