using Nancy.ViewEngines.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Net.Configuration
{
    public class RazorConfig : IRazorConfiguration
    {
        public IEnumerable<string> GetAssemblyNames()
        {
            yield return "Finances.Net";
            yield return "Finances.Web";
        }

        public IEnumerable<string> GetDefaultNamespaces()
        {
            yield return "Finances.Net.Models";            
        }

        public bool AutoIncludeModelNamespace
        {
            get { return true; }
        }
    }
}
