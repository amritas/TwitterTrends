using MongoDB.Bson;
using MongoDB.Driver;
using System.Configuration;

namespace Data
{
    public class Repository
    {
        static MongoDatabase mongoDb = null;

        public Repository()
        {
            ConnecttoDb();
        }

        public void ConnecttoDb()
        {
            //var client = new MongoClient(ConfigurationManager.AppSettings["connectionString"]);
            //var server = client.GetServer();

            var connectionstring = GetMongoDbConnectionString();
            var url = new MongoUrl(connectionstring);
            var client = new MongoClient(url);
            var server = client.GetServer();
            var mongoDb = server.GetDatabase(MongoUrl.Create(connectionstring).DatabaseName);//.GetDatabase(url.DatabaseName);
            //mongoDb= server.GetDatabase("TwitterTrends");
        }

        private string GetMongoDbConnectionString()
        {
            return ConfigurationManager.AppSettings.Get("MONGOHQ_URL") ??
            ConfigurationManager.AppSettings.Get("MONGOLAB_URI") ??
            "mongodb://localhost/APICache";
        }

        public void SaveTweets(string tweets)
        {
            Tweets tweet = new Tweets(tweets);
            var collection = mongoDb.GetCollection<Tweets>("tweets");
            collection.Insert(tweet).ToBson();
        }

        public MongoCollection<Tweets> GetTweets()
        {
            var tweetCollection = mongoDb.GetCollection<Tweets>("tweets");
            return tweetCollection;
        }
    }
}
