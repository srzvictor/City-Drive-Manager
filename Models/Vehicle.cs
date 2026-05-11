namespace CityDriveManager.Models
{
    public abstract class Vehicle
    {
        public string Brand { get; set; }
        public string Color { get; set; }
        public double CurrentSpeed { get; protected set; }

        protected Vehicle(string brand, string color)
        {
            Brand = brand.Trim().ToUpper();
            Color = color.Trim().ToUpper();
            CurrentSpeed = 0;
        }

        public virtual void Accelerate()
        {
            CurrentSpeed += 10;
        }

        public virtual void Brake()
        {
            CurrentSpeed -= 10;
            if (CurrentSpeed < 0)
                CurrentSpeed = 0;
        }

        public override string ToString()
        {
            return $"Marque : {Brand}\nCouleur : {Color}\nVitesse actuelle : {CurrentSpeed} km/h";
        }
    }
}