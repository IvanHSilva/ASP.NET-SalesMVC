﻿using SalesMVC.Data;
using SalesMVC.Models;
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
    }
}
