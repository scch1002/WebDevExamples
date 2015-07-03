using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDevExamples.WebTech.CSharp.Events
{
    public class EventExamples
    {
        private delegate string CustomDelegate(string value);
        private event Func<string, string> _simpleEvent;
        private event CustomDelegate _customEvent;
        private Func<string, string> _customAccessors;
        private event Func<string, string> customAccessors
        {
            add {
                _customAccessors += value;
            }
            remove {
                _customAccessors -= value;
            }
        }

        private event EventHandler<ExampleEventArgs> _eventHandler;
        
        public string SimpleEvent(string value)
        {
            _simpleEvent = Hello;

            return _simpleEvent(value);
        }

        public string CustomEvent(string value)
        {
            _customEvent = Hello;

            return _customEvent(value);
        }

        public string CustomAccessors(string value)
        {
            customAccessors += (name) => "No Thank you, " + name;
            customAccessors += Hello;
            customAccessors += (name) => "Another method, " + name;

            return _customAccessors(value);
        }

        public string EventHandlerEventArgs(string value)
        {
            var response = string.Empty;

            _eventHandler = (object sender, ExampleEventArgs exampleEventArgs) => response = Hello(exampleEventArgs.Name);

            _eventHandler(this, new ExampleEventArgs(value));

            return response;
        }

        private string Hello(string name)
        {
            return "Hello, " + name;
        }
    }
}