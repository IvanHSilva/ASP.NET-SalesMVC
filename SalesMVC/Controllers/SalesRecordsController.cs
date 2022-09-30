using Microsoft.AspNetCore.Mvc;
using SalesMVC.Models;
using SalesMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesMVC.Controllers {
    public class SalesRecordsController : Controller {
        
        private readonly SalesRecordService _service;
        public SalesRecordsController(SalesRecordService service) {
            _service = service;
        }

        public IActionResult Index() {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate) {
            if (!minDate.HasValue) minDate = new DateTime(DateTime.Now.Year, 1, 1);
            if (!maxDate.HasValue) maxDate = DateTime.Now;
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            List<SalesRecord> result = await _service.FindByDateAsync(minDate, maxDate);
            return View(result);
        }

        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate) {
            if (!minDate.HasValue) minDate = new DateTime(DateTime.Now.Year, 1, 1);
            if (!maxDate.HasValue) maxDate = DateTime.Now;
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            List<IGrouping<Department, SalesRecord>> result = await _service.FindByDateGroupingAsync(minDate, maxDate);
            return View(result);
        }
    }
}
