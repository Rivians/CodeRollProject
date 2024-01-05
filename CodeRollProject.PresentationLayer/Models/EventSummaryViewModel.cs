using CodeRollProject.EntityLayer.Concrete;

namespace CodeRollProject.PresentationLayer.Models
{
    public class EventSummaryViewModel
    {
        public List<User> Users { get; set; }
        public List<Vote> Votes { get; set; }
    }
}
