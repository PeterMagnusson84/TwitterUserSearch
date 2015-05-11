using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Web;

namespace TweetSearch.Models
{
    public class Tweet
    {
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }

        public Tweet(JToken t)
        {
            CreatedAt = DateTime.ParseExact((t["created_at"]).ToString(),
            "ddd MMM dd HH:mm:ss zz00 yyyy", CultureInfo.InvariantCulture);
            Name = (t["user"]["name"]).ToString();
            Text = (t["text"]).ToString();
        }
    }
}