using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales_Tracking.API.Models.Domains;
using Sales_Tracking.API.Services;

namespace Sales_Tracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormManagementController : ControllerBase
    {
        private readonly FormMangmentService _formMangmentService;
        public FormManagementController(FormMangmentService formMangmentService)
        {
            _formMangmentService = formMangmentService;
        }

        // GET: api/FormManagement
        [HttpGet("GetFormManagmentById/{Id}")]
        public IActionResult GetFormManagements(int Id)
        {
            // Logic to get form managements
            return Ok();
        }

        // POST: api/FormManagement
        [HttpPost("AddProduct")]
        public async Task<IActionResult> CreateFormManagement([FromBody] FormManagement formManagement)
        {
            // Logic to create form management
            var resposne = _formMangmentService.AddProduct(formManagement);
            if(resposne == null)
            {
                return BadRequest("Failed to create form management");
            }
            return Ok(resposne);
        }


        // PUT: api/FormManagement/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateFormManagement(int id, [FromBody] FormManagement formManagement)
        {
            // Logic to update form management
            return NoContent();
        }


        // DELETE: api/FormManagement/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteFormManagement(int id)
        {
            // Logic to delete form management
            return NoContent();
        }
    }
}
