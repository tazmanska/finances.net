using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Net.Models
{
    public class Account
    {
        public string Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
    }
}
