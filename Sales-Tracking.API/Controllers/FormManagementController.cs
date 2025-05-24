using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales_Tracking.API.Models.Domains;
using Sales_Tracking.API.Services;
using System.Dynamic;

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
        [HttpGet("GetProductById/{Id}")]
        public IActionResult GetFormManagements(int Id)
        {
            if(Id == null)
            {
                return BadRequest("Id cannot be null");
            }
            // Logic to get form managements
            FormManagement response = _formMangmentService.GetProductById(Id).Result;
            if(response == null)
            {
                return NotFound("Product not found");
            }
            return Ok(response);
        }

        [HttpGet("GetProductList/{fieldName}")]
        public IActionResult GetPrdouctList(string fieldName)
        {
            // Logic to get form managements
            var response = _formMangmentService.GetProductList(fieldName).Result;
            if (response == null)
            {
                return NotFound("Product not found");
            }
            return Ok(response);
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
        [HttpPost("UpdateProduct")]
        public IActionResult UpdateProduct([FromBody] FormManagement formManagement)
        {
            // Logic to update form management
            var response = _formMangmentService.UpdateProduct(formManagement).Result;
            if(response == null)
            {
                return BadRequest("Failed to update form management");
            }

            return Ok(response);
        }


        // DELETE: api/FormManagement/{id}
        [HttpPost("RemoveProduct")]
        public IActionResult DeleteFormManagement(FormManagement formManagement)
        {
            dynamic obj = new ExpandoObject();
            // Logic to delete form management
            var response = _formMangmentService.RemoveProduct(formManagement).Result;
            if (response == true)
            {
                obj.Message = "Product deleted successfully";
                obj.StatusCode = 200;
                return Ok(obj);
            }
            else if (response == false)
            {
                obj.Message = "Product not found";
                obj.StatusCode = 404;
                return NotFound(obj);
            }
            else
            {
                obj.Message = "Failed to delete product";
                obj.StatusCode = 400;
                return BadRequest(obj);
            }
        }
    }
}
