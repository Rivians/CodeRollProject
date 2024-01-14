using CodeRollProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeRollProject.DataAccessLayer.Abstract
{
    public interface IEventDal : IGenericDal<Event>
    { 
        public Event GetEventById(int id);
        public List<Event> GetLast5EventByUserId(int userId);
    }
}
