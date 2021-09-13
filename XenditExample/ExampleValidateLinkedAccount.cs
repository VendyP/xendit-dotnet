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

    class ExampleValidateLinkedAccount
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            NetworkClient networkClient = new NetworkClient(httpClient);
            XenditConfiguration.RequestClient = networkClient;
            XenditConfiguration.ApiKey = "xnd_development_...";

            try
            {
                string otpCode = "123456";
                string linkedAccountTokenId = "linked-account-token-id";

                ValidatedLinkedAccount validatedLinkedAccount = await ValidatedLinkedAccount.ValidateOtp(otpCode, linkedAccountTokenId);
                Console.WriteLine(validatedLinkedAccount);
            }
            catch (XenditException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
