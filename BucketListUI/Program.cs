﻿using BucketListDL;
using BucketListMODEL;

namespace BucketListUI
{

    internal class Program
    {
        public static void Main(string[] args)
        {
            Program myprogram = new Program();
            myprogram.Runn();

        }

    

  
        public void Runn()
        {
            Console.WriteLine("PERSONAL BUCKET LIST DESTINATIONS");
            Console.WriteLine();


            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();
            Console.WriteLine();

            BucketListBL.DestinationService destinationService = new BucketListBL.DestinationService();
            bool result = destinationService.VerifyOwner(username, password);


            if (result)
            {
                Console.Clear();
                Program myMainProg = new Program();
                myMainProg.Run();

            }


            else
            {
                Console.WriteLine("Invalid username and password! Press 'ENTER' key to restart.");
                string key1 = Console.ReadLine();

                Console.Clear();
                Program prog0 = new Program();
                prog0.Runn();
            }

        }

    

 

        public void Run()
        {

            Console.WriteLine("WELCOME BACK LYKA!");
            Console.WriteLine();


            BucketListBL.DestinationService destinationService = new BucketListBL.DestinationService();
            List<Destination> destinations = destinationService.DisplayDestinationNames();

            Console.WriteLine("Here's your Bucket List Destinations:");
            Console.WriteLine();

            foreach (var name in destinations)
            {
                Console.WriteLine("  > " + name.destination);
            }


            Console.WriteLine();
            Console.WriteLine("Choose What To Do:");
            Console.WriteLine("  1 - Search Destination");
            Console.WriteLine("  2 - Add New Destination");
            Console.WriteLine("  3 - Remove Destination");
            Console.WriteLine();
            Console.Write("Enter Number Of Choice: ");

            string option = Console.ReadLine();


            switch (option)
            {
                case "1":



                    Console.WriteLine();
                    Console.WriteLine("---------- SEARCH OPTION ----------");
                    Console.WriteLine();

                    Console.Write("Search Destination: ");
                    string search = Console.ReadLine();


                    bool results = destinationService.VerifyDestination(search);

                    DestinationDataService destinationDataService = new DestinationDataService();
                    Destination details = destinationDataService.GetDestination(search);

                    if (results)
                    {

                        Console.WriteLine();
                        Console.WriteLine("ABOUT DESTINATION");
                        Console.WriteLine();
                        Console.WriteLine($"Name: {details.destination}");
                        Console.WriteLine($"Major Attractions: {details.majorAttraction}");
                        Console.WriteLine($"Established: {details.yearEstablished}");
                        Console.WriteLine($"Address: {details.address}");
                        Console.WriteLine($"Opening Hours: {details.openingHours}");
                    }

                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Destination not found. Please refer from the list!");
                    }

                    Console.WriteLine();
                    Console.WriteLine("Press 'ENTER' key to restart.");
                    Console.ReadLine();

                    Console.Clear();

                    Program prog1 = new Program();
                    prog1.Run();


                    break;


                case "2":



                    Console.WriteLine();
                    Console.WriteLine("---------- ADD OPTION ----------");
                    Console.WriteLine();
                    Console.Write("Enter New Destination: ");
                    string newDestination = Console.ReadLine();

                    destinationService.AddNewDestination(newDestination);

                    Console.WriteLine();
                    Console.WriteLine("Destination has been added successfully!\nHere's the updated list: ");
                    Console.WriteLine();

                    foreach (var name in destinations)
                    {
                        Console.WriteLine("  > " + name.destination);
                    }


                    Console.WriteLine();
                    Console.WriteLine("Press 'ENTER' key to restart.");
                    Console.ReadLine();

                    Console.Clear();

                    Program prog2 = new Program();
                    prog2.Run();

                    break;


                case "3":



                    Console.WriteLine();
                    Console.WriteLine("---------- REMOVE OPTION ----------");
                    Console.WriteLine();
                    Console.Write("Enter Destination Name: ");
                    string delDestination = Console.ReadLine();
                    Console.WriteLine();

                    if (destinationService.RemoveDestination(delDestination))
                    {

                        Console.WriteLine("Destination has been removed successfully!\nHere's the updated list: ");
                        Console.WriteLine();

                        foreach (var name in destinations)
                        {
                            Console.WriteLine("  > " + name.destination);
                        }

                    }

                    else
                    {
                        Console.WriteLine("Destination not found. Try again!");
                    }

                    Console.WriteLine();
                    Console.WriteLine("Press 'ENTER' key to restart.");
                    Console.ReadLine();

                    Console.Clear();

                    Program prog3 = new Program();
                    prog3.Run();

                    break;


                default:

                    Console.WriteLine();
                    Console.WriteLine("Invalid choice! Press 'ENTER' key to restart.");
                    Console.ReadLine();

                    Console.Clear();

                    Program prog4 = new Program();
                    prog4.Run();

                    break;
            }

        }
    }

}