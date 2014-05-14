using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var client = new MongoClient(ConfigurationManager.AppSettings["connectionString"]);
            var server = client.GetServer();
            mongoDb= server.GetDatabase("TwitterTrends");
        }

        public void SaveTweets(string tweets)
        {
            Tweets tweet = new Tweets(tweets);
            var collection = mongoDb.GetCollection<Tweets>("tweets");
            collection.Insert(tweet).ToBson();
           
        }
    }
}
