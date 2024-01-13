using CodeRollProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeRollProject.BusinessLayer.Abstract
{
    public interface IVoteService : IGenericService<Vote>
    {
        public Vote TGetVoteByParticipantAndEventID(string participantName, int eventId);
    }
}
