namespace CityDriveManager.Models
{
    public class Car : Vehicle
    {
        public string Model { get; set; }

        public Car(string brand, string color, string model)
            : base(brand, color)
        {
            Model = model.Trim().ToUpper();
        }

        public override string ToString()
        {
            return $"CAR\n{base.ToString()}\nModèle : {Model}";
        }
    }
}