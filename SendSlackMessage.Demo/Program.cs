using SendSlackMessage.Entities;
using System;
using System.Configuration;

namespace SendSlackMessage.Demo
{
    class Program
    {
        private static readonly string _webHookUrl = ConfigurationManager.AppSettings.Get("WebHookUrl").ToString(); //PUT YOUR WEB HOOK URL IN App.Config[WebHookUrl] 
        private static readonly string _username = ConfigurationManager.AppSettings.Get("UserName").ToString(); //PUT YOUR USER IN App.Config[UserName]
        private static readonly string _iconEmoji = ConfigurationManager.AppSettings.Get("IconEmoji").ToString(); //PUT YOUR USER IN App.Config[IconEmoji] - Optional
        private static readonly string _iconUrl = ConfigurationManager.AppSettings.Get("IconUrl").ToString(); //PUT YOUR USER IN App.Config[IconUrl] - Optional
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing demo...");

            //Get your webHookUrl here: https://my.slack.com/services/new/incoming-webhook/
            var client = new SsmClient(_webHookUrl);
            Console.WriteLine("Write the text and press Enter to send to Slack:");
            string text = Console.ReadLine();

            var message = new Message(_username, _iconEmoji, _iconUrl, text);
            Console.WriteLine("Sending message to Slack...");

            var response = client.Send(message);
            Console.WriteLine(response.Result.ToString());
            Console.ReadLine();
        }
    }
}
