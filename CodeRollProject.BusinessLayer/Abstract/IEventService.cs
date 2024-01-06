using CodeRollProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeRollProject.BusinessLayer.Abstract
{
    public interface IEventService : IGenericService<Event>
    {
        public string GenerateRandomUrl();
        public string GenerateFullUrl();  // controller ve action'ın da url içine katılması lazım
    }
}
