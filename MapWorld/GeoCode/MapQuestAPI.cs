using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TicketService.GeoCode
{
    public class MapQuestAPI
    {
        private string _key = "";
        private const string urltemplategeocodestreet = "http://www.mapquestapi.com/geocoding/v1/address?key={0}&street={1}&city={2}&state={3}&postalCode={4}";
        private const string urltemplategeocodelocation = "http://www.mapquestapi.com/geocoding/v1/address?key={0}&location={1}";

        private const string hostgeocode = "www.mapquestapi.com";

        public MapQuestAPI(string Key)
        {
            _key = Key;
        }

        public GeocodeLatLng GetLatLng(string location)
        {
            string url = string.Format(urltemplategeocodelocation, _key, location);
            string pagebody = "";
            GetWebPage(url, hostgeocode, ref pagebody);

            GeocodeResponse g = Newtonsoft.Json.JsonConvert.DeserializeObject<GeocodeResponse>(pagebody);

            GeocodeLatLng latlng = new GeocodeLatLng();
            if (g != null
                && g.results != null
                && g.results.Length > 0
                && g.results[0].locations != null
                && g.results[0].locations.Length > 0
                && g.results[0].locations[0].latLng != null)
            {
                latlng = g.results[0].locations[0].latLng;
            }

            return latlng;
        }

        public GeocodeLatLng GetLatLng(string street, string city, string state, string postalCode)
        {
            string url = string.Format(urltemplategeocodestreet, _key, street, city, state, postalCode);
            string pagebody = "";
            GetWebPage(url, hostgeocode, ref pagebody);

            GeocodeResponse g = Newtonsoft.Json.JsonConvert.DeserializeObject<GeocodeResponse>(pagebody);

            GeocodeLatLng latlng = new GeocodeLatLng();
            if (g != null
                && g.results != null
                && g.results.Length > 0
                && g.results[0].locations != null
                && g.results[0].locations.Length > 0
                && g.results[0].locations[0].latLng != null)
            {
                latlng = g.results[0].locations[0].latLng;
            }

            return latlng;
        }

        public class GeocodeResponse
        {
            public GeocodeResult[] results { get; set; }
        }

        public class GeocodeResult
        {
            public GeocodeLocation[] locations { get; set; }
        }

        public class GeocodeLocation
        {
            public GeocodeLatLng latLng { get; set; }
            public string street { get; set; }
            public string adminArea4 { get; set; }
        }

        public class GeocodeLatLng
        {
            public decimal lng { get; set; }
            public decimal lat { get; set; }
        }

        private void GetWebPage(string url, string hosturl, ref string pagebody)
        {
            HttpWebRequest HttpWRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWRequest.Method = "Get";
            HttpWRequest.Host = hosturl;

            HttpWebResponse HttpWResponse = (HttpWebResponse)HttpWRequest.GetResponse();

            StreamReader sr = new StreamReader(HttpWResponse.GetResponseStream(), Encoding.UTF8);
            pagebody = sr.ReadToEnd();
            sr.Close();
        }

    }
}