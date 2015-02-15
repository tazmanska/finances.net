using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finances.Web.Infrastructure.TempData
{
    class TempDataStorage
    {
        const string TempDataListKey = "tempDataList";
        private readonly NancyContext nancyContext;
        public TempDataStorage(NancyContext nancyContext)
        {
            this.nancyContext = nancyContext;
        }

       
        public Dictionary<string, TempDataItem> GetStorageList()
        {                        
            var tempDataList = nancyContext.Request.Session[TempDataListKey] as Dictionary<string, TempDataItem>;
            if (tempDataList == null)
            {
                tempDataList = new Dictionary<string, TempDataItem>();
                nancyContext.Request.Session[TempDataListKey] = tempDataList;
            }               

            return tempDataList;
        }


        public void Save()
        {
            var newList = new Dictionary<string, TempDataItem>();
            foreach (var item in GetStorageList())
            {
                newList.Add(item.Key, item.Value);
            }
            nancyContext.Request.Session[TempDataListKey] = newList;
        }


        public void RemoveOldItems()
        {
            var tempDataList = GetStorageList();

            var toRemove = tempDataList.Where(x => x.Value.Age >= TempDataItemAge.Old).Select(x => x.Key).ToList();
            foreach (var keyToRemove in toRemove)
            {
                tempDataList.Remove(keyToRemove);
            }
        }

        public void IncreaseLivingTime()
        {
            var tempDataList = GetStorageList();
            foreach (var item in tempDataList)
            {
                item.Value.Age++;
            }
        }
    }
}