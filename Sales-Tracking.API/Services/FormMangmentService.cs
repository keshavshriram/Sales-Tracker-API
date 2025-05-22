using Microsoft.EntityFrameworkCore;
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

        public async Task<FormManagement> GetProductById(int id)
        {
            try
            {
                return await _context.FormManagements.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting product for Id : " + id);
            }
        }
        
        public async Task<List<FormManagement>> GetProductList()
        {
            try
            {
                return await _context.FormManagements.Where(s => !s.IsRecordDeleted).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting product list.");
            }
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

        public async Task<FormManagement> UpdateProduct(FormManagement formManagement)
        {
            try
            {
                var existingProduct = await _context.FormManagements.FindAsync(formManagement.productId);
                if (existingProduct == null)
                {
                    throw new Exception("Product not found");
                }
                existingProduct.ProductName = formManagement.ProductName;
                existingProduct.UnitOfMeasure = formManagement.UnitOfMeasure;
                _context.FormManagements.Update(existingProduct);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log it)
                throw new Exception("Error adding product", ex);
            }
            return formManagement;
        }

        public async Task<bool> RemoveProduct(FormManagement formManagement)
        {
            try
            {
                var existingProduct = await _context.FormManagements.FindAsync(formManagement.productId);
                if (existingProduct == null)
                {
                    throw new Exception("Product not found");
                }
                existingProduct.IsRecordDeleted = true;
                _context.FormManagements.Update(existingProduct);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log it)
                throw new Exception("Error adding product", ex);
            }
            return true;
        }


    }
}
