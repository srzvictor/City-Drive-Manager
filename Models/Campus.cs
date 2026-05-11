namespace CityDriveManager.Models
{
    public class Campus : PointOfInterest
    {
        public int Capacity { get; set; }

        public Campus(string name, double latitude, double longitude, int capacity)
            : base(name, latitude, longitude)
        {
            Capacity = capacity;
        }

        public override string ToString()
        {
            return $"CAMPUS\n{base.ToString()}\nCapacité : {Capacity}";
        }
    }
}