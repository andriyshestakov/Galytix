using System.Linq;

namespace Galytix.Model
{
    public class CountryGwpBusinessModel
    {
        public static double GetAverageGrowthRate(CountryGwpItem country, int startYear, int endYear)
        {
            var values = country.Gwp
                .Where(gwp => gwp.Key >= startYear && gwp.Key <= endYear)
                .OrderBy(p => p.Key)
                .Select(p => p.Value).ToArray();

            if (values.Length == 0) return 0;
            if (values.Length == 1) return 1;

            double[] yearGrowth = new double[values.Length - 1];
            for (int i = 0; i < values.Length - 1; i++)
            {
                yearGrowth[i] = (double)(values[i + 1] - values[i]) / (double)values[i] * 100;
            }

            return yearGrowth.Average();
        }
    }
}
