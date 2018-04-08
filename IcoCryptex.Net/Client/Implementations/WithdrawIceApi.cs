using System;
using System.Threading.Tasks;
using IcoCryptex.Net.Objects;
using IcoCryptex.Net.Objects.Util;

namespace IcoCryptex.Net.Client.Implementations
{
    public sealed class WithdrawIceApi
    {
        private readonly IceClient _client;

        internal WithdrawIceApi(IceClient client)
        {
            _client = client;
        }

        public IceWithdrawalFeeQuote GetFeeQuote(IceSymbol symbol) => GetFeeQuoteAsync(symbol).Result;
        public Task<IceWithdrawalFeeQuote> GetFeeQuoteAsync(IceSymbol symbol)
        {
            return _client.ApiUtility.Get<IceWithdrawalFeeQuote>($"/withdraw/fee/{symbol.Name}");
        }

        public IceRequestResult Withdraw(IceSymbol symbol, string address, DecimalCast amount, Guid? feeQuoteId = null) => WithdrawAsync(symbol, address, amount, feeQuoteId).Result;
        public Task<IceRequestResult> WithdrawAsync(IceSymbol symbol, string address, DecimalCast amount, Guid? feeQuoteId = null)
        {
            var data = new IceCreateWithdrawalRequest { Address = address, Amount = amount, FeeQuoteId = feeQuoteId };
            return _client.ApiUtility.Post<IceRequestResult>($"/withdraw/{symbol.Name}", data);
        }

        public IceWalletTransaction[] GetPending() => GetPendingAsync().Result;
        public Task<IceWalletTransaction[]> GetPendingAsync()
        {
            return _client.ApiUtility.Get<IceWalletTransaction[]>($"/withdraw/pending");
        }

        public IceWalletTransaction[] GetHistory() => GetHistoryAsync().Result;
        public Task<IceWalletTransaction[]> GetHistoryAsync()
        {
            return _client.ApiUtility.Get<IceWalletTransaction[]>($"/withdraw/history");
        }
    }
}