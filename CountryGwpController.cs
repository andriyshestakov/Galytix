using Galytix.Data;
using Galytix.Model;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Web.Http;

namespace Galytix
{
    public class CountryGwpController : ApiController
    {
        private ICountryGwpRepository _repository { get; }

        public CountryGwpController(ICountryGwpRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CountryGwpItem> Post([FromBody]JObject data)
        {
            var request = data.ToObject<AverageGrowthRateRequest>();
            return _repository.FindCloseAverageGwpPeers(request.Country, request.LineOfBusiness, request.YearStart, request.YearEnd, request.PeersToReturn);
        }
    }
}
