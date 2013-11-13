using System;
using System.Collections.Generic;

namespace NorthWindData.Entities
{
    interface IRepository : IDisposable
    {
        List<Category> GetCategories();
        List<Product> GetProductsByCategory(int catid);
        List<int> GetOrdersByProduct(int proid);
        int GetQuantityByOrder(int ordnum, int proid);
    }
}
