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
        public string? EventName { get; set; }                
        public string? EventPlatform { get; set; }
        public string? EventDescription { get; set; }
        public DateTime? EventTime1 { get; set; }              // 1. opsiyon 
        public DateTime? EventTime2 { get; set; }              // 2. opsiyon
        public DateTime? EventTime3 { get; set; }              // 3. opsiyon
        public string? EventUrl { get; set; }
        public string? EventFullUrl { get; set; }


        public virtual List<Vote> Votes { get; set; }

        public int UserID { get; set; }   //foreign key 
        public virtual User User { get; set; }
    }
}
