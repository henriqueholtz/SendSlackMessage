using SendSlackMessage.Entities;
using System;
using System.Configuration;

//Get or Create your webHookUrl here: https://my.slack.com/services/new/incoming-webhook/
//Some instructions here: https://github.com/henriqueholtz/SendSlackMessage/blob/master/README.md
namespace SendSlackMessage.Demo
{
    internal static class Program
    {
        #region static variables
        private static readonly string _webHookUrl = ConfigurationManager.AppSettings.Get("WebHookUrl").ToString(); //PUT YOUR WEB HOOK URL IN App.Config[WebHookUrl] 
        private static string _username = ConfigurationManager.AppSettings.Get("UserName").ToString(); //PUT YOUR USER IN App.Config[UserName]
        private static readonly string _iconUrl = ConfigurationManager.AppSettings.Get("IconUrl").ToString(); //PUT YOUR USER IN App.Config[IconUrl] - Optional
        private static string _channelOverride = ConfigurationManager.AppSettings.Get("Channel").ToString(); //PUT YOUR USER IN App.Config[Channel] - Optional (to override channel of web-hook)
        #endregion
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Demo of ** SendSlackMessage **");
            Console.WriteLine("Initializing demo...");
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

                #region select mode
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
                        message = MenuOptions();
                    }

                    if (message != null)
                    {
                        message.SetChannel(_channelOverride); //To override channel
                        Console.WriteLine("Sending message to Slack...");
                        var response = client.Send(message);
                        Console.WriteLine(response.Result.ToString());
                    }
                }
                #endregion
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

        static Message MenuOptions()
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("---            Menu             ---");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("1- Simple option");

            string option = Console.ReadLine();
            int opt = 0;
            while (!int.TryParse(option.Trim(), out opt) || opt <= 0)
            {
                Console.Write("Invalid number. Try again: ");
                option = Console.ReadLine();
            }
            return Option(opt);
        }

        static Message Option(int option)
        {
            Console.WriteLine($"Selected: {option}");
            switch (option)
            {
                case 1:
                    return new Message("override after", "SendSlackMessage - 1", Emoji.Coffee, "", "This is a first option predefined.");
                //case 2:
                //    break;
                default:
                    return new Message("override after", "SendSlackMessage - Default", Emoji.Bomb, "", "This is a default option predefined.");
            }
        }
    }
}
