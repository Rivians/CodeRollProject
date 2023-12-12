using CodeRollProject.DataAccessLayer.Abstract;
using CodeRollProject.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeRollProject.DataAccessLayer.Repositories
{
	public class GenericRepository<T> : IGenericDal<T> where T : class
	{
		public void Delete(T t)
		{
			using var context = new Context();
			context.Set<T>().Remove(t);
			context.SaveChanges();

		}

		public T GetByID(int id)
		{
			using var context = new Context();
			return context.Set<T>().Find(id);
			
		}

		public List<T> GetListAll()
		{
			using var context = new Context();
			return context.Set<T>().ToList();
			
		}

		public List<T> GetListAll(Expression<Func<T, bool>> filter)  //  daha sonra kullanılacak. ****************************
		{
			throw new NotImplementedException();
		}

		public void Insert(T t)
		{
			using var context = new Context();
			context.Set<T>().Add(t);
			context.SaveChanges();	
		}

		public void Update(T t)
		{
			using var context = new Context();
			context.Set<T>().Update(t);
			context.SaveChanges();
		}
	}
}
