using SendSlackMessage.Entities;
using System;
using System.Configuration;

namespace SendSlackMessage.Demo
{
    internal static class Program
    {
        private static readonly string _webHookUrl = ConfigurationManager.AppSettings.Get("WebHookUrl").ToString(); //PUT YOUR WEB HOOK URL IN App.Config[WebHookUrl] 
        private static string _username = ConfigurationManager.AppSettings.Get("UserName").ToString(); //PUT YOUR USER IN App.Config[UserName]
        private static readonly string _iconUrl = ConfigurationManager.AppSettings.Get("IconUrl").ToString(); //PUT YOUR USER IN App.Config[IconUrl] - Optional
        private static string _channelOverride = ConfigurationManager.AppSettings.Get("Channel").ToString(); //PUT YOUR USER IN App.Config[Channel] - Optional (to override channel of web-hook)
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Demo of ** SendSlackMessage **");
            Console.WriteLine("Initializing demo...");
            //Get or Create your webHookUrl here: https://my.slack.com/services/new/incoming-webhook/
            //Some instructions here: https://github.com/henriqueholtz/SendSlackMessage/blob/master/README.md
            try
            {
                var client = new SsmClient(_webHookUrl);

                #region channel
                if (String.IsNullOrWhiteSpace(_channelOverride))
                {
                    Console.WriteLine("Couldn't possible get the channel from your config. Write (or leave blank to no override) and press Enter.");
                    _channelOverride = Console.ReadLine();

                }
                #endregion

                #region username
                Console.WriteLine();
                if (String.IsNullOrWhiteSpace(_username))
                {
                    Console.WriteLine("Couldn't possible get the username from your config. Write (or leave blank to no override) and press Enter.");
                    _username = Console.ReadLine();
                }
                #endregion

                for (var i = 0; i < 100; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine("----------------------------------------------------------------------------------------------");
                    Console.Write("Press key A to dynamic mode, or another to entry in the menu with some options: ");
                    var option = Console.ReadKey();
                    Console.WriteLine();
                    Message message = null;
                    if (option.Key == ConsoleKey.A)
                        message = DynamicMode();
                    else
                    {
                        Console.WriteLine("Loading menu of options....");
                        Console.WriteLine();
                        MenuOptions();
                    }

                    if (message != null)
                    {
                        Console.WriteLine("Sending message to Slack...");
                        var response = client.Send(message);
                        Console.WriteLine(response.Result.ToString());
                    }
                }
            }
            catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An error ocurred: {ex}");
                Console.ResetColor();
            }
            Console.ReadLine();
        }

        static Message DynamicMode()
        {
            Console.WriteLine("Entry in dynamic mode....");
            Console.WriteLine();

            Console.WriteLine("Write the text and press Enter to send to Slack:");
            string text = Console.ReadLine();
            return new Message(_channelOverride, _username, Emoji.Coffee, _iconUrl, text, true);
        }

        static void MenuOptions()
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("---            Menu             ---");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Option in construction, select dynamic mode please.");
            //Console.WriteLine("1- ");
            //Console.WriteLine("2- ");
        }
    }
}
