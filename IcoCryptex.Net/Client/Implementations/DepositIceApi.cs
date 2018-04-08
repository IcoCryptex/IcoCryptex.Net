using System.Threading.Tasks;
using IcoCryptex.Net.Objects;
using IcoCryptex.Net.Objects.Raw;

namespace IcoCryptex.Net.Client.Implementations
{
    public sealed class DepositIceApi
    {
        private readonly IceClient _client;

        internal DepositIceApi(IceClient client)
        {
            _client = client;
        }

        public string GetAddress(IceSymbol symbol) => GetAddressAsync(symbol).Result;
        public async Task<string> GetAddressAsync(IceSymbol symbol)
        {
            var raw = await _client.ApiUtility.Get<IceDepositAddressRaw>($"/deposit/{symbol.Name}");
            return raw.Address;
        }

        public IceWalletTransaction[] GetPending() => GetPendingAsync().Result;
        public Task<IceWalletTransaction[]> GetPendingAsync()
        {
            return _client.ApiUtility.Get<IceWalletTransaction[]>($"/deposit/pending");
        }

        public IceWalletTransaction[] GetHistory() => GetHistoryAsync().Result;
        public Task<IceWalletTransaction[]> GetHistoryAsync()
        {
            return _client.ApiUtility.Get<IceWalletTransaction[]>($"/deposit/history");
        }
    }
}