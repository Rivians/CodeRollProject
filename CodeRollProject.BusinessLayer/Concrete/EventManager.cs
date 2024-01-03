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
    public class EventManager : IEventService
    {
        IEventDal _eventDal;

        public EventManager(IEventDal eventDal)
        {
            _eventDal = eventDal;
        }



        public void TDelete(Event t)
        {
            _eventDal.Delete(t);
        }

        public Event TGetByID(int id)
        {
            return _eventDal.GetByID(id);
        }

        public List<Event> TGetListAll()
        {
            return _eventDal.GetListAll();
        }

        public List<Event> TGetListAll(Expression<Func<Event, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void TInsert(Event t)
        {
            _eventDal.Insert(t);
        }

        public void TUpdate(Event t)
        {
            _eventDal.Update(t);
        }
    }
}
