using System.Threading.Tasks;
using IcoCryptex.Net.Objects;

namespace IcoCryptex.Net.Client.Implementations
{
    public sealed class AccountIceApi
    {
        private readonly IceClient _client;

        internal AccountIceApi(IceClient client)
        {
            _client = client;
        }

        public IceApiSetDetails GetApiSetInfo() => GetApiSetInfoAsync().Result;
        public Task<IceApiSetDetails> GetApiSetInfoAsync()
        {
            return _client.ApiUtility.Get<IceApiSetDetails>("/");
        }

        public IceAccountBalances GetAccountBalances() => GetAccountBalancesAsync().Result;
        public Task<IceAccountBalances> GetAccountBalancesAsync()
        {
            return _client.ApiUtility.Get<IceAccountBalances>("/balances");
        }

        public IceAccount GetAccountDetails() => GetAccountDetailsAsync().Result;
        public Task<IceAccount> GetAccountDetailsAsync()
        {
            return _client.ApiUtility.Get<IceAccount>("/account");
        }

        public IceAccountSecurity GetAccountSecurity() => GetAccountSecurityAsync().Result;
        public Task<IceAccountSecurity> GetAccountSecurityAsync()
        {
            return _client.ApiUtility.Get<IceAccountSecurity>("/security");
        }
    }
}