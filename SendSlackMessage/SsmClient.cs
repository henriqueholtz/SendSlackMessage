using SendSlackMessage.Entities;
using SendSlackMessage.Exceptions;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SendSlackMessage
{
    public class SsmClient
    {
        private static readonly HttpClient _client = new HttpClient();
        public string WebHookUri { get; set; }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public SsmClient(string webHookUrl)
        {
            Uri webHookUri;
            if (Uri.IsWellFormedUriString(webHookUrl, UriKind.RelativeOrAbsolute) && Uri.TryCreate(webHookUrl, UriKind.RelativeOrAbsolute, out webHookUri))
            {
                if (webHookUri.IsWellFormedOriginalString())
                    WebHookUri = webHookUrl;
            }
            throw new InvalidUrlException(webHookUrl);
        }

        public Task<string> Send(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
