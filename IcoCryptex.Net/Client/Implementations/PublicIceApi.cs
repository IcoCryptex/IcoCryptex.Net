using System.Threading.Tasks;
using IcoCryptex.Net.Objects;
using IcoCryptex.Net.Objects.Raw;

namespace IcoCryptex.Net.Client.Implementations
{
    public sealed class PublicIceApi
    {
        private readonly IceClient _client;

        internal PublicIceApi(IceClient client)
        {
            _client = client;
        }

        public IceSymbol[] GetSymbols() => GetSymbolsAsync().Result;
        public Task<IceSymbol[]> GetSymbolsAsync()
        {
            return _client.ApiUtility.Get<IceSymbol[]>("/symbols", false);
        }

        public IceSymbolPair[] GetPairs() => GetPairsAsync().Result;
        public Task<IceSymbolPair[]> GetPairsAsync()
        {
            return _client.ApiUtility.Get<IceSymbolPair[]>("/pairs", false);
        }

        public IceTicker GetTicker(IceSymbolPair symbolPair) => GetTickerAsync(symbolPair).Result;
        public Task<IceTicker> GetTickerAsync(IceSymbolPair symbolPair)
        {
            return _client.ApiUtility.Get<IceTicker>($"/ticker/{symbolPair.Name}", false);
        }

        public IceDepth GetDepth(IceSymbolPair symbolPair) => GetDepthAsync(symbolPair).Result;
        public async Task<IceDepth> GetDepthAsync(IceSymbolPair symbolPair)
        {
            return await _client.ApiUtility.Get<IceDepthRaw>($"/depth/{symbolPair.Name}", false);
        }

        public IceOrderTransaction[] GetHistory(IceSymbolPair symbolPair) => GetHistoryAsync(symbolPair).Result;
        public async Task<IceOrderTransaction[]> GetHistoryAsync(IceSymbolPair symbolPair)
        {
            return await _client.ApiUtility.Get<IceOrderTransaction[]>($"/history/{symbolPair.Name}", false);
        }

        public decimal GetSuggestedPrice(IceSymbolPair symbolPair) => GetSuggestedPriceAsync(symbolPair).Result;
        public async Task<decimal> GetSuggestedPriceAsync(IceSymbolPair symbolPair)
        {
            return await _client.ApiUtility.Get<decimal>($"/pairs/suggestedprice/{symbolPair.Name}", false);
        }
    }
}