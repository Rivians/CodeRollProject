using CodeRollProject.EntityLayer.Concrete;

namespace CodeRollProject.PresentationLayer.Models
{
    public class EventVoteViewModel
    {
        public Event eventt { get; set; }   // event bilgilerini çekiyoruz  --  başarılı
        public string participantName { get; set; }  // oy veren kişinin adını asp for ile yakalamak için  --  başarılı
        public List<string> SelectedOption { get; set; }  // name parametresi ile seçilen oyun değerini yani tarihini tutuyoruz  --  başarılı
    }
}
