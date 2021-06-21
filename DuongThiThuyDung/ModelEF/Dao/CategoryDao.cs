using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.Dao
{
	public class CategoryDao
	{
		private DuongThiThuyDungContext db;
		public CategoryDao()
		{
			db = new DuongThiThuyDungContext();
		}
		public List<Category> ListAll()
		{
			return db.Categorys.ToList();
		}
		//tim kiem
		public IEnumerable<Category> LisWheretAll(string keysearch, int page, int pagesize)
		{
			IQueryable<Category> model = db.Categorys;
			if (!string.IsNullOrEmpty(keysearch))
			{
				model = model.Where(x => x.Name.Contains(keysearch));
			}
			return model.OrderBy(x => x.Name).ToPagedList(page, pagesize);
		}

		public string Insert(Category enity)
		{
			db.Categorys.Add(enity);
			db.SaveChanges();
			return enity.CategoryID;
		}
		public bool Update(Category entity)
		{
			try
			{
				var cateID = Find(entity.CategoryID);
				if (!string.IsNullOrEmpty(entity.Name))
				{
					cateID.Name = entity.Name;
				}
				if (entity.CategoryID == null)
				{
					cateID.CategoryID = entity.CategoryID;
				}
				db.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}

		}
		public bool Delete(string id)
		{
			try
			{
				var result = db.Categorys.Where(x => x.CategoryID == id).SingleOrDefault();
				db.Categorys.Remove(result);
				db.SaveChanges();
				return true;
			}
			catch (Exception e)
			{
				return false;
			}
		}
		public Category Find(string CategoryID)
		{

			return db.Categorys.Where(x => x.CategoryID.Equals(CategoryID)).SingleOrDefault();
		}

	}
}
