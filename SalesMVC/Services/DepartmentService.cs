using SalesMVC.Data;
using SalesMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace SalesMVC.Services {
    public class DepartmentService {
        // DBContext dependency
        private readonly SalesMVCContext _context;

        // Constructor with dependency injection
        public DepartmentService(SalesMVCContext context) {
            _context = context;
        }

        // Methods
        public List<Department> FindAll() {
            return _context.Department.OrderBy(d => d.Name).ToList();
        }
    }
}
