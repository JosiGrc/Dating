using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static Dating.Models.Geocode;

namespace Dating.Controllers
{
    public class GeocodesController : ApiController
    {
        // GET: api/Geocodes
        public IEnumerable<string> Get()
        {
            //var result = new WebClient().DownloadString(requestUrl);
            //GeoCode geocode = JsonConvert.DeserializeObject<GeoCode>(result);
            //return geocode;

            return new string[] { "value1", "value2" };
        }

        // GET: api/Geocodes/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Geocodes
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Geocodes/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Geocodes/5
        public void Delete(int id)
        {
        }
    }
}
