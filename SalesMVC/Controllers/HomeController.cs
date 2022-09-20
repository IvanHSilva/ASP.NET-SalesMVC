using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalesMVC.Models;
using SalesMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SalesMVC.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
            //List<Department> departments = new List<Department>();
            //departments.Add(new Department(1, "Eletrônicos"));
            //departments.Add(new Department(2, "Games"));
            //departments.Add(new Department(3, "Livros"));
            //departments.Add(new Department(4, "Moda"));
            //departments.Add(new Department(5, "Ifantil"));

            //return View(departments);
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
