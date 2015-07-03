using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDevExamples.WebTech.CSharp.Events;

namespace WebDevExamples.WebTech.Controllers
{
    public class EventsController : Controller
    {
        public ActionResult Index()
        {
            return View(new EventExamplesResult());
        }

        [HttpPost]
        public ActionResult Index(string name)
        {
            var eventExamples = new EventExamples();

            return View(new EventExamplesResult
            {
                SimpleEvent = eventExamples.SimpleEvent(name),
                CustomEvent = eventExamples.CustomEvent(name),
                CustomAccessors = eventExamples.CustomAccessors(name),
                EventHandlerEventArgs = eventExamples.EventHandlerEventArgs(name)
            });
        }
    }
}