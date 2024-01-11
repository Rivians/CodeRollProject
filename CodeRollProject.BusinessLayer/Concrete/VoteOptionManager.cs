using CodeRollProject.BusinessLayer.Abstract;
using CodeRollProject.DataAccessLayer.Abstract;
using CodeRollProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeRollProject.BusinessLayer.Concrete
{
    public class VoteOptionManager : IVoteOptionService
    {
        IVoteOptionDal _voteOptionDal;
        public VoteOptionManager(IVoteOptionDal voteOptionDal)
        {
            _voteOptionDal = voteOptionDal;
        }



        public void TDelete(VoteOption t)
        {
            _voteOptionDal.Delete(t);
        }

        public VoteOption TGetByID(int id)
        {
            return _voteOptionDal.GetByID(id);
        }

        public List<VoteOption> TGetListAll()
        {
            return _voteOptionDal.GetListAll();
        }

        public List<VoteOption> TGetListAll(Expression<Func<VoteOption, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void TInsert(VoteOption t)
        {
            _voteOptionDal.Insert(t);
        }

        public void TUpdate(VoteOption t)
        {
            _voteOptionDal.Update(t);
        }
    }
}
