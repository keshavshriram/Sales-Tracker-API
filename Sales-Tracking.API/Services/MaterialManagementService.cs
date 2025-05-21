using Sales_Tracking.API.Data;

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
    }
}
