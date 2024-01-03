using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeRollProject.EntityLayer.Concrete
{
    public class EventUser
    {
        public int EventUserID { get; set; }
        public int UserID { get; set; }
        public int EventID { get; set; }


        public User User { get; set; }
        public Event Event { get; set; }
    }
}
