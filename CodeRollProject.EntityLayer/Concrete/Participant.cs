using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeRollProject.EntityLayer.Concrete
{
	public class Participant
	{
		[Key]
		public int ParticipantID { get; set; }
        public int UserID { get; set; }
        public int EventID { get; set; }



        //// ilişkiler 
        //public List<Event> Events { get; set; }
        //public User User { get; set; }
        //public Vote Vote { get; set; }
    }
}
