using CodeRollProject.EntityLayer.Concrete;
using System.Text.Json.Serialization;

namespace CodeRollProject.PresentationLayer.Models
{
    public class UserEventViewModel
    {
        public Event _Event { get; set; }

        [JsonIgnore]
        public List<User> _User { get; set; }
    }
}
