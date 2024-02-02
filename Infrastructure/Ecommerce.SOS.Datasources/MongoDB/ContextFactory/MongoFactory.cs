using Ecommerce.SOS.Domain.Constants;
using Ecommerce.SOS.Domain.Utils;
using MongoDB.Driver;

namespace Ecommerce.SOS.Datasources.MongoDB.ContextFactory
{
	public class MongoFactory
	{
        public MongoFactory()
        {
        }

        public MongoClient CreateMongoClientFromConnectionString()
        {

            string pass = EnvironmentManager.GetEnvironmentValue(
                    EnvironmentVariables.MONGODB_HOST);

            MongoClientSettings clientSettings = MongoClientSettings.FromConnectionString(pass);

            clientSettings.ServerApi = new ServerApi(ServerApiVersion.V1);
            MongoClient client = new MongoClient(clientSettings);

            return client;
        }

        public IMongoCollection<T> GetCollection<T>(string clientDataBase, string collectionName,
            IMongoClient client)
        {
            IMongoDatabase database = client.GetDatabase(clientDataBase);
            IMongoCollection<T> collection = database.GetCollection<T>(collectionName);
            return collection;
        }
    }
}

