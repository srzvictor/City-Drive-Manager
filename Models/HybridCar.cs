namespace CityDriveManager.Models
{
    public class HybridCar : Vehicle, IThermalCar, IElectricCar
    {
        public double BatteryLevel { get; set; }
        public double FuelLevel { get; set; }

        public HybridCar(string brand, string color, double batteryLevel, double fuelLevel)
            : base(brand, color)
        {
            BatteryLevel = batteryLevel;
            FuelLevel = fuelLevel;
        }

        public override void Accelerate()
        {
            if (BatteryLevel > 0)
            {
                BatteryLevel -= 2;
                if (BatteryLevel < 0)
                    BatteryLevel = 0;
            }
            else if (FuelLevel > 0)
            {
                FuelLevel -= 1;
                if (FuelLevel < 0)
                    FuelLevel = 0;
            }

            base.Accelerate();
        }

        public void Refuel(double amount)
        {
            FuelLevel += amount;
        }

        public void Recharge(double amount)
        {
            BatteryLevel += amount;
            if (BatteryLevel > 100)
                BatteryLevel = 100;
        }

        public override string ToString()
        {
            return $"HYBRID CAR\n{base.ToString()}\nBatterie : {BatteryLevel}%\nCarburant : {FuelLevel}L";
        }
    }
}