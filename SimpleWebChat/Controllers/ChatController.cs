using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleWebChat.Controllers
{
    public class ChatController : Controller
    {
        public ActionResult WebChat()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}