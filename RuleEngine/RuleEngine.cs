using Data;
using MongoDB.Driver;
using Newtonsoft.Json;
using System.Configuration;
using System.Web.Http;
using TweetSharp;

namespace RuleEngine
{
    public class RuleEngineController : ApiController
    {
        public string Tweets;

        string consumerKey = ConfigurationManager.AppSettings["TwitterConsumerKey"];
        string consumerSecret = ConfigurationManager.AppSettings["TwitterConsumerSecret"];
        string accessToken = ConfigurationManager.AppSettings["AccessToken"];
        string accessTokenSecret = ConfigurationManager.AppSettings["AccessTokenSecret"];

        public void GetLatestTweets(string keyword)
        {
            ITwitterService service = AuthenticateTwitterSvc();

            var tweets = (service.Search(new SearchOptions { Q = keyword })).Statuses.ToString();
            Tweets= JsonConvert.SerializeObject(tweets);
        }

        public MongoCollection<Tweets> ShowTweets()
        {
            ITwitterService service = AuthenticateTwitterSvc();
            Repository repo = new Repository();
            return repo.GetTweets();
        }
       
        public void SaveTweets(string keyword)
        {
            ITwitterService service = AuthenticateTwitterSvc();
            Repository repo = new Repository();
            repo.SaveTweets(Tweets);
        }

        private ITwitterService AuthenticateTwitterSvc()
        {
            ITwitterService service = new TwitterService(consumerKey, consumerSecret);
            service.AuthenticateWith(accessToken, accessTokenSecret);
            return service;
        }
    }
}
