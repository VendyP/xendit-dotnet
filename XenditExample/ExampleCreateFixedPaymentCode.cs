namespace XenditExample
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xendit.net;
    using Xendit.net.Model;
    using Xendit.net.Network;
    using Xendit.net.Exception;
    using Xendit.net.Struct;
    using Xendit.net.Enum;

    class ExampleCreateFixedPaymentCode
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            NetworkClient networkClient = new NetworkClient(httpClient);
            XenditConfiguration.RequestClient = networkClient;
            XenditConfiguration.ApiKey = "xnd_development_...";

            try
            {
                CreateFixedPaymentCodeParameter parameter = new CreateFixedPaymentCodeParameter
                {
                    ReferenceId = "demo_payment_code_id",
                    ChannelCode = RetailOutletEnum.ChannelCode.SevenEleven,
                    CustomerName = "Rika Sutanto",
                    Amount = 50,
                    Currency = RetailOutletEnum.Currency.PHP,
                    Market = RetailOutletEnum.Country.Philippines,
                    PaymentCode = "12345678",
                    Description = "Example payment code",
                };

                FixedPaymentCode fixedPaymentCode = await RetailOutlet.CreatePaymentCode(parameter);
                Console.WriteLine(fixedPaymentCode);
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
