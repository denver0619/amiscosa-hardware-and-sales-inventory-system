﻿using amiscosa_hardware_and_sales_inventory_system.Domain.Entities;

namespace amiscosa_hardware_and_sales_inventory_system.Domain.Repositories
{
    public interface ITransactionDetailRepository
    {
        public void AddTransactionDetail(TransactionDetail transactionDetail);
        public List<TransactionDetail> GetAllTransactionDetailByTransactionID (string transactionID);
        public List<TransactionDetail> GetAllTransactionsByProductID(string productID);
    }
}
