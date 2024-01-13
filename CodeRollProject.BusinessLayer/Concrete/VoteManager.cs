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
    public class VoteManager : IVoteService
    {
        IVoteDal _voteDal;
        public VoteManager(IVoteDal voteDal)
        {
            _voteDal = voteDal;
        }




        public void TDelete(Vote t)
        {
            _voteDal.Delete(t);
        }

        public Vote TGetByID(int id)
        {
            return _voteDal.GetByID(id);    
        }

        public List<Vote> TGetListAll()
        {
            return _voteDal.GetListAll();
        }

        public List<Vote> TGetListAll(Expression<Func<Vote, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Vote TGetVoteByParticipantAndEventID(string participantName, int eventId)
        {
            return _voteDal.GetVoteByParticipantAndEventID(participantName, eventId);
        }

        public void TInsert(Vote t)
        {
            _voteDal.Insert(t);
        }

        public void TUpdate(Vote t)
        {
            _voteDal.Update(t);
        }
    }
}
