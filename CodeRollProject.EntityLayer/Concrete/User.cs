using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeRollProject.EntityLayer.Concrete
{
	public class User
	{
		[Key]
        public int UserID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public int? EventID { get; set; }


        //// ilişkiler 
        public List<Event> Events { get; set; }
        //public List<Vote> Vote { get; set; }
    }
}
