using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.Dao
{
	public class UserAccountDao
	{
			private DuongThiThuyDungContext db;
			public UserAccountDao()
			{
				db = new DuongThiThuyDungContext();
			}
			public int Login(string tk, string mk)
			{
				var result = db.UserAccounts.SingleOrDefault(x => x.UserName.Contains(tk) && x.Password.Contains(mk));
				if (result == null)
				{
					return 0;
				}
				else
					return 1;
			}
			//Thêm
			public string Insert(UserAccount entitydangnhap)
			{
				var id = Find(entitydangnhap.UserName);
				if (id == null)
				{
					db.UserAccounts.Add(entitydangnhap);
				}
				else
				{
					id.UserName = entitydangnhap.UserName;
					if (!String.IsNullOrEmpty(entitydangnhap.Password))
					{
						id.Password = entitydangnhap.Password;
					}
				}

				db.SaveChanges();
				return entitydangnhap.Password;
			}
			//code xóa
			public bool delete(int id)
			{
				try
				{
					var user = db.UserAccounts.Find(id);
					db.UserAccounts.Remove(user);
					db.SaveChanges();
					return true;
				}
				catch (Exception)
				{
					return false;
				}
			}
			//tạo hàm kiểm tra xem trùng tên không
			public UserAccount Find(string name)
			{
				return db.UserAccounts.Find(name);
			}
			public List<UserAccount> ListAll()
			{
				return db.UserAccounts.ToList();
			}
			public IEnumerable<UserAccount> ListWhereAll(string keysearch, int page, int pagesize)
			{
				IQueryable<UserAccount> model = db.UserAccounts;
				if (!string.IsNullOrEmpty(keysearch))
				{
					model = model.Where(x => x.UserName.Contains(keysearch));
				}
				return model.OrderBy(x => x.UserName).ToPagedList(page, pagesize);
			}
		}
	}

