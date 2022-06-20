using System;
using System.Collections.Generic;
using System.Text;
using OnlineShopAdmin.Domain.Contracts;

namespace OnlineShopAdmin.Domain.Contracts
{
    public interface IRepositoryWrapper
    {
        IProductRepository Product { get; }
        ICustomerRepository Customer { get; }

        ISalesOrderHeaderRepository SalesOrderHeader { get; }
        void Save();

    }
}
