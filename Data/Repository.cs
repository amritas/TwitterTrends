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

            var connectionstring = ConfigurationManager.AppSettings.Get("(MONGOHQ_URL|MONGOLAB_URI)");
            var url = new MongoUrl(connectionstring);
            var client = new MongoClient(url);
            var server = client.GetServer();
            var mongoDb = server.GetDatabase(url.DatabaseName);
            mongoDb= server.GetDatabase("TwitterTrends");
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
