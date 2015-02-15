using Nancy.Bootstrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finances.Web.Infrastructure.TempData
{
    public class TempDataHandler : IApplicationStartup 
    {     
        public void Initialize(IPipelines pipelines)
        {
            pipelines.BeforeRequest += (ctx) => 
            {
                var storage = new TempDataStorage(ctx);
                storage.IncreaseLivingTime();
                storage.RemoveOldItems();      
                        
                return null;
            };

            pipelines.AfterRequest += (ctx) =>
            {
                var storage = new TempDataStorage(ctx);
                storage.Save();
            };
        }

        
    }
}