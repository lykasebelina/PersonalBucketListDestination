using System;
using BucketListBL;
using BucketListMODEL;
using System.Collections.Generic;


namespace BucketListUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = 
            "Data Source =LAPTOP-MLIHGQC9\Lawrence; Initial Catalog = BucketListDestinationProject; Integrated Security = True;";
            DestinationService service = new DestinationService(connectionString);

            Console.WriteLine("Welcome to Travel Bucket List App!");
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            Owner user = service.Login(username, password);

            if (user != null)
            {
                Console.WriteLine("Login successful!");

                bool running = true;
                while (running)
                {
                    Console.WriteLine("1. Search Destination");
                    Console.WriteLine("2. View All Destinations");
                    Console.WriteLine("3. Add Destination");
                    Console.WriteLine("4. Delete Destination");
                    Console.WriteLine("5. Exit");

                    Console.Write("Choose an option: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            Console.Write("Enter Destination ID: ");
                            int id = int.Parse(Console.ReadLine());
                            Destination destination = service.GetDestination(id);
                            if (destination != null)
                            {
                                Console.WriteLine($"Name: {destination.Name}");
                                Console.WriteLine($"Description: {destination.Description}");
                                Console.WriteLine($"Country: {destination.Country}");
                                Console.WriteLine($"City: {destination.City}");

                            }
                            else
                            {
                                Console.WriteLine("Destination not found.");
                            }
                            break;

                        case "2":
                            List<Destination> destinations = service.GetAllDestinations();
                            foreach (var dest in destinations)
                            {
                                Console.WriteLine($"ID: {dest.DestinationId}, Name: {dest.Name}, Country: {dest.Country}, City: {dest.City}");
                            }
                            break;

                        case "3":
                            Destination newDestination = new Destination();
                            Console.Write("Enter Name: ");
                            newDestination.Name = Console.ReadLine();
                            Console.Write("Enter Description: ");
                            newDestination.Description = Console.ReadLine();
                            Console.Write("Enter Country: ");
                            newDestination.Country = Console.ReadLine();
                            Console.Write("Enter City: ");
                            newDestination.City = Console.ReadLine();

                            service.AddDestination(newDestination);
                            Console.WriteLine("Destination added successfully.");
                            break;

                        case "4":
                            Console.Write("Enter Destination ID to delete: ");
                            int deleteId = int.Parse(Console.ReadLine());
                            service.DeleteDestination(deleteId);
                            Console.WriteLine("Destination deleted successfully.");
                            break;

                        case "5":
                            running = false;
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Login failed. Invalid username or password.");
            }
        }
    }
}
