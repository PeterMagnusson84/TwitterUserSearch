using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TweetSearch.Models;

namespace TweetSearch.ViewModels
{
    public class TwitterIndexViewModel
    {
        [DisplayName("Sök")]
        [Required(ErrorMessage = "En Twitteranvändare måste anges")]
        public string ScreenName { get; set; }

        public bool HasTweets
        {
            get { return Tweets != null && Tweets.Any(); }
        }

        public string Name
        {
            get
            {
                return HasTweets ? Tweets.First().Name : "[Unknown]";
            }
        
        }

        public IEnumerable<Tweet> Tweets { get; set; }
    }
}