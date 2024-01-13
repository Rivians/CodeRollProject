using CodeRollProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeRollProject.DataAccessLayer.Abstract
{
	public interface IUserDal : IGenericDal<User>
	{
		User GetUserByEmail(string email);
	}
}
