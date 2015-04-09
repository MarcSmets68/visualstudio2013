using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Twitter3
{
    [Serializable]
    public class Twitter
    {
        const string bestand = @"C:\Data\Twitter.obj";

        public void SchrijfTweet(Tweet tweet)
        {
            Tweets tweets;
            if (File.Exists(bestand))
            {
                tweets = LeesTweets();
            }
            else
                tweets = new Tweets();
            tweets.AddTweet(tweet);
            SchrijfTweets(tweets);

        }

        public Tweets LeesTweets()
        {
            try
            {
                using (var readstream = File.Open(bestand, FileMode.Open, FileAccess.Read))
                {
                    var lezer = new BinaryFormatter();
                    return  ((Tweets)lezer.Deserialize(readstream));                   
                }
            }
            catch (IOException)
            {

                throw new Exception("Fout bij openen van bestand."); 
            }
            catch (SerializationException)
            {
                throw new Exception("Fout bij het deserialiseren.");
            }
            catch (Exception ex)
            {
               throw new Exception(ex.Message);
            }
           
        }

        public void SchrijfTweets(Tweets ingave)
        {
            try
            {
                using (var writestream = File.Open(bestand, FileMode.OpenOrCreate))
                {
                    var schrijf = new BinaryFormatter();
                    schrijf.Serialize(writestream, ingave);
                }
            }
            catch (IOException)
            {

                throw new Exception("Fout bij openen van bestand."); 
            }
            catch (SerializationException)
            {
                throw new Exception("Fout bij het serialiseren.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Tweet> AllTweets()
        {
            if (File.Exists(bestand))
            {
                var tweets = LeesTweets();
                return tweets.AlleTweets().OrderByDescending(time => time.Tijdstip).ToList();
            }
            else
            {
                throw new Exception("Het bestand" + bestand + " is niet gevonden!");
            }
        }

        public List<Tweet> TweetsVan(string naam)
        {
           return AllTweets().Where(val => val.Naam.ToUpper() == naam.ToUpper()).ToList();
        }

       
    }
}
