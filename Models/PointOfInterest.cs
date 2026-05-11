using System.Globalization;

namespace CityDriveManager.Models
{
    public class PointOfInterest
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public PointOfInterest(string name, double latitude, double longitude)
        {
            Name = name.Trim().ToUpper();
            Latitude = latitude;
            Longitude = longitude;
        }

        public string GetGoogleMapsUrl()
        {
            string lat = Latitude.ToString(CultureInfo.InvariantCulture);
            string lon = Longitude.ToString(CultureInfo.InvariantCulture);

            return $"https://www.google.com/maps?q={lat},{lon}";
        }

        public double CalculateDistance(PointOfInterest other)
        {
            double dLat = other.Latitude - Latitude;
            double dLon = other.Longitude - Longitude;
            return (Math.Sqrt(dLat * dLat + dLon * dLon))*111;
        }

        public override string ToString()
        {
            return $"Nom : {Name}\nCoordonnées : ({Latitude}, {Longitude})\nGoogle Maps : {GetGoogleMapsUrl()}";
        }
    }
}