using IcoCryptex.Net.Client.Implementations;
using IcoCryptex.Net.InternalObjects;
using IcoCryptex.Net.Utility;

namespace IcoCryptex.Net.Client
{
    public sealed class IceClient
    {
        public PublicIceApi Public { get; }
        public AccountIceApi Account { get; }
        public DepositIceApi Deposit { get; }
        public WithdrawIceApi Withdraw { get; }
        public OrderIceApi Order { get; }

        internal readonly ApiIdentity Identity;
        internal readonly ApiUtil ApiUtility;

        public IceClient(string apiKey, string apiSecret, bool ssl = true, string host = "api.icocryptex.io", ushort port = 443)
        {
            Identity = new ApiIdentity(apiKey, apiSecret);
            ApiUtility = new ApiUtil(host, port, ssl, this);

            Public = new PublicIceApi(this);
            Account = new AccountIceApi(this);
            Deposit = new DepositIceApi(this);
            Withdraw = new WithdrawIceApi(this);
            Order = new OrderIceApi(this);
        }
    }
}
