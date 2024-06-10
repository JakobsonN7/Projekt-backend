using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Service
{
    public interface IRegistrationService
    {
        Task<IEnumerable<RegistrationModel>> GetAllRegistrationsAsync();
        Task<RegistrationModel> GetRegistrationByIdAsync(int id);
        Task<RegistrationModel> CreateRegistrationAsync(RegistrationModel registrationModel);
        Task<RegistrationModel> UpdateRegistrationAsync(RegistrationModel registrationModel);
        Task<bool> DeleteRegistrationAsync(int id);
    }
}
