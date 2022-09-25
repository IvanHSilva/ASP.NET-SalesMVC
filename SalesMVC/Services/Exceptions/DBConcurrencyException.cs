using System;

namespace SalesMVC.Services.Exceptions {
    public class DBConcurrencyException : ApplicationException {
        public DBConcurrencyException(string message) : base(message) { }
    }
}
