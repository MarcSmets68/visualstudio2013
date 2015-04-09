using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Twitter3
{
    [Serializable]
    public class Tweets
    {
        private List<Tweet> messages;
        public ReadOnlyCollection<Tweet> AlleTweets()
        {
            return new ReadOnlyCollection<Tweet>(messages);
        }

        public void AddTweet(Tweet tweet)
        {
            if (messages == null)
                messages = new List<Tweet>();;
            messages.Add(tweet);
        }
        
    }
}
