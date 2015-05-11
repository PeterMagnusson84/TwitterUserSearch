using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TweetSearch.Models.Webservices;
using TweetSearch.ViewModels;

namespace TweetSearch.Controllers
{
    public class TwitterController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "ScreenName")] TwitterIndexViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var webservice = new TwitterWebservice();
                    model.Tweets = webservice.GetUserTimeline(model.ScreenName);
                }
                
            }
            catch(Exception ex)//Ta hand om möjliga fel.
            {
                ModelState.AddModelError(String.Empty, ex.Message);
            }
            
            return View(model);
        }

       
    }
}
