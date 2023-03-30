using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolidProductApi.Data;
using SolidProductApi.Models;
using SolidProductApi.Services.ElectronicServices;
using SolidProductApi.Services.ProductServices;

namespace SolidProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectronicController : ControllerBase
    {
        private readonly IElectronicService _electronicService;

        // Dependency Injection af IElectronicService
        public ElectronicController(IElectronicService electronicService)
        {
            _electronicService = electronicService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Electronic>>>> GetElectronic()
        {
            var electronics = await _electronicService.GetElectronicsAsync();

            var response = new ServiceResponse<List<Electronic>>
            {
                Data = electronics.Data
            };

            return Ok(response.Data);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ServiceResponse<Electronic>>> GetElectronic([FromRoute] Guid id)
        {
            var electronic = await _electronicService.GetElectronicAsync(id);

            var response = new ServiceResponse<Electronic>
            {
                Data = electronic.Data
            };

            return Ok(response.Data);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Electronic>>> AddElectronic(Electronic electronic)
        {
            await _electronicService.AddElectronicAsync(electronic);

            var response = new ServiceResponse<Electronic>
            {
                Data = electronic
            };

            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<Electronic>>> EditElectronic(Electronic electronic)
        {
            await _electronicService.EditElectronicAsync(electronic);

            var response = new ServiceResponse<Electronic>
            {
                Data = electronic
            };

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<ServiceResponse<Electronic>>> DeleteElectronic([FromRoute] Guid id)
        {
            await _electronicService.DeleteElectronicAsync(id);

            var response = new ServiceResponse<Electronic>();

            return Ok(response);
        }
    }
}
