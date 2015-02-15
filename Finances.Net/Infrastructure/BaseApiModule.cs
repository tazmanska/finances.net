using Finances.Web.Infrastructure.TempData;
using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Net.Infrastructure
{
    public abstract class BaseApiModule: NancyModule
    {
        public dynamic TempData { get; private set; }
        public BaseApiModule(string modulePath)
            : base(modulePath)
        {
            Initalize();
        }

        public BaseApiModule()
        {
            Initalize();
        }

        protected void SetSuccessMessage(string msg)
        {            
           this.TempData.SuccessMessage = msg;
        }

        protected void SetErrorMessage(string msg)
        {
            this.TempData.ErrorMesssage = msg;
        }
       

        private void Initalize()
        {
            this.Before += (ctx) => 
            { 
                this.TempData = new TempData(this.Context); 
                return null; 
            };                   
        }
    }
}
