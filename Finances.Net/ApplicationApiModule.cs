using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Nancy.Conventions;
using Nancy.TinyIoc;
using Finances.Net.Infrastructure;

namespace Finances.Net
{
    public class ApplicationApiModule : BaseApiModule
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

            
            Get["/About"] = o => View["about.cshtml"];

            Post["/Donate"] = o =>
            {
                this.SetSuccessMessage("Thanks!");
                return Response.AsRedirect("/About");
            };
        }
    }
}
