using CodeRollProject.DataAccessLayer.Abstract;
using CodeRollProject.DataAccessLayer.Concrete;
using CodeRollProject.DataAccessLayer.Repositories;
using CodeRollProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeRollProject.DataAccessLayer.EntityFramework
{
    public class EfVoteRepository : GenericRepository<Vote>, IVoteDal
    {
        private readonly Context context;
        public EfVoteRepository(Context context)
        {
            this.context = context;
        }

        public Vote GetVoteWithParticipantAndEventID(string participantName, int eventId)
        {
            return context.Votes.Include(v => v.VoteOptions).FirstOrDefault(v => v.ParticipantName == participantName && v.EventID == eventId);
        }
    }
}
