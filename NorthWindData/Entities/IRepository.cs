using System;
using System.Collections.Generic;

namespace NorthWindData.Entities
{
    interface IRepository : IDisposable
    {
        IEnumerable<Category> GetCategories(int catid);
        IEnumerable<Product> GetProductsByCategory(int catid);
        IEnumerable<Order_Detail> GetOrdersByProduct(int proid);
        int GetQuantityByOrder(int ordnum, int proid);
    }
}
