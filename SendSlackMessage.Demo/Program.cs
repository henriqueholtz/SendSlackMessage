using SendSlackMessage.Entities;
using System;
using System.Configuration;

namespace SendSlackMessage.Demo
{
    internal static class Program
    {
        private static readonly string _webHookUrl = ConfigurationManager.AppSettings.Get("WebHookUrl").ToString(); //PUT YOUR WEB HOOK URL IN App.Config[WebHookUrl] 
        private static readonly string _username = ConfigurationManager.AppSettings.Get("UserName").ToString(); //PUT YOUR USER IN App.Config[UserName]
        private static readonly string _iconUrl = ConfigurationManager.AppSettings.Get("IconUrl").ToString(); //PUT YOUR USER IN App.Config[IconUrl] - Optional
        private static readonly string _channelOverride = ConfigurationManager.AppSettings.Get("Channel").ToString(); //PUT YOUR USER IN App.Config[Channel] - Optional (to override channel of web-hook)
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing demo...");
            //Get or Create your webHookUrl here: https://my.slack.com/services/new/incoming-webhook/
            //Some instructions here: https://github.com/henriqueholtz/SendSlackMessage/blob/master/README.md
            try
            {
                var client = new SsmClient(_webHookUrl);
                Console.WriteLine("Write the text and press Enter to send to Slack:");
                string text = Console.ReadLine();

                var message = new Message(_channelOverride, _username, Emoji.Coffee, _iconUrl, text);
                Console.WriteLine("Sending message to Slack...");

                var response = client.Send(message);
                Console.WriteLine(response.Result.ToString());
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error ocurred: {ex}");
            }
            Console.ReadLine();
        }
    }
}
