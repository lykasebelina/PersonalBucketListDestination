using BucketListMODEL;


namespace BucketListDL
{

    public class DestinationDataService
    {
        List<Destination> destinations = new List<Destination>();
        List<Owner> owner = new List<Owner>();

        public DestinationDataService()
        {
            CreateDestinationData();
        }

        private void CreateDestinationData()
        {
            Owner defaultOwner = new Owner
            {
                username = "lykasebelina",
                password = "00260"
            };

            destinations.Add(new Destination
            {
                destination = "Las Casas Filipinas de Acuzar",
                majorAttraction = "Spanish-Filipino Colonial Structures",
                yearEstablished = "1780",
                address = "Bagac, Bataan, Philippines",
                openingHours = "Open 24 Hours",
                access = defaultOwner

            });

            destinations.Add(new Destination
            {
                destination = "Intramuros",
                majorAttraction = "Museums and Churches",
                yearEstablished = "1571",
                address = "Bonifacio Dr & Padre Burgos St, Manila, Luzon 1002, Philippines",
                openingHours = "9 AM-5 PM",
                access = defaultOwner

            });

            destinations.Add(new Destination
            {
                destination = "Calle Crisologo",
                majorAttraction = "Ancestral Houses",
                yearEstablished = "16th Century",
                address = "Crisologo, Vigan City, Ilocos Sur",
                openingHours = "Open 24 Hours",
                access = defaultOwner
            });

            destinations.Add(new Destination
            {
                destination = "Manila Ocean Park",
                majorAttraction = "Oceanarium",
                yearEstablished = "2007",
                address = "Quirino Grandstand, 666 Behind, Ermita, Manila, 1000 Metro Manila",
                openingHours = "10 AM-6 PM",
                access = defaultOwner
            });

            destinations.Add(new Destination
            {
                destination = "Burnham Park",
                majorAttraction = "Orchidarium, Gardens, and Man-made Lake",
                yearEstablished = "1907",
                address = "Jose Abad Santos Dr, Baguio, 2600 Benguet",
                openingHours = "Open 24 Hours",
                access = defaultOwner
            });

            owner.Add(defaultOwner);


        }


        public Owner GetOwner(string username, string password)
        {
            Owner foundOwner = new Owner();

            foreach (var ownerData in owner)
            {
                if (username == ownerData.username && password == ownerData.password)
                {
                    foundOwner = ownerData;
                }
            }

            return foundOwner;
        }

        public Destination GetDestination(string destination)
        {
            Destination foundDestination = new Destination();

            foreach (var data in destinations)
            {
                if (destination == data.destination)
                {
                    foundDestination = data;
                }
            }

            return foundDestination;

        }

        public List<Destination> GetDestinationNames()
        {

            return destinations;
        }


        public bool DeleteDestinations(string delDestination)
        {

            var place = destinations.FirstOrDefault(n => n.destination == delDestination);
            if (place != null)

            {
                destinations.Remove(place);
                return true;
            }

            return false;

        }

        public void AddDestination(Destination addDestination)
        {
            destinations.Add(addDestination);
        }
    }


}