using Microsoft.EntityFrameworkCore;
using SalesMVC.Data;
using SalesMVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesMVC.Services {
    public class DepartmentService {
        // DBContext dependency
        private readonly SalesMVCContext _context;

        // Constructor with dependency injection
        public DepartmentService(SalesMVCContext context) {
            _context = context;
        }

        // Methods
        public async Task<List<Department>> FindAllAsync() {
            return await _context.Department.OrderBy(d => d.Name).ToListAsync();
        }
    }
}
