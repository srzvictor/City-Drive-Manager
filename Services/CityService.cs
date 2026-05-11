using System;
using System.Collections.Generic;
using CityDriveManager.Models;

namespace CityDriveManager.Services
{
    public class CityService
    {
        private List<Vehicle> vehicles = new();
        private List<PointOfInterest> points = new();
        private List<Trip> trips = new();

        public void Run()
        {
            int choice;

            do
            {
                ShowMenu();
                choice = ReadInt("Choix : ");

                switch (choice)
                {
                    case 1: AddPoint(); break;
                    case 2: AddVehicle(); break;
                    case 3: ShowVehicles(); break;
                    case 4: ShowPoints(); break;
                    case 5: CalculateDistance(); break;
                    case 6: SimulateVehicle(); break;
                    case 7: CreateTrip(); break;
                    case 8: ShowTrips(); break;
                    case 9: break;
                    default:
                        Console.WriteLine("Choix invalide.");
                        break;
                }

            } while (choice != 9);

            Console.WriteLine("Merci d'avoir utilisé City Drive Manager");
        }

        private void ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("====================================");
            Console.WriteLine("CITY DRIVE MANAGER - SMART CITY");
            Console.WriteLine("====================================");
            Console.WriteLine("1. Ajouter un point d'intérêt");
            Console.WriteLine("2. Ajouter un véhicule");
            Console.WriteLine("3. Afficher les véhicules");
            Console.WriteLine("4. Afficher les lieux");
            Console.WriteLine("5. Calculer une distance");
            Console.WriteLine("6. Simuler accélération/freinage");
            Console.WriteLine("7. Créer un trajet");
            Console.WriteLine("8. Afficher les trajets");
            Console.WriteLine("9. Quitter");
        }

        private void AddPoint()
        {
            Console.WriteLine("1. Campus");
            Console.WriteLine("2. Monument");
            int type = ReadInt("Type : ");

            string name = ReadString("Nom : ");
            double lat = ReadDouble("Latitude : ");
            double lon = ReadDouble("Longitude : ");

            if (type == 1)
            {
                int capacity = ReadInt("Capacité : ");
                points.Add(new Campus(name, lat, lon, capacity));
            }
            else
            {
                int year = ReadInt("Année de construction : ");
                points.Add(new HistoricalMonument(name, lat, lon, year));
            }

            Console.WriteLine("Point ajouté !");
        }

        private void AddVehicle()
        {
            Console.WriteLine("1. Car");
            Console.WriteLine("2. Truck");
            Console.WriteLine("3. HybridCar");
            int type = ReadInt("Type : ");

            string brand = ReadString("Marque : ");
            string color = ReadString("Couleur : ");

            if (type == 1)
            {
                string model = ReadString("Modèle : ");
                vehicles.Add(new Car(brand, color, model));
            }
            else if (type == 2)
            {
                double tonnage = ReadDouble("Tonnage : ");
                vehicles.Add(new Truck(brand, color, tonnage));
            }
            else
            {
                double battery = ReadDouble("Batterie (%) : ");
                double fuel = ReadDouble("Carburant (L) : ");
                vehicles.Add(new HybridCar(brand, color, battery, fuel));
            }

            Console.WriteLine("Véhicule ajouté !");
        }

        private void ShowVehicles()
        {
            if (vehicles.Count == 0)
            {
                Console.WriteLine("Aucun véhicule.");
                return;
            }

            for (int i = 0; i < vehicles.Count; i++)
            {
                Console.WriteLine($"\n[{i + 1}]");
                Console.WriteLine(vehicles[i]);
            }
        }

        private void ShowPoints()
        {
            if (points.Count == 0)
            {
                Console.WriteLine("Aucun lieu.");
                return;
            }

            for (int i = 0; i < points.Count; i++)
            {
                Console.WriteLine($"\n[{i + 1}]");
                Console.WriteLine(points[i]);
            }
        }

        private void CalculateDistance()
        {
            if (points.Count < 2)
            {
                Console.WriteLine("Il faut au moins 2 lieux.");
                return;
            }

            ShowPoints();
            int a = ReadInt("Point 1 : ") - 1;
            int b = ReadInt("Point 2 : ") - 1;

            if (a < 0 || a >= points.Count || b < 0 || b >= points.Count)
            {
                Console.WriteLine("Index invalide.");
                return;
            }

            double distance = points[a].CalculateDistance(points[b]);
            Console.WriteLine($"Distance : {distance:0.00} km");
        }

        private void SimulateVehicle()
        {
            if (vehicles.Count == 0)
            {
                Console.WriteLine("Aucun véhicule.");
                return;
            }

            ShowVehicles();
            int index = ReadInt("Véhicule : ") - 1;

            if (index < 0 || index >= vehicles.Count)
            {
                Console.WriteLine("Index invalide.");
                return;
            }

            Console.WriteLine("1. Accélérer");
            Console.WriteLine("2. Freiner");
            int choice = ReadInt("Choix : ");

            if (choice == 1)
                vehicles[index].Accelerate();
            else if (choice == 2)
                vehicles[index].Brake();
            else
            {
                Console.WriteLine("Choix invalide.");
                return;
            }

            Console.WriteLine(vehicles[index]);
        }

        private void CreateTrip()
        {
            if (vehicles.Count == 0 || points.Count < 2)
            {
                Console.WriteLine("Ajoutez d'abord des véhicules et des lieux.");
                return;
            }

            ShowVehicles();
            int vehicleIndex = ReadInt("Véhicule : ") - 1;

            ShowPoints();
            int startIndex = ReadInt("Point de départ : ") - 1;
            int endIndex = ReadInt("Point d'arrivée : ") - 1;

            if (vehicleIndex < 0 || vehicleIndex >= vehicles.Count ||
                startIndex < 0 || startIndex >= points.Count ||
                endIndex < 0 || endIndex >= points.Count)
            {
                Console.WriteLine("Index invalide.");
                return;
            }

            Console.Write("Date de départ (yyyy-MM-dd HH:mm) : ");
            DateTime departure;

            while (!DateTime.TryParse(Console.ReadLine(), out departure))
            {
                Console.Write("Format invalide. Recommencez : ");
            }

            trips.Add(new Trip(
                vehicles[vehicleIndex],
                points[startIndex],
                points[endIndex],
                departure
            ));

            Console.WriteLine("Trajet créé !");
        }

        private void ShowTrips()
        {
            if (trips.Count == 0)
            {
                Console.WriteLine("Aucun trajet.");
                return;
            }

            for (int i = 0; i < trips.Count; i++)
            {
                Console.WriteLine($"\nTrajet #{i + 1}");
                Console.WriteLine(trips[i]);
            }
        }

        private int ReadInt(string message)
        {
            int value;
            Console.Write(message);

            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Valeur invalide. Recommencez : ");
            }

            return value;
        }

        private double ReadDouble(string message)
        {
            double value;
            Console.Write(message);

            while (!double.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Valeur invalide. Recommencez : ");
            }

            return value;
        }

        private string ReadString(string message)
        {
            Console.Write(message);
            return Console.ReadLine()?.Trim() ?? "";
        }
    }
}