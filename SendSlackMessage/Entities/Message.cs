using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendSlackMessage.Entities
{
    public class Message
    {
        public string Channel { get; private set; }
        public string Username { get; private set; }
        public string IconEmoji { get; private set; }
        public string IconUrl { get; private set; }
        public string Text { get; private set; }

        public Message(string channel, string username, string iconEmoji, string iconUrl, string text)
        {
            Channel = channel;
            Username = username;
            IconEmoji = iconEmoji;
            IconUrl = iconUrl;
            Text = text;
        }
    }
}
