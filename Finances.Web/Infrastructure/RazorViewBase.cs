using Nancy.ViewEngines;
using Nancy.ViewEngines.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finances.Web.Infrastructure
{
    public abstract class RazorViewBase : RazorViewBase<dynamic> 
    { 
    
    }

    public abstract class RazorViewBase<TModel> : NancyRazorViewBase<TModel>, INancyRazorView
    {
        public dynamic TempData { get; private set; }

        public override void Initialize(RazorViewEngine engine, IRenderContext renderContext, object model)
        {
            base.Initialize(engine, renderContext, model);
            TempData = new TempData.TempData(renderContext.Context);
        }
    }
}