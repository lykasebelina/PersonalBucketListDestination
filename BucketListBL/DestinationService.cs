using BucketListMODEL;
using BucketListDL;
using System.Collections.Generic;


namespace BucketListBL
{
    public class DestinationService
    {
        private DestinationDataService _dbContext;

        public DestinationService(string connectionString)
        {
            _dbContext = new DestinationDataService(connectionString);
        }

        public Owner Login(string username, string password)
        {
            return _dbContext.GetUser(username, password);
        }

        public List<Destination> GetAllDestinations()
        {
            return _dbContext.GetAllDestinations();
        }

        public void AddDestination(Destination destination)
        {
            _dbContext.AddDestination(destination);
        }

        public void DeleteDestination(int id)
        {
            _dbContext.DeleteDestination(id);
        }

        public Destination GetDestination(int id)
        {
            return _dbContext.GetDestination(id);
        }
    }
}
