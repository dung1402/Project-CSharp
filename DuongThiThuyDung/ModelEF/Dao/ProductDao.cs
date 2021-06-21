using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
	public class ProductDao
	{
		private DuongThiThuyDungContext db;
		public ProductDao()
		{
			db = new DuongThiThuyDungContext();
		}

		public List<Product> ListAll()
		{
			var result = from s in db.Products
						 orderby s.Quantity ascending, s.UnitCost descending
						 select s;
			return result.ToList();
		}
		//tim kiem
		public IEnumerable<Product> LisWheretAll(string keysearch, int page, int pagesize)
		{
			IQueryable<Product> model = db.Products;
			if (!string.IsNullOrEmpty(keysearch))
			{
				model = model.Where(x => x.Name.Contains(keysearch));
			}
			return model.OrderBy(x => x.Name).ToPagedList(page, pagesize);
		}
		public string Insert(Product enity)
		{
			db.Products.Add(enity);
			db.SaveChanges();
			return enity.ID.ToString();
		}
		public bool Update(Product entityProduct)
		{
			try
			{
				var product = Find(entityProduct.ID);
				product.Name = entityProduct.Name;
				product.UnitCost = entityProduct.UnitCost;
				product.Quantity = entityProduct.Quantity;
				product.CategoryID = entityProduct.CategoryID;

				db.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}

		}
		//public bool Delete(string Id_Product)
		//{
		//    try
		//    {
		//        Product product = db.Products.Find(Id_Product);
		//        db.Products.Remove(product);
		//        db.SaveChanges();
		//        return true;
		//    }
		//    catch (Exception e)
		//    {
		//        return false;
		//    }

		//}
		public bool Delete(int id)
		{
			try
			{
				var dao = db.Products.Find(id);
				db.Products.Remove(dao);
				db.SaveChanges();
				return true;
			}
			catch (Exception e)
			{
				return false;
			}
		}
		public Product Find(int id)
		{

			return db.Products.Find(id);
		}

	}
}
