using SolidProductApi.Models;

namespace SolidProductApi.Services.ElectronicServices
{
    // Interface benyttes for at sikre at alle klasser der implementerer denne interface, har de samme metoder.
    public interface IElectronicService
    {
        Task<ServiceResponse<List<Electronic>>> GetElectronicsAsync();
        Task<ServiceResponse<Electronic>> GetElectronicAsync(Guid id);
        Task<ServiceResponse<Electronic>> AddElectronicAsync(Electronic electronic);
        Task<ServiceResponse<Electronic>> EditElectronicAsync(Electronic electronic);
        Task<ServiceResponse<Electronic>> DeleteElectronicAsync(Guid id);
    }
}