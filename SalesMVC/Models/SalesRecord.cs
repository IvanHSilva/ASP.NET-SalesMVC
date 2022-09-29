using SalesMVC.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesMVC.Models {
    public class SalesRecord {
        public int Id { get; set; }
        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Display(Name = "Valor")]
        [DisplayFormat(DataFormatString = "{0:N}")]
        public double Amount { get; set; }
        [Display(Name = "Status")] 
        public SaleStatus Status { get; set; }
        [Display(Name = "Vendedor")] 
        public Seller Seller { get; set; }

        public SalesRecord() {}

        public SalesRecord(DateTime date, double amount, SaleStatus status, Seller seller) {
            //Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Seller = seller;
        }
    }
}
