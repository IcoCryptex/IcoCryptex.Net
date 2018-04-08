using System.Collections.Generic;
using System.Threading.Tasks;
using IcoCryptex.Net.Objects;
using IcoCryptex.Net.Objects.Enums;
using IcoCryptex.Net.Objects.Util;

namespace IcoCryptex.Net.Client.Implementations
{
    public sealed class OrderIceApi
    {
        private readonly IceClient _client;

        internal OrderIceApi(IceClient client)
        {
            _client = client;
        }

        public Dictionary<string, List<IceOrder>> GetOpenOrders() => GetOpenOrdersAsync().Result;
        public Task<Dictionary<string, List<IceOrder>>> GetOpenOrdersAsync()
        {
            return _client.ApiUtility.Get<Dictionary<string, List<IceOrder>>>($"/order");
        }

        public IceOrder GetOrder(long orderId) => GetOrderAsync(orderId).Result;
        public Task<IceOrder> GetOrderAsync(long orderId)
        {
            return _client.ApiUtility.Get<IceOrder>($"/order/{orderId}");
        }

        public IceRequestResult DeleteOrder(long orderId) => DeleteOrderAsync(orderId).Result;
        public Task<IceRequestResult> DeleteOrderAsync(long orderId)
        {
            return _client.ApiUtility.Delete<IceRequestResult>($"/order/{orderId}");
        }

        public IceRequestResult CreateOrder(IceSymbolPair symbolPair, OrderType type, DecimalCast amount, DecimalCast price) => CreateOrderAsync(symbolPair, type, amount, price).Result;
        public Task<IceRequestResult> CreateOrderAsync(IceSymbolPair symbolPair, OrderType type, DecimalCast amount, DecimalCast price)
        {
            var data = new IceCreateOrder { Amount = amount, Price = price, Type = type };
            return _client.ApiUtility.Post<IceRequestResult>($"/order/{symbolPair.Name}", data);
        }

        public Dictionary<string, List<IceOrderTransaction>> GetOrderHistory(IceSymbolPair symbolPair = null) => GetOrderHistoryAsync(symbolPair).Result;
        public Task<Dictionary<string, List<IceOrderTransaction>>> GetOrderHistoryAsync(IceSymbolPair symbolPair = null)
        {
            var route = symbolPair == null ? $"/history" : $"/history/{symbolPair.Name}";
            return _client.ApiUtility.Get<Dictionary<string, List<IceOrderTransaction>>>(route);
        }
    }
}