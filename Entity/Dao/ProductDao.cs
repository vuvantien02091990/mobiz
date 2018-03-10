using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model;

namespace Model.Dao
{
    public class ProductDao
    {
        private MobiZContext db = new MobiZContext();
        // GET: Product
 
        public List<Product> ListNewProduct(int top)
        {
            return db.Products.OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }
        public List<Product> ListFeatureProduct(int top)
        {
            return db.Products.Where(x => x.Price != null).OrderByDescending(x => x.Price).Take(top).ToList();
        }
        public List<Product> ListCategoryProduct(long catId,int top)
        {
            return db.Products.Where(x => x.CategoryID == catId).Take(top).ToList();
        }
    }
}
