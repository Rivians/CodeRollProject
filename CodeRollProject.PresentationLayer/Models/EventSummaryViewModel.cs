using CodeRollProject.EntityLayer.Concrete;

namespace CodeRollProject.PresentationLayer.Models
{
    public class EventSummaryViewModel
    {
        public Event eventt { get; set; } 
        public List<Vote> votess { get; set; }
    }
}
