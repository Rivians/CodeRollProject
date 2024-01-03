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
    public class EventUserManager : IEventUserService
    {
        IEventUserDal _eventUserDal;

        public EventUserManager(IEventUserDal eventUserDal)
        {
            _eventUserDal = eventUserDal;
        }



        public void TDelete(EventUser t)
        {
            _eventUserDal.Delete(t);
        }

        public EventUser TGetByID(int id)
        {
            return _eventUserDal.GetByID(id);
        }

        public List<EventUser> TGetListAll()
        {
            return _eventUserDal.GetListAll();
        }

        public List<EventUser> TGetListAll(Expression<Func<EventUser, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void TInsert(EventUser t)
        {
            _eventUserDal.Insert(t);
        }

        public void TUpdate(EventUser t)
        {
            _eventUserDal.Update(t);
        }
    }
}
