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
        public string? VoteOption { get; set; }


        public int? EventID { get; set; }
        //public Event Event { get; set; }


        public int? UserID { get; set; }
        //public User User { get; set; }
    }
}
