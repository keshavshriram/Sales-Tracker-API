using Microsoft.AspNetCore.Mvc;
using Sales_Tracking.API.Models.Domains;
using Sales_Tracking.API.Services;

namespace Sales_Tracking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaterialManagementController : ControllerBase
    {
        private readonly MaterialManagementService _service;

        public MaterialManagementController(MaterialManagementService service)
        {
            _service = service;
        }

        [HttpGet("GetAllOrders")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("GetOrderById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null || result.IsRecordDeleted)
                return NotFound();
            return Ok(result);
        }

        [HttpPost("CreateOrder")]
        public async Task<IActionResult> Create([FromBody] MaterialManagement model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _service.CreateAsync(model);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPost("UpdateOrder")]
        public async Task<IActionResult> Update([FromBody] MaterialManagement model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _service.UpdateAsync(model);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        [HttpPost("RemoveOrder")]
        public async Task<IActionResult> Delete(MaterialManagement materialManagement)
        {
            var success = await _service.DeleteAsync(materialManagement.Id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
