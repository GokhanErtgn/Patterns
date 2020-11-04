using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            GermanyReservation germanyReservation = new GermanyReservation();
            BelgiumReservation belgiumReservation = new BelgiumReservation();
            TurkeyReservation turkeyReservation = new TurkeyReservation();

            germanyReservation.NextClass = belgiumReservation;
            belgiumReservation.NextClass = turkeyReservation;

            germanyReservation.SuitableHalls(new SearchFilter { ParticipantCount = 15, Country = "Türkiye" });
            Console.ReadLine();

        }

        
    }

    public class SearchFilter
    {
        public string Country { get; set; }
        public string City { get; set; }
        public int ParticipantCount { get; set; }
        public DateTime RequestDate { get; set; }
    }

    public abstract class MeetingRoomReservation
    {
        public MeetingRoomReservation NextClass { get; set; }

        private EventHandler<SearchFilter> _searchFilter;

        protected abstract void Search(object sender, SearchFilter searchFilter);

        public MeetingRoomReservation()
        {
            _searchFilter += Search;
        }

        public void SuitableHalls(SearchFilter searchFilter)
        {
            _searchFilter(this, searchFilter);
        }

    }

    public class GermanyReservation : MeetingRoomReservation
    {
        protected override void Search(object sender, SearchFilter searchFilter)
        {
            if (searchFilter.Country=="Almanya")
            {
                Console.WriteLine("Almanya için uygun salonlar aranıyor.");
            }
            else
            {
                NextClass?.SuitableHalls(searchFilter);
            }
        }
    }
    public class BelgiumReservation : MeetingRoomReservation
    {
        protected override void Search(object sender, SearchFilter searchFilter)
        {
            if (searchFilter.Country == "Belçika")
            {
                Console.WriteLine("Belçika için uygun salonlar aranıyor.");
            }
            else
            {
                NextClass?.SuitableHalls(searchFilter);
            }
        }
    }

    public class TurkeyReservation : MeetingRoomReservation
    {
        protected override void Search(object sender, SearchFilter searchFilter)
        {
            if (searchFilter.Country == "Türkiye")
            {
                Console.WriteLine("Türkiye için uygun salonlar aranıyor.");
            }
        }
    }
}
