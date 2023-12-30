using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeRollProject.EntityLayer.Concrete
{
	public class Event
	{
		[Key]
        public int EventID { get; set; }
        public string? EventName { get; set; }                /* */
        public string? EventTitle { get; set; }
        public string? EventDescription { get; set; }         /* */
        public string? EventPlatform { get; set; }            /* */
        public DateTime? EventTime { get; set; }              /* */
        public int? EventCreatorID { get; set; }     


        public List<User> Users { get; set; }
        //public List<Vote> Votes { get; set; }
    }
}
