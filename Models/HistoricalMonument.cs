namespace CityDriveManager.Models
{
    public class HistoricalMonument : PointOfInterest
    {
        public int BuildYear { get; set; }

        public HistoricalMonument(string name, double latitude, double longitude, int buildYear)
            : base(name, latitude, longitude)
        {
            BuildYear = buildYear;
        }

        public override string ToString()
        {
            return $"HISTORICAL MONUMENT\n{base.ToString()}\nConstruit en : {BuildYear}";
        }
    }
}