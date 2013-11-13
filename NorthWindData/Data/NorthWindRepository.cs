using System.Collections.Generic;
using System.Linq;
using NorthWindData.Entities;

namespace NorthWindData.Data
{
    public class NorthWindRepository : IRepository
    {
        public NorthwindContext Context { get; private set; }
        public NorthWindRepository()
        {
            Context = new NorthwindContext();
        }

        public IEnumerable<Category> GetCategories(int catid)
        {
            return Context.Categories.Where(c => c.CategoryID == catid);
        }

        public IEnumerable<Product> GetProductsByCategory(int catid)
        {
            return Context.Products.Where(p => p.CategoryID == catid);
        }

        public IEnumerable<Order_Detail> GetOrdersByProduct(int proid)
        {
            return Context.Order_Details.Where(o => o.ProductID == proid);
        }

        public int GetQuantityByOrder(int ordnum, int proid)
        {
            var orderdetail = Context.Order_Details.FirstOrDefault(od => od.ProductID == proid && od.OrderID == ordnum);
            if (orderdetail != null)
            {
                return orderdetail.Quantity;
            }
            return -1;
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
        }
    }
}
