using CodeRollProject.EntityLayer.Concrete;

namespace CodeRollProject.PresentationLayer.Models
{
    public class EventVoteViewModel
    {
        public Event eventt { get; set; }
        public List<Vote> votee { get; set; }
    }
}
