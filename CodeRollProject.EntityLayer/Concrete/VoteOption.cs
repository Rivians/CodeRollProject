using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeRollProject.EntityLayer.Concrete
{
    public class VoteOption
    {
        public int VoteOptionID { get; set; }
        public string? VoteValue { get; set; }
        public bool? IsSelected { get; set; }


        public int VoteID { get; set; }
        public Vote Vote { get; set; }
    }
}
