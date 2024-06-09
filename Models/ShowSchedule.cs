using WSBF.Web.Data.Entities;

namespace WSBF.Web.Models
{
    public class ShowSchedule
    {
        public ShowSchedule(IEnumerable<Show> showList, string currday)
        {
            this.ShowList = new List<Show>();

            foreach (var s in showList)
            {
                if (s.day == currday) { this.ShowList.Add(s); }
            }
        }

        public List<Show> ShowList { get; set; }
    }
}
