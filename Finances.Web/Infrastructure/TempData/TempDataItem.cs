using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finances.Web.Infrastructure.TempData
{
    [Serializable]
    public class TempDataItem
    {
        public dynamic Value { get; set; }
        public TempDataItemAge Age { get; set; }
    }
}