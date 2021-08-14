using SendSlackMessage.Entities;
using System;

namespace SendSlackMessage.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing demo...");

            //Get your webHookUrl here: https://my.slack.com/services/new/incoming-webhook/
            var client = new SsmClient("-- PUT YOUR WEB HOOK URL HERE --");

            var message = new Message("UserName", "", "", "Text Demo.");
            Console.WriteLine("Sending message to Slack...");

            var response = client.Send(message);
            Console.WriteLine(response.Result.ToString());
            Console.ReadLine();
        }
    }
}
