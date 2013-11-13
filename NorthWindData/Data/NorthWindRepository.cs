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

        public List<Category> GetCategories()
        {
            //return Context.Categories.Where(c => c.CategoryID == catid);
            return Context.Categories.ToList();
        }

        public List<Product> GetProductsByCategory(int catid)
        {
            return Context.Products.Where(p => p.CategoryID == catid).ToList();
        }

        public List<int> GetOrdersByProduct(int proid)
        {
            return Context.Order_Details.Where(o => o.ProductID == proid)
                .Select(od => od.ProductID).ToList();

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
