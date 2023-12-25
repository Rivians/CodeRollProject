using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeRollProject.EntityLayer.Concrete
{
	public class Vote
	{
		[Key]
        public int VoteID { get; set; }
        public int EventID { get; set; }
        public int UserID { get; set; }
        public string SelectedOption { get; set; }



		// ilişkiler   ?????????????????????????????????????????????????????
		//public Event Event { get; set; }
		//public User User { get; set; }
		//public Participant Participant { get; set; }
    }
}
