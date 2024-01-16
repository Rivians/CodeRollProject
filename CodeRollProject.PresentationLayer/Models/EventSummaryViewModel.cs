using CodeRollProject.EntityLayer.Concrete;

namespace CodeRollProject.PresentationLayer.Models
{
    public class EventSummaryViewModel
    {
        public Event eventt { get; set; } 
        public List<Vote> votess { get; set; }
        public int vote1Count { get; set; }
        public int vote2Count { get; set; }
        public int vote3Count { get; set; }
    }
}
