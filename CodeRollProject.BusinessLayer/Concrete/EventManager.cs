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



        public string GenerateFullUrl()
        {
            string randomUrl = GenerateRandomUrl();
            string fullUrl = "CodeRoll/EventFinal/Index" + randomUrl;
            return fullUrl;
        }

        public string GenerateRandomUrl()
        {
            List<int> numbers = new List<int>()
            {
                0,1,2,3,4,5,6,7,8,9
            };

            List<char> characters = new List<char>()
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o',
                'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D',
                'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S',
                'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '-', '_', '?'
            };

            string randomURL = "";
            Random rand = new Random();

            for (int i = 0; i < 16; i++)
            {
                int random = rand.Next(0, 3);
                if (random == 1) // sayı kullan
                {
                    random = rand.Next(0,numbers.Count());
                    randomURL += numbers[random].ToString();
                }
                else // karakter kullan
                {
                    random = rand.Next(0,characters.Count());
                    randomURL += characters[random].ToString();
                }
            }

            return randomURL;
        }

        public void TDelete(Event t)
        {
            _eventDal.Delete(t);
        }

        public Event TGetByID(int id)
        {
            return _eventDal.GetByID(id);
        }

        public Event TGetEventById(int eventId)
        {
            return _eventDal.GetEventById(eventId);
        }

        public List<Event> TGetLast5EventByUserId(int userId)
        {
            return _eventDal.GetLast5EventByUserId(userId);
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
