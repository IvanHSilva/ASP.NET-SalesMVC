using Microsoft.AspNetCore.Mvc;
using SalesMVC.Models;
using SalesMVC.Models.ViewModels;
using SalesMVC.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SalesMVC.Controllers {

    public class SellersController : Controller {

        private readonly SellerService _service;
        private readonly DepartmentService _depService;

        public SellersController(SellerService service, DepartmentService depService) {
            _service = service;
            _depService = depService;
        }

        public async Task<IActionResult> Index() {
            List<Seller> list = await _service.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create() {
            List<Department> departments = await _depService.FindAllAsync();
            SellerFormViewModel viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Seller seller) {
            if (!ModelState.IsValid) {
                List<Department> departments = await _depService.FindAllAsync();
                SellerFormViewModel viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            }
            await _service.InsertAsync(seller);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id) {
            if (id == null) return RedirectToAction(nameof(Error), new { message = "Id não fornecido!" });
            Seller seller = await _service.FindByIdAsync(id.Value);
            if (seller == null) return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            return View(seller);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id) {
            await _service.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id) {
            if (id == null) return RedirectToAction(nameof(Error), new { message = "Id não fornecido!" });
            Seller seller = await _service.FindByIdAsync(id.Value);
            if (seller == null) return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            return View(seller);
        }

        public async Task<IActionResult> Edit(int? id) {
            if (id == null) return RedirectToAction(nameof(Error), new { message = "Id não fornecido!" });
            Seller seller = await _service.FindByIdAsync(id.Value);
            if (seller == null) return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            List<Department> departments = await _depService.FindAllAsync();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Seller seller) {
            if (!ModelState.IsValid) {
                List<Department> departments = await _depService.FindAllAsync();
                SellerFormViewModel viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            }
            if (id != seller.Id) return RedirectToAction(nameof(Error), new { message = "Ids não correspondem!" });
            try {
                await _service.UpdateAsync(seller);
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
