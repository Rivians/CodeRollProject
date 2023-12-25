using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeRollProject.DtoLayer.Dtos
{
    public class CreateEventDto
    {
        public string eventName { get; set; }
        public string eventDescription { get; set; }
        public string eventPlatform { get; set; }
        public DateTime eventDateTime { get; set; }
    }
}
