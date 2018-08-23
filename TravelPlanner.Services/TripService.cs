using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPlanner.Contracts;
using TravelPlanner.Data;
using TravelPlanner.Models;
using TravelPlannerAppProject.Models;

namespace TravelPlanner.Services
{
    public class TripService : ITripService
    {
        private readonly Guid _userID;

        public TripService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateTrip(TripCreate model)
        {
            var entity =
                new Trip()
                {
                    OwnerID = _userID,
                    TripName = model.TripName,
                    DepartDate = model.DepartDate,
                    ReturnDate = model.ReturnDate
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Trips.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public TripDetail GetTripById(int tripID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Trips
                        .Single(e => e.TripID == tripID && e.OwnerID == _userID);
                return
                    new TripDetail
                    {
                        TripID = entity.TripID,
                        TripName = entity.TripName,
                        DepartDate = entity.DepartDate,
                        ReturnDate = entity.ReturnDate
                    };
            }
        }

        public IEnumerable<TripListItem> GetTrips()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Trips
                        .Where(e => e.OwnerID == _userID)
                        .Select(
                            e =>
                                new TripListItem
                                {
                                    TripID = e.TripID,
                                    TripName = e.TripName,
                                    DepartDate = e.DepartDate,
                                    ReturnDate = e.ReturnDate
                                }
                        );
                return query.ToArray();
            }
        }

        public bool UpdateTrip(TripEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Trips
                        .Single(e => e.TripID == model.TripID && e.OwnerID == _userID);
                entity.TripName = model.TripName;
                entity.DepartDate = model.DepartDate;
                entity.ReturnDate = model.Returndate;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTrip(int tripID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Trips
                    .Single(e => e.TripID == tripID && e.OwnerID == _userID);
                ctx.Trips.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
