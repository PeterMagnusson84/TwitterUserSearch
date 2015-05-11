using GeekTweet.Models.Webservices;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace TweetSearch.Models.Webservices
{
    public class TwitterWebservice
    {
        public IEnumerable<Tweet> GetUserTimeline(string screenName)
        {
            string tweetJson;

            var oAuthTwitterWrapper = new OAuthTwitterWrapper();
            var accessToken = oAuthTwitterWrapper.GetAccessToken();

            var requestUriString = string.Format("https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name={0}&count=20", screenName);
            var request = (HttpWebRequest)WebRequest.Create(requestUriString);
            request.Headers.Add("Authorization", string.Format("{0} {1}", accessToken.Type, accessToken.Token));

            using(var response = request.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                tweetJson = reader.ReadToEnd();
            }

            return JArray.Parse(tweetJson).Select(t => new Tweet(t)).ToList();

        }
    }
}