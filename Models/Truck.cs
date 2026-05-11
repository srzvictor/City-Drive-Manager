namespace CityDriveManager.Models
{
    public class Truck : Vehicle
    {
        public double Tonnage { get; set; }

        public Truck(string brand, string color, double tonnage)
            : base(brand, color)
        {
            Tonnage = tonnage;
        }

        public override string ToString()
        {
            return $"TRUCK\n{base.ToString()}\nTonnage : {Tonnage} t";
        }
    }
}