using System.Collections.Generic;

namespace Galytix.Model
{
    // Consider changing to immutable  Dictionary => IEnumerable and readonly props
    public class CountryGwpItem
    {
        public string Country { get; set; }
        public string VariableId { get; set; }
        public string VariableName { get; set; }
        public string LineOfBusiness { get; set; }
        public Dictionary<int, decimal> Gwp { get; set; }
    }
}
