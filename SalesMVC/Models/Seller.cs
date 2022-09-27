using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesMVC.Models {
    public class Seller {
        public int Id { get; set; }
        [Display(Name="Nome")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [StringLength(60, MinimumLength = 10, ErrorMessage = "{0} deve ter entre {2} a {1} caracteres")]
        public string Name { get; set; }
        [Display(Name = "E-Mail")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [EmailAddress(ErrorMessage = "Digite um e-mail válido!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Data Nascimento")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
        [Display(Name = "Salário-Base")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [Range(100.0, 10000.0, ErrorMessage = "{0} deve ser entre {1} a {2}")]
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
