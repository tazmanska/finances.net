using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finances.Net.Services;
using Nancy;

namespace Finances.Net.Api
{
    public class AccountApi : NancyModule
    {
        private readonly IAccountService _accountService = null;

        public AccountApi(IAccountService accountService)
            : base("/api")
        {
            _accountService = accountService;

            Get["/account"] = _ => Response.AsJson(_accountService.GetAccounts());

            Get["/account/{id}"] = _ =>
            {
                var account = _accountService.Get(_.id.ToString());
                return account == null ? HttpStatusCode.NotFound : Response.AsJson((object)account);
            };
            
            Post["/account"] = _ => "add new account";
            
            Put["/account/{id}"] = _ => "update account " + _.id.ToString();
            
            Delete["/account/{id}"] = _ =>
            {
                var account = _accountService.Get(_.id.ToString());
                if (account == null)
                {
                    return HttpStatusCode.NotFound;
                }
                _accountService.Delete(_.id.ToString());
                return HttpStatusCode.OK;
            };
        }
    }
}
