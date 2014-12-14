using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebDevExamples.WebTech.Controllers.api
{
    public class ExamplesController : ApiController
    {
        public List<string> Get()
        {
            return "This is an example of a web api controller.".Split(' ').ToList();
        }

        public List<string> Post([FromBody]string text)
        {
            return text.Split(' ').ToList();
        }

        public List<string> Put([FromBody]string text)
        {
            return text.Split(' ').Select(s => "{" + s + "}").ToList();
        }

        public List<string> Delete([FromBody]string text)
        {
            return new List<string> { string.Join("}{", text.Split(' ')) };
        }
    }
}
