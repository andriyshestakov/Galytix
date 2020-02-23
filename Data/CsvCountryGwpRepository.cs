using Galytix.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Galytix.Data
{
    public class CsvCountryGwpRepository : ICountryGwpRepository
    {
        private readonly IEnumerable<CountryGwpItem> _countryGwpItems = Enumerable.Empty<CountryGwpItem>();
        public CsvCountryGwpRepository(string path)
        {
            try
            {
                _countryGwpItems = CsvCountryGwpParser.ParseCsv(path).ToArray();
            }
            catch (Exception)
            {
                // log 
                // I am not implementing proper exception handling considering it is test (not prod code) and due to the lack of time, sorry 
                throw;
            }
        }

        public IEnumerable<CountryGwpItem> FindCloseAverageGwpPeers(string country, string lineOfBusiness, int yearStart, int yearEnd, int peersToReturn)
        {
            CountryGwpItem selectedCountry = _countryGwpItems.FirstOrDefault(c => c.Country == country && c.LineOfBusiness == lineOfBusiness);
            var selectedCountryAvgGrowthRate = CountryGwpBusinessModel.GetAverageGrowthRate(selectedCountry, yearStart, yearEnd);

            var peers = _countryGwpItems
                .Where(p => p.LineOfBusiness == lineOfBusiness)
                .OrderByDescending(p => SqrRootDistanceToAvgGrowthRate(selectedCountryAvgGrowthRate, p, yearStart, yearEnd))
                .Take(peersToReturn);

            return peers;
        }

        private double SqrRootDistanceToAvgGrowthRate(double selectedCountryAvgGrowthRate, CountryGwpItem countryGwp, int yearStart, int yearEnd)
        {
            return Math.Sqrt(Math.Pow((selectedCountryAvgGrowthRate - CountryGwpBusinessModel.GetAverageGrowthRate(countryGwp, yearStart, yearEnd)), 2));
        }

        public IEnumerable<CountryGwpItem> GetAll()
        {
            return _countryGwpItems.ToArray();
        }
    }
}
