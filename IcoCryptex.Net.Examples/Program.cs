using System.Linq;
using IcoCryptex.Net.Client;
using IcoCryptex.Net.Objects.Enums;

namespace IcoCryptex.Net.Examples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new IceClient("B3DA0C82906648FA9C2493D82A357C412AC6B5F7958948EBB1240E429EC75AD4", "32ECCDC8178B4CACB798388A501142F062588C55DD7047AEB79F798AD4C6EB92723FF91B552B494DA972D6F2F4316E30028F312C1A3A4F038147E375AC7C09FC");

            var symbols = client.Public.GetSymbols();
            var symbolPairs = client.Public.GetPairs();

            var btcTrx = symbolPairs.FirstOrDefault(pair => pair.Name == "btc-trx");

            var orderResult = client.Order.CreateOrder(btcTrx, OrderType.Buy, 1, 1);
        }
    }
}
