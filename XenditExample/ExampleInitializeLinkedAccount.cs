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

    class ExampleInitializeLinkedAccount
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            NetworkClient networkClient = new NetworkClient(httpClient);
            XenditConfiguration.RequestClient = networkClient;
            XenditConfiguration.ApiKey = "xnd_development_...";

            try
            {
                InitializedLinkedAccountParameter parameter = new InitializedLinkedAccountParameter
                {
                    CustomerId = "customer-id",
                    ChannelCode = LinkedAccountEnum.ChannelCode.DcBri,
                    Properties = new LinkedAccountProperties
                    {
                        AccountMobileNumber = "+62818555988",
                        CardLastFour = "4444",
                        CardExpiry = "06/24",
                        AccountEmail = "test@email.com",
                    },
                    Metadata = new Dictionary<string, object>()
                    {
                        { "example-metadata", "here is the example" },
                    },
                }

                InitializedLinkedAccount initializedLinkedAccount = await InitializedLinkedAccount.Initialize(parameter);
                Console.WriteLine(initializedLinkedAccount);
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
