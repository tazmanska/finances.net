using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finances.Net.Models;

namespace Finances.Net.Services
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();
        Account Get(string id);
        void Delete(string id);
    }

    class AccountService : IAccountService
    {
        private readonly List<Account> _accounts = new List<Account>
        {
            new Account() { Id = "1", Amount = 100m, Name = "Wallet" },
            new Account() { Id = "2", Amount = 99.5m, Name = "Bank Account" }
        };

        public IEnumerable<Account> GetAccounts()
        {
            return _accounts;
        }

        public Account Get(string id)
        {
            return GetAccounts().FirstOrDefault(x => x.Id == id);
        }

        public void Delete(string id)
        {
            var account = Get(id);
            if (account != null)
            {
                _accounts.Remove(account);
            }
        }
    }
}
