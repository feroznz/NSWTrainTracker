using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace NSWTrainTracker.Models.DAL
{
    /// <summary>
    /// TODO: This will need to be fixed so that all data comes from database but problem( feed is REAL-TIME : maybe look at SignalR/Katana later) ?
    /// Mock a data store:
    /// TODO: The base URL should come from the configuration files.
    ///TODO: we will have to store the xml2object into database,SQL sor for this case.
    /// </summary>
    public class TrackWorkContext
    {
        private const string HostUri = @"http://www.sydneytrains.info/rss/feeds/trackwork.xml";

        public IEnumerable<TrackWork> Get()
        {
            var xmlDoc = MakeRequest(HostUri);
            if (xmlDoc == null) return null;

            //Check if its good service.
            //var check = xmlDoc.Descendants("item").Where(e => e.Element("title").Value.StartsWith("Good"));
            var items = (from c in xmlDoc.Descendants("item")
                         select
                             new TrackWork
                             {
                                 Title = GetTitle(c.Element("title")),
                                 StartDate = GetDates(c.Element("title"))[0].ToString("f"),
                                 EndDate = GetDates(c.Element("title"))[1].ToString("f"),
                                 Link = (string)c.Element("link"),
                                 Description = (string)c.Element("description"),
                                 PubDate = (string)c.Element("pubDate")
                             }).ToList();
            return items;
        }


        // Submit the HTTP Request and return the XML response
        private static XDocument MakeRequest(string requestUrl)
        {
            try
            {
                var request = WebRequest.Create(requestUrl) as HttpWebRequest;
                if (request == null) return null;
                var response = request.GetResponse() as HttpWebResponse;

                if (response == null) return null;
                var xmlDoc = XDocument.Load(response.GetResponseStream());
                return (xmlDoc);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " . Trace : " + e.StackTrace);
                return null;
            }
        }

        #region Helper private Methods

        private static string GetTitle(XElement fullTitle)
        {
            var dates = fullTitle.Value.Split('-');
            return dates[0].TrimEnd();
        }

        private static List<DateTime> GetDates(XElement fullDate)
        {
            var datesGoodService = new List<DateTime>();
            var dates = fullDate.Value.Split('-');

            // if the service is good then return blank dates.
            if (fullDate.Value.StartsWith("Good"))
            {
                datesGoodService.Add(DateTime.MinValue);
                datesGoodService.Add(DateTime.MinValue);

                return datesGoodService;
            }

            var actualDates = dates[1];
            string[] stringSeparators = { "to" };
            var results = actualDates.Split(stringSeparators, StringSplitOptions.None);
            return results.Select(item => item != null ? FormatDate(item) : new DateTime()).ToList();
        }

        // converts string to DatetTime;
        private static DateTime FormatDate(string dateToConvert)
        {
            if (string.IsNullOrEmpty(dateToConvert)) return DateTime.MinValue;
            DateTime date;
            DateTime.TryParse(dateToConvert, out date);

            return date;
        }

        private DateTime FormatDate(XElement dateToParse)
        {
            if (dateToParse == null) return DateTime.MinValue;

            CultureInfo provider = CultureInfo.InvariantCulture;
            const string format = "ddd dd MMM yyyy h:mm";
            var date = DateTime.ParseExact(dateToParse.Value, format, provider);

            return date;
        }

        #endregion

    }
}