using Microsoft.AspNetCore.Mvc;
using SalesMVC.Models;
using SalesMVC.Models.ViewModels;
using SalesMVC.Services;
using System.Collections.Generic;

namespace SalesMVC.Controllers {

    public class SellersController : Controller {

        private readonly SellerService _service;
        private readonly DepartmentService _depService;

        public SellersController(SellerService service, DepartmentService depService) {
            _service = service;
            _depService = depService;
        }

        public IActionResult Index() {
            List<Seller> list = _service.FindAll();
            return View(list);
        }

        public IActionResult Create() {
            List<Department> departments = _depService.FindAll();
            SellerFormViewModel viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller) {
            _service.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id) {
            if (id == null) return NotFound();
            Seller seller = _service.FindById(id.Value);
            if (seller == null) return NotFound();  
            return View(seller);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id) {
            _service.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id) {
            if (id == null) return NotFound();
            Seller seller = _service.FindById(id.Value);
            if (seller == null) return NotFound();
            return View(seller);
        }

    }
}
