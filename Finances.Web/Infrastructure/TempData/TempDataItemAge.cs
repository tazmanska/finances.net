using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finances.Web.Infrastructure.TempData
{
    [Serializable]
    public enum TempDataItemAge
    {
        New = 1,
        Adult = 2,
        Old = 3,
    }
}