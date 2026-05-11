using CityDriveManager.Services;

namespace CityDriveManager
{
    class Program
    {
        static void Main()
        {
            CityService service = new CityService();
            service.Run();
        }
    }
}