using Microsoft.EntityFrameworkCore;
using Sales_Tracking.API.Data;
using Sales_Tracking.API.Models.Domains;
using System;

namespace Sales_Tracking.API.Services
{
    public class MaterialManagementService
    {
        private readonly TrackerDBContext _context;
        public MaterialManagementService(TrackerDBContext context)
        {
            // Constructor logic here
            _context = context;
        }

        public async Task<IEnumerable<MaterialManagement>> GetAllAsync()
        {
            return await _context.materialManagements.Where(s => !s.IsRecordDeleted).ToListAsync();
        }

        public async Task<MaterialManagement?> GetByIdAsync(int id)
        {
            return await _context.materialManagements.FindAsync(id);
        }

        public async Task<MaterialManagement> CreateAsync(MaterialManagement dto)
        {
            var entity = new MaterialManagement
            {
                productId = dto.productId,
                Action = dto.Action,
                Quantity = dto.Quantity,
                TotalAmount = dto.TotalAmount,
                perProductRate = dto.TotalAmount/ dto.Quantity,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.materialManagements.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<MaterialManagement?> UpdateAsync( MaterialManagement dto)
        {
            var entity = await _context.materialManagements.FindAsync(dto.Id);
            if (entity == null) return null;

            entity.Action = dto.Action;
            entity.Quantity = dto.Quantity;
            entity.TotalAmount = dto.TotalAmount;
            entity.perProductRate = dto.TotalAmount / dto.Quantity;
            entity.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.materialManagements.FindAsync(id);
            if (entity == null) return false;
            entity.IsRecordDeleted = true;
            _context.materialManagements.Update(entity);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
