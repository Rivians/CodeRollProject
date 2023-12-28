using CodeRollProject.EntityLayer.Concrete;

namespace CodeRollProject.PresentationLayer.Models
{
    public class UserEventVoteViewModel
    {
        public User _user { get; set; }
        public Event _event { get; set; }
        public Vote _vote { get; set; }
    }
}
