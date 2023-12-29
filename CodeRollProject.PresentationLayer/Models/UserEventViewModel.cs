using CodeRollProject.EntityLayer.Concrete;

namespace CodeRollProject.PresentationLayer.Models
{
    public class UserEventViewModel
    {
        public Event _Event { get; set; }
        public List<User> _User { get; set; }
    }
}
