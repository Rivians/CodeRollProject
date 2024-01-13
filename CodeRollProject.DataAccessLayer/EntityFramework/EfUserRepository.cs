using CodeRollProject.DataAccessLayer.Abstract;
using CodeRollProject.DataAccessLayer.Concrete;
using CodeRollProject.DataAccessLayer.Repositories;
using CodeRollProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeRollProject.DataAccessLayer.EntityFramework
{
    public class EfUserRepository : GenericRepository<User>, IUserDal
    {
        private readonly Context context;
        public EfUserRepository(Context context)
        {
            this.context = context;
        }

        public User GetUserByEmail(string email)
        {
            return context.Users.FirstOrDefault(u => u.Email == email);
        }
    }
}
