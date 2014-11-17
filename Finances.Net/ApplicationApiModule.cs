using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Nancy.Conventions;
using Nancy.TinyIoc;

namespace Finances.Net
{
    public class ApplicationApiModule : NancyModule
    {
        public ApplicationApiModule()
        {
            Get["/"] = o => View["index.html"];

            Get["/Exit"] = o =>
            {
                Program.Exit();
                return Response.AsJson(new {exit = true});
            };

            Get["/Onet"] = o => Response.AsRedirect("http://onet.pl");
        }
    }
}
