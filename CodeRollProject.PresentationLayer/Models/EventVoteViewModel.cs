using CodeRollProject.EntityLayer.Concrete;

namespace CodeRollProject.PresentationLayer.Models
{
    public class EventVoteViewModel
    {
        public Event eventt { get; set; }
        public List<VoteOption> voteOptionn { get; set; }
    }
}
