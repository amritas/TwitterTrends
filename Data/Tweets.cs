using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Tweets
    {
        public string Tweet { get; set; }

        public Tweets(string tweet)
        {
            this.Tweet = tweet;
        }
    }
}
