using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebDevExamples.ServerWebTech.Controllers.api
{
    public class ExamplesController : ApiController
    {
        public List<string> Get()
        {
            return "This is an example of an web api controller".Split(' ').ToList();
        }

        public List<string> Post(string text)
        {
            return text.Split(' ').ToList();
        }

        public List<string> Put(string text)
        {
            return text.Split(' ').Select(s => "{" + s + "}").ToList();
        }

        public string Delete(string text)
        {
            return string.Join("}{", text.Split(' '));
        }
    }
}
