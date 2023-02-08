using Microsoft.AspNetCore.Mvc;
using TinFur.Models;
using TinFur.Services;

namespace TinFur.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly PetService _petService;

        public PetController(PetService employeeService) => _petService = employeeService;

        [HttpGet]
        public async Task<List<Pet>> Get() => await _petService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Pet>> Get(string id)
        {
            var employee = await _petService.GetAsync(id);

            if (employee is null)
            {
                return NotFound();
            }

            return employee;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Pet newEmployee)
        {
            await _petService.CreateAsync(newEmployee);

            return NoContent();
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Pet updatedEmployee)
        {
            var employee = await _petService.GetAsync(id);

            if (employee is null)
            {
                return NotFound();
            }

            updatedEmployee.Id = employee.Id;

            await _petService.UpdateAsync(id, updatedEmployee);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var employee = await _petService.GetAsync(id);

            if (employee is null)
            {
                return NotFound();
            }

            await _petService.RemoveAsync(id);

            return NoContent();
        }
    }
}
