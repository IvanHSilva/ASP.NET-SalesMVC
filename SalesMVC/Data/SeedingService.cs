using SalesMVC.Models;
using SalesMVC.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesMVC.Data {
    public class SeedingService {
        private SalesMVCContext _context;

        public SeedingService(SalesMVCContext context) {
            _context = context; 
        }

        public void Seed() {
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any()) {
                return; // DB já populado
            }
            
            Department dpt1 = new Department("Eletrônicos");
            Department dpt2 = new Department("Informática");
            Department dpt3 = new Department("Comics");
            Department dpt4 = new Department("Games");
            Department dpt5 = new Department("Brinquedo");
            Department dpt6 = new Department("Livros");

            Seller sl1 = new Seller("Alex Green", "alexgreen@gmail.com", DateTime.Parse("15/04/1982"), 5000.00, dpt1);
            Seller sl2 = new Seller("Mariah Yellow", "mariahyellow@gmail.com", DateTime.Parse("12/05/1978"), 300.00, dpt3);
            Seller sl3 = new Seller("Rust Red", "rustred@gmail.com", DateTime.Parse("01/08/1990"), 2300.00, dpt6);
            Seller sl4 = new Seller("Emilia Blue", "emiliablue@gmail.com", DateTime.Parse("31/12/1989"), 4100.00, dpt4);
            Seller sl5 = new Seller("George Orange", "georgeorange@gmail.com", DateTime.Parse("05/07/1975"), 1800.00, dpt2);
            Seller sl6 = new Seller("Mike Purple", "mikepurple@gmail.com", DateTime.Parse("25/01/2005"), 2100.00, dpt5);

            SalesRecord sr1 = new SalesRecord(DateTime.Parse("01/09/2022"), 11000.00, SaleStatus.Faturado, sl5);
            SalesRecord sr2 = new SalesRecord(DateTime.Parse("10/09/2002"), 14300.00, SaleStatus.Faturado, sl3);
            SalesRecord sr3 = new SalesRecord(DateTime.Parse("05/09/2022"), 10100.00, SaleStatus.Pendente, sl1);
            SalesRecord sr4 = new SalesRecord(DateTime.Parse("04/09/2022"), 8300.00, SaleStatus.Faturado, sl6);
            SalesRecord sr5 = new SalesRecord(DateTime.Parse("08/09/2022"), 4500.00, SaleStatus.Pendente, sl2);
            SalesRecord sr6 = new SalesRecord(DateTime.Parse("03/09/2022"), 7800.00, SaleStatus.Faturado, sl4);
            SalesRecord sr7 = new SalesRecord(DateTime.Parse("11/09/2022"), 20000.00, SaleStatus.Faturado, sl5);
            SalesRecord sr8 = new SalesRecord(DateTime.Parse("15/09/2002"), 8500.00, SaleStatus.Faturado, sl3);
            SalesRecord sr9 = new SalesRecord(DateTime.Parse("12/09/2022"), 9800.00, SaleStatus.Pendente, sl1);
            SalesRecord sr10 = new SalesRecord(DateTime.Parse("16/09/2022"), 12900.00, SaleStatus.Faturado, sl6);
            SalesRecord sr11 = new SalesRecord(DateTime.Parse("14/09/2022"), 7500.00, SaleStatus.Pendente, sl2);
            SalesRecord sr12 = new SalesRecord(DateTime.Parse("20/09/2022"), 6900.00, SaleStatus.Faturado, sl4);
            SalesRecord sr13 = new SalesRecord(DateTime.Parse("21/09/2022"), 9900.00, SaleStatus.Faturado, sl5);
            SalesRecord sr14 = new SalesRecord(DateTime.Parse("30/09/2002"), 18000.00, SaleStatus.Faturado, sl3);
            SalesRecord sr15 = new SalesRecord(DateTime.Parse("25/09/2022"), 14100.00, SaleStatus.Pendente, sl1);
            SalesRecord sr16 = new SalesRecord(DateTime.Parse("23/09/2022"), 18200.00, SaleStatus.Faturado, sl6);
            SalesRecord sr17 = new SalesRecord(DateTime.Parse("28/09/2022"), 14500.00, SaleStatus.Pendente, sl2);
            SalesRecord sr18 = new SalesRecord(DateTime.Parse("27/09/2022"), 17700.00, SaleStatus.Faturado, sl4);

            _context.Department.AddRange(dpt1, dpt2, dpt3, dpt4, dpt5, dpt6);
            _context.Seller.AddRange(sl1, sl2, sl3, sl4, sl5, sl6);
            _context.SalesRecord.AddRange(sr1, sr2, sr3, sr4, sr5, sr6, sr7, sr8, sr9,
                sr10, sr11, sr12, sr13, sr14, sr15, sr16, sr17, sr18);

            _context.SaveChanges();
        }
    }
}
