using Microsoft.AspNetCore.Mvc;
using SalesMVC.Models;
using SalesMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesMVC.Controllers {
    
    public class SellersController : Controller {
        
        private readonly SellerService _service;

        public SellersController(SellerService service) {
            _service = service;
        }
        
        public IActionResult Index() {
            List<Seller> list = _service.FindAll();
            return View(list);
        }
    }
}
