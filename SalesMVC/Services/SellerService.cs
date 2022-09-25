using Microsoft.EntityFrameworkCore;
using SalesMVC.Data;
using SalesMVC.Models;
using SalesMVC.Services.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace SalesMVC.Services {
    public class SellerService {
        // DBContext dependency
        private readonly SalesMVCContext _context;

        // Constructor with dependency injection
        public SellerService(SalesMVCContext context) {
            _context = context;
        }

        // Methods
        public List<Seller> FindAll() {
            return _context.Seller.ToList();
        }

        public void Insert(Seller seller) {
            _context.Add(seller);
            _context.SaveChanges();
        }

        public Seller FindById(int id) {
            return _context.Seller.Include(s => s.Department).FirstOrDefault(s => s.Id == id);
        }

        public void Remove(int id) {
            Seller seller = _context.Seller.Find(id);
            _context.Seller.Remove(seller);
            _context.SaveChanges();
        }

        public void Update(Seller seller) {
            if (!_context.Seller.Any(s => s.Id == seller.Id)) throw new NotFoundException("Id não encontrado!");
            try {
                _context.Update(seller);
                _context.SaveChanges();
            } catch (DbUpdateConcurrencyException e) {
                throw new DBConcurrencyException(e.Message);
            }
        }
    }
}
