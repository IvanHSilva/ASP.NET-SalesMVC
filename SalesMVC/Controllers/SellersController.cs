using Microsoft.AspNetCore.Mvc;
using SalesMVC.Models;
using SalesMVC.Models.ViewModels;
using SalesMVC.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;

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
            if (id == null) return RedirectToAction(nameof(Error), new { message = "Id não fornecido!" });
            Seller seller = _service.FindById(id.Value);
            if (seller == null) return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            return View(seller);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id) {
            _service.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id) {
            if (id == null) return RedirectToAction(nameof(Error), new { message = "Id não fornecido!" });
            Seller seller = _service.FindById(id.Value);
            if (seller == null) return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            return View(seller);
        }

        public IActionResult Edit(int? id) {
            if (id == null) return RedirectToAction(nameof(Error), new { message = "Id não fornecido!" });
            Seller seller = _service.FindById(id.Value);
            if (seller == null) return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            List<Department> departments = _depService.FindAll();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller) {
            if (id != seller.Id) return RedirectToAction(nameof(Error), new { message = "Ids não correspondem!" });
            try {
                _service.Update(seller);
                return RedirectToAction(nameof(Index));
            } catch (ApplicationException e) {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(string message) {
            ErrorViewModel viewModel = new ErrorViewModel {
                Mesage = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
