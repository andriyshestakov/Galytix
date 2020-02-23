namespace Galytix
{
    public class AverageGrowthRateRequest
    {
        public string Country { get; set; }
        public string LineOfBusiness { get; set; }
        public int YearStart { get; set; }
        public int YearEnd { get; set; }
        public int PeersToReturn { get; set; }
    }
}
