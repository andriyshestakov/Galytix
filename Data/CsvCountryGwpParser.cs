using Galytix.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace Galytix.Data
{
    public class CsvCountryGwpParser
    {
        public static IEnumerable<CountryGwpItem> ParseCsv(string path)
        {
            using (var reader = new StreamReader(path))
            {
                if (!reader.EndOfStream)
                {
                    reader.ReadLine(); // ignore column name line 
                }
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(new[] { ',' });
                    yield return ParseCountryGwpItem(values);
                }
            }
        }
        private static CountryGwpItem ParseCountryGwpItem(string[] values)
        {
            CountryGwpItem item = new CountryGwpItem();
            item.Country = values[(int)CountryGwpItemFields.country];
            item.VariableId = values[(int)CountryGwpItemFields.variableId];
            item.VariableName = values[(int)CountryGwpItemFields.variableName];
            item.LineOfBusiness = values[(int)CountryGwpItemFields.lineOfBusiness];

            item.Gwp = new Dictionary<int, decimal>();

            decimal gwp;

            if (Decimal.TryParse(values[(int)CountryGwpItemFields.Y2000], out gwp))
            {
                item.Gwp.Add(2000, gwp);
            }

            if (Decimal.TryParse(values[(int)CountryGwpItemFields.Y2001], out gwp))
            {
                item.Gwp.Add(2001, gwp);
            }

            if (Decimal.TryParse(values[(int)CountryGwpItemFields.Y2002], out gwp))
            {
                item.Gwp.Add(2002, gwp);
            }

            if (Decimal.TryParse(values[(int)CountryGwpItemFields.Y2003], out gwp))
            {
                item.Gwp.Add(2003, gwp);
            }

            if (Decimal.TryParse(values[(int)CountryGwpItemFields.Y2004], out gwp))
            {
                item.Gwp.Add(2004, gwp);
            }

            if (Decimal.TryParse(values[(int)CountryGwpItemFields.Y2005], out gwp))
            {
                item.Gwp.Add(2005, gwp);
            }

            if (Decimal.TryParse(values[(int)CountryGwpItemFields.Y2006], out gwp))
            {
                item.Gwp.Add(2006, gwp);
            }

            if (Decimal.TryParse(values[(int)CountryGwpItemFields.Y2007], out gwp))
            {
                item.Gwp.Add(2007, gwp);
            }

            if (Decimal.TryParse(values[(int)CountryGwpItemFields.Y2008], out gwp))
            {
                item.Gwp.Add(2008, gwp);
            }

            if (Decimal.TryParse(values[(int)CountryGwpItemFields.Y2009], out gwp))
            {
                item.Gwp.Add(2009, gwp);
            }

            if (Decimal.TryParse(values[(int)CountryGwpItemFields.Y2010], out gwp))
            {
                item.Gwp.Add(2010, gwp);
            }

            if (Decimal.TryParse(values[(int)CountryGwpItemFields.Y2011], out gwp))
            {
                item.Gwp.Add(2011, gwp);
            }

            if (Decimal.TryParse(values[(int)CountryGwpItemFields.Y2012], out gwp))
            {
                item.Gwp.Add(2012, gwp);
            }

            if (Decimal.TryParse(values[(int)CountryGwpItemFields.Y2013], out gwp))
            {
                item.Gwp.Add(2013, gwp);
            }


            if (Decimal.TryParse(values[(int)CountryGwpItemFields.Y2014], out gwp))
            {
                item.Gwp.Add(2014, gwp);
            }

            if (Decimal.TryParse(values[(int)CountryGwpItemFields.Y2015], out gwp))
            {
                item.Gwp.Add(2015, gwp);
            }

            return item;
        }

        private enum CountryGwpItemFields
        {
            country,
            variableId,
            variableName,
            lineOfBusiness,
            Y2000,
            Y2001,
            Y2002,
            Y2003,
            Y2004,
            Y2005,
            Y2006,
            Y2007,
            Y2008,
            Y2009,
            Y2010,
            Y2011,
            Y2012,
            Y2013,
            Y2014,
            Y2015
        }
    }
}