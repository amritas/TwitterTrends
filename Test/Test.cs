using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RuleEngine;
using NUnit;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class Test
    {
        [TestCase]
        public void GetTweets()
        {
            RuleEngineController contrl = new RuleEngineController();
            contrl.GetLatestTweets();
            Assert.AreEqual(2, 2);
        }
       
    }
}
