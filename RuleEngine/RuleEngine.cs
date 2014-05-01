using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using TweetSharp;
using System.Configuration;
using Newtonsoft.Json;

namespace RuleEngine
{
    public class RuleEngineController : ApiController
    {
        public void GetTweets(string keyword)
        {
            var consumerKey = ConfigurationManager.AppSettings["TwitterConsumerKey"];
            var consumerSecret = ConfigurationManager.AppSettings["TwitterConsumerSecret"];
            var accessToken = ConfigurationManager.AppSettings["AccessToken"];
            var accessTokenSecret = ConfigurationManager.AppSettings["AccessTokenSecret"];

            var service = new TwitterService(consumerKey, consumerSecret);
            service.AuthenticateWith(accessToken, accessTokenSecret);

            var tweets = (service.Search(new SearchOptions { Q = keyword })).Statuses.ToString();
            string jsonTweets= JsonConvert.SerializeObject(tweets);

            
        }


    }
}
