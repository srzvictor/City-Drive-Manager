namespace CityDriveManager.Models
{
    public class Trip
    {
        public const double AverageSpeed = 50;

        public Vehicle Vehicle { get; set; }
        public PointOfInterest Start { get; set; }
        public PointOfInterest End { get; set; }
        public DateTime DepartureDate { get; set; }

        public Trip(Vehicle vehicle, PointOfInterest start, PointOfInterest end, DateTime departureDate)
        {
            Vehicle = vehicle;
            Start = start;
            End = end;
            DepartureDate = departureDate;
        }

        public double GetDistance()
        {
            return Start.CalculateDistance(End);
        }

        public int GetDurationInMinutes()
        {
            return (int)((GetDistance() / AverageSpeed) * 60);
        }

        public override string ToString()
        {
            return $"Véhicule : {Vehicle.Brand}\n" +
                   $"De : {Start.Name}\n" +
                   $"À : {End.Name}\n" +
                   $"Distance : {GetDistance():0.00} km\n" +
                   $"Durée estimée : {GetDurationInMinutes()} minutes\n" +
                   $"Départ : {DepartureDate:dd-MM-yyyy HH:mm}";
        }
    }
}