using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPlanner.Data;
using TravelPlanner.Models;
using TravelPlannerAppProject.Models;

namespace TravelPlanner.Services
{
    public class ItineraryService
    {
        private readonly Guid _userID;

        public ItineraryService(Guid userID)
        {
            _userID = userID;
            
        }

        public bool CreateItinerary(ItineraryCreate model)
        {
            var entity =
                new Itinerary()
                {
                    OwnerID = _userID,
                    ActivityName = model.ActivityName,
                    ActivityDescription = model.ActivityDescription,
                    ActivityCost = model.ActivityCost,
                    ActivityDate = model.ActivityDate
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Itineraries.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public ItineraryDetail GetItineraryByID(int itineraryID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Itineraries
                        .Single(e => e.ItineraryID == itineraryID && e.OwnerID == _userID);
                return
                    new ItineraryDetail
                    {
                        ItineraryID = entity.ItineraryID,
                        Completed = entity.Completed,
                        ActivityName = entity.ActivityName,
                        ActivityDescription = entity.ActivityDescription,
                        ActivityCost = entity.ActivityCost,
                        ActivityDate = entity.ActivityDate
                    };
            }
        }

        public IEnumerable<ItineraryListItem> GetItineraries()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Itineraries
                        .Where(e => e.OwnerID == _userID)
                        .Select(
                            e =>
                                new ItineraryListItem
                                {
                                    ItineraryID = e.ItineraryID,
                                    ActivityName = e.ActivityName,
                                    Completed = e.Completed,
                                    ActivityDescription = e.ActivityDescription,
                                    ActivityCost = e.ActivityCost,
                                    ActivityDate = e.ActivityDate
                                }
                        );
                return query.ToArray();
            }
        }

        public bool UpdateItinerary(ItineraryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Itineraries
                        .Single(e => e.ItineraryID == model.ItineraryID && e.OwnerID == _userID);

                entity.ActivityName = model.ActivityName;
                entity.Completed = model.Completed;
                entity.ActivityDescription = model.ActivityDescription;
                entity.ActivityCost = model.ActivityCost;
                entity.ActivityDate = model.ActivityDate;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteItinerary(int itineraryID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Itineraries
                        .Single(e => e.ItineraryID == itineraryID && e.OwnerID == _userID);
                ctx.Itineraries.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
