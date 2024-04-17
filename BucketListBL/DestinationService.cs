using BucketListDL;
using BucketListMODEL;


namespace BucketListBL
{
    public class DestinationService
    {
        DestinationDataService destinationDataService = new DestinationDataService();

        public bool VerifyOwner(string username, string password)
        {


            var result = destinationDataService.GetOwner(username, password);


            return result.username != null ? true : false;
            return result.password != null ? true : false;


        }

        public bool VerifyDestination(string destination)
        {


            var results = destinationDataService.GetDestination(destination);

            return results.destination != null ? true : false;

        }

        public List<Destination> DisplayDestinationNames()
        {

            return destinationDataService.GetDestinationNames();
        }


        public bool RemoveDestination(string delDestination)
        {
            return destinationDataService.DeleteDestinations(delDestination);
        }

        public void AddNewDestination(string newDestination)
        {
            var addDes = new Destination { destination = newDestination };
            destinationDataService.AddDestination(addDes);



        }
    }
}