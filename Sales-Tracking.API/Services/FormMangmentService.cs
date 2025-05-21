using Sales_Tracking.API.Data;
using Sales_Tracking.API.Models.Domains;

namespace Sales_Tracking.API.Services
{
    public class FormMangmentService
    {
        private readonly TrackerDBContext _context;
        public FormMangmentService(TrackerDBContext context)
        {
            // Constructor logic here
            _context = context;
        }

        public async Task<FormManagement> AddProduct(FormManagement formManagement)
        {
            try
            {
                 _context.FormManagements.Add(formManagement);
                 _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log it)
                throw new Exception("Error adding product", ex);
            }
            return formManagement;
        }   
    }
}
