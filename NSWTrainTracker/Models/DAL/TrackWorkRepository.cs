using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NSWTrainTracker.Models.DAL
{
    public class TrackWorkRepository:ITrackWorkRepository
    {
        private TrackWorkContext _db = new TrackWorkContext();

        public IEnumerable<TrackWork> Get()
        {
            return _db.Get();
        }

        public TrackWork GetById(int id)
        {
            return null;
        }

        public IEnumerable<TrackWork> GetTrackWorksByDate(DateTime date)
        {
            return null;
        }

    }
}