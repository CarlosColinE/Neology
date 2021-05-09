using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheAudioDBAPI.Controllers.Album
{
    public class FullArtistInfoController : Controller
    {
        // GET: FullArtistInfo
        public ActionResult FullInfo()
        {
            return View();
        }

        public string Artist(string artist)
        {
            string val = artist;

            return val;
        }
        
    }
}