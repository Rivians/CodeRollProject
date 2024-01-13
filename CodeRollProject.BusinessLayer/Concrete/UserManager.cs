using CodeRollProject.BusinessLayer.Abstract;
using CodeRollProject.DataAccessLayer.Abstract;
using CodeRollProject.DataAccessLayer.Concrete;
using CodeRollProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeRollProject.BusinessLayer.Concrete
{
	public class UserManager : IUserService
	{
		IUserDal _userDal;
		public UserManager(IUserDal userDal)
		{
			_userDal = userDal;
		}




		public void TDelete(User user)
		{
			_userDal.Delete(user);
		}

		public User TGetByID(int id)
		{
			return _userDal.GetByID(id);
		}

		public List<User> TGetListAll()
		{
			return _userDal.GetListAll();
		}

		public List<User> TGetListAll(Expression<Func<User, bool>> filter)  //  daha sonra kullanılacak. ****************************
		{
			throw new NotImplementedException();
		}

        public User TGetUserByEmail(string email)
        {
            return _userDal.GetUserByEmail(email);
        }

        public void TInsert(User user)
		{
			_userDal.Insert(user);
		}

		public void TUpdate(User user)
		{
			_userDal.Update(user);
		}
	}
}
