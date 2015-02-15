using Nancy;
using Nancy.Bootstrapper;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace Finances.Web.Infrastructure.TempData
{
    public class TempData : DynamicObject
    {
        private readonly NancyContext context;
        private readonly TempDataStorage storage;
        public TempData(NancyContext context)
        {
            this.context = context;
            this.storage = new TempDataStorage(context);
        }

        public dynamic this[string name]
        {
            get
            {                
                var item = GetItem(name);
                if (item == null)
                    return null;

                return item.Value;
            }
            set
            {
                SetItem(name, value);
            }
        }
      
        private TempDataItem GetItem(string name)
        {
            var tempDataList = storage.GetStorageList();         

            if (!tempDataList.ContainsKey(name))
                return null;
            
            return tempDataList[name];
        }

       

        private void SetItem(string name, dynamic value)
        {
            RemoveItem(name);
            var tempDataList = storage.GetStorageList();
            tempDataList[name] = new TempDataItem() { Value = value, Age = TempDataItemAge.New };            
        }

        private void RemoveItem(string name)
        {
            var item = GetItem(name);
            if (item == null)
                return;

            var list = storage.GetStorageList();
            list.Remove(name);
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = this[binder.Name];
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            this[binder.Name] = value;

            return true;
        }
      
    }
}