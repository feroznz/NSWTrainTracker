using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NSWTrainTracker.Models;
using NSWTrainTracker.Models.DAL;

namespace NSWTrainTracker.Controllers
{
    public class TrainTrackerController : ApiController
    {
        private ITrackWorkRepository _repository;
        public TrainTrackerController(ITrackWorkRepository repository)
        {
            _repository = repository;
            //_db = new TrainRequestClient(CityCircleFeedBase);
        }

        public IEnumerable<TrackWork> Get()
        {
            var test = _repository.Get();
            return _repository.Get();
        }

        //Maybe get it by name since its not stored in the database and don't have id coming from the
        // xml2 objects(TrackWork)
        public IHttpActionResult GetTrackWork(int id)
        {
            return null;
        }
    }
}
