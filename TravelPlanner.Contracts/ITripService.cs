using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPlanner.Data;
using TravelPlanner.Models;

namespace TravelPlanner.Contracts
{
    public interface ITripService
    {
        bool CreateTrip(TripCreate model);
        TripDetail GetTripById(int tripID);
        IEnumerable<TripListItem> GetTrips();
        bool UpdateTrip(TripEdit model);
        bool DeleteTrip(int tripID);
    }
}
