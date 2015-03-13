using System.Collections.Generic;
using NSWTrainTracker.Models;
using NSWTrainTracker.Models.DAL;

namespace NSWTrainTracker.Controllers
{
    public class TrainTrackerController : BaseApiController
    {
        public TrainTrackerController(ITrackWorkRepository repo)
            : base(repo)
        {
        }

        public IEnumerable<TrackWork> Get()
        {
            return TheRepository.Get();
        }

        //Maybe get it by name since its not stored in the database and don't have id coming from the
        // xml2 objects(TrackWork)
        //public IHttpActionResult GetTrackWork(int id)
        //{
        //    return null;
        //}
    }
}
