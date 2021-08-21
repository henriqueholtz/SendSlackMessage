using SendSlackMessage.Entities;
using SendSlackMessage.Exceptions;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace SendSlackMessage
{
    public class SsmClient
    {
        private static Uri WebHookUri { get; set; }

        public SsmClient(string webHookUrl)
        {
            CreateUri(webHookUrl);
        }

        public Task<string> Send(Message message)
        {
            try
            {
                var requestBody = JsonSerializer.Serialize(message);
                return SsmRequest.Process(WebHookUri, requestBody);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public Task<string> SendAsync(Message message)
        {
            try
            { 
                var requestBody = JsonSerializer.Serialize(message);
                return SsmRequest.ProcessAsync(WebHookUri, requestBody);
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void CreateUri(string url)
        {
            Uri webHookUri;
            if (Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute) && Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out webHookUri) && webHookUri.IsWellFormedOriginalString())
            {
                WebHookUri = webHookUri;
                return;
            }
            throw new InvalidUrlException(url);
        }
    }
}
