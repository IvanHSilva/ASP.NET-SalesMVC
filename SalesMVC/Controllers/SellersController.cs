using Microsoft.AspNetCore.Mvc;
using SalesMVC.Models;
using SalesMVC.Services;
using System.Collections.Generic;

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

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller) {
            _service.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
