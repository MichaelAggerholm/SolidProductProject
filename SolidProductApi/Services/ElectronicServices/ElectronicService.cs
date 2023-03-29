using Microsoft.EntityFrameworkCore;
using SolidProductApi.Models;
using SolidProductApi.Services.ProductServices;

namespace SolidProductApi.Services.ElectronicServices
{
    public class ElectronicService : ProductService, IElectronicService
    {
        private readonly DataContext _context;

        public ElectronicService(DataContext DataContext) : base(DataContext)
        {
            _context = DataContext;
        }

        public async Task<ServiceResponse<List<Electronic>>> GetElectronicsAsync()
        {
            var serviceResponse = new ServiceResponse<List<Electronic>>();

            var electronics = await _context.Electronics.ToListAsync();
            serviceResponse.Data = electronics;

            return serviceResponse;
        }

        public async Task<ServiceResponse<Electronic>> AddElectronicAsync(Electronic electronic)
        {
            var response = new ServiceResponse<Electronic>();

            electronic.Id = Guid.NewGuid();

            await _context.Electronics.AddAsync(electronic);
            await _context.SaveChangesAsync();

            response.Data = electronic;

            return response;
        }

        public async Task<ServiceResponse<Electronic>> GetElectronicAsync(Guid id)
        {
            var response = new ServiceResponse<Electronic>();

            var electronic = await _context.Electronics.FirstOrDefaultAsync(p => p.Id == id);

            response.Data = electronic;

            return response;
        }

        public async Task<ServiceResponse<Electronic>> EditElectronicAsync(Electronic electronic)
        {
            var response = new ServiceResponse<Electronic>();

            var electronicToUpdate = await _context.Electronics.FirstOrDefaultAsync(p => p.Id == electronic.Id);

            electronicToUpdate.Title = electronic.Title;
            electronicToUpdate.Description = electronic.Description;
            electronicToUpdate.Price = electronic.Price;
            electronicToUpdate.Brand = electronic.Brand;
            electronicToUpdate.Model = electronic.Model;
            electronicToUpdate.Type = electronic.Type;

            await _context.SaveChangesAsync();
            response.Data = electronicToUpdate;

            return response;
        }

        public async Task<ServiceResponse<Electronic>> DeleteElectronicAsync(Guid id)
        {
            var response = new ServiceResponse<Electronic>();
            var electronicToDelete = await _context.Electronics.FirstOrDefaultAsync(p => p.Id == id);

            _context.Electronics.Remove(electronicToDelete);
            await _context.SaveChangesAsync();
            response.Data = electronicToDelete;

            return response;
        }
    }
}
