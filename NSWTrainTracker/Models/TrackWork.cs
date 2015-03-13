using System;

namespace NSWTrainTracker.Models
{
    public class TrackWork
    {
        public string Title { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public string Link { get; set; }
        public string Description { get; set; }
        public string PubDate { get; set; }
        public DateTime DcDate { get; set; }
    }
}
