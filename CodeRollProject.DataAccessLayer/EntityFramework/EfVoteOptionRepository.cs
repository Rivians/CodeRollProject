using CodeRollProject.DataAccessLayer.Abstract;
using CodeRollProject.DataAccessLayer.Repositories;
using CodeRollProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeRollProject.DataAccessLayer.EntityFramework
{
    public class EfVoteOptionRepository : GenericRepository<VoteOption>, IVoteOptionDal
    {
    }
}
