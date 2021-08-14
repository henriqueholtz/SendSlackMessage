using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SendSlackMessage
{
    internal static class SsmRequest
    {
        private static readonly HttpClient _client = new HttpClient();
        private const string MEDIATYPE = "application/json";
        internal static async Task<string> Process(Uri webHookUri, string requestBody)
        {
            try
            {
                using (var request = new HttpRequestMessage(HttpMethod.Post, webHookUri))
                {
                    request.Content = new StringContent(requestBody, Encoding.UTF8, MEDIATYPE);
                    var response = _client.SendAsync(request).GetAwaiter().GetResult();
                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                return "Error when posting to the web hook url. Error Message: " + ex.Message;
            }
        }

        internal static async Task<string> ProcessAsync(Uri webHookUri, string requestBody)
        {
            try
            {
                using (var request = new HttpRequestMessage(HttpMethod.Post, webHookUri))
                {
                    using (var content = new StringContent(requestBody, Encoding.UTF8, MEDIATYPE))
                    {
                        request.Content = content;
                        using (var response = await _client.SendAsync(request).ConfigureAwait(false))
                            return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    }
                }
            }
            catch(Exception ex)
            {
                return "Error when posting (async) to the web hook url. Error Message: " + ex.Message;
            }
        }
    }
}
