using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesMVC.Models {
    public class Seller {
        public int Id { get; set; }
        [Display(Name="Nome")]
        public string Name { get; set; }
        [Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Data Nascimento")]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
        [Display(Name = "Salário-Base")]
        //[DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N}")]
        public double BaseSalary { get; set; }
        [Display(Name = "Departamento")]
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller() {}

        public Seller(string name, string email, DateTime birthdate, double baseSalary, Department department) {
            //Id = id;
            Name = name;
            Email = email;
            Birthdate = birthdate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sales) {
            Sales.Add(sales);
        }

        public void RemoveSales(SalesRecord sales) {
            Sales.Remove(sales);
        }

        public double TotalSales(DateTime initial, DateTime final) {
            return Sales.Where(sales => sales.Date >= initial && sales.Date <= final).Sum(sales => sales.Amount);
        }
    }
}
