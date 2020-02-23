using Galytix.Model;
using System.Collections.Generic;

namespace Galytix.Data
{
    public interface ICountryGwpRepository
    {
        IEnumerable<CountryGwpItem> GetAll();
        IEnumerable<CountryGwpItem> FindCloseAverageGwpPeers(string country, string lineOfBusiness, int yearStart, int yearEnd, int peersToReturn);
    }
}
