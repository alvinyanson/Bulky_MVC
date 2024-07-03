using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;

namespace Bulky.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {

        private ApplicationDBContext _db;

        public ProductRepository(ApplicationDBContext db): base(db)
        {
            _db = db;
        }

        public void Update(Product obj)
        {
            //_db.Products.Update(obj);

            var objFromDB = _db.Products.FirstOrDefault(u => u.Id == obj.Id);

            if (objFromDB != null) 
            { 
                objFromDB.Title = obj.Title;
                objFromDB.ISBN = obj.ISBN;
                objFromDB.Price = obj.Price;
                objFromDB.ListPrice = obj.ListPrice;
                objFromDB.Price50 = obj.Price50;
                objFromDB.Price100 = obj.Price100;
                objFromDB.Description = obj.Description;
                objFromDB.CategoryId = obj.CategoryId;
                objFromDB.Author = obj.Author;

                if (obj.ImageUrl != null) 
                {
                    objFromDB.ImageUrl = obj.ImageUrl;
                }

            }
        }
    }
}
