using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPlanner.Models;

namespace TravelPlanner.Contracts
{
    //--MAKE THIS PUBLIC
    public interface IItineraryService
    {
        //--take method names from service class, remove 'public'

        bool CreateItinerary(ItineraryCreate model);
        ItineraryDetail GetItineraryByID(int itineraryID);
        IEnumerable<ItineraryListItem> GetItineraries();
        bool UpdateItinerary(ItineraryEdit model);
        bool DeleteItinerary(int itineraryID);

    }
}
