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
    public class EfEventRepository : GenericRepository<Event>, IEventDal
    {
        private readonly Context context;

        public EfEventRepository(Context context)
        {
            this.context = context;
        }

        public Event GetEventById(int id)
        {
            return context.Events.Include(e => e.Votes).ThenInclude(e => e.VoteOptions).FirstOrDefault(e => e.EventID == id);
        }

        public List<Event> GetLast5EventByUserId(int userId)
        {
            return context.Events.Where(e => e.UserID == userId).OrderByDescending(e => e.EventID).Take(5).ToList();
        }
    }
}