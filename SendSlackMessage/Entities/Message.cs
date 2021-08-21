using SendSlackMessage.Enums;
using SendSlackMessage.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace SendSlackMessage.Entities
{
    public class Message
    {
        [JsonPropertyName("channel")]
        public string Channel { get; private set; }

        [JsonPropertyName("username")]
        public string Username { get; private set; }

        [JsonPropertyName("icon_emoji")]
        public string IconEmoji { get; private set; }

        [JsonPropertyName("icon_url")]
        public string IconUrl { get; private set; }

        [JsonPropertyName("text")]
        public string Text { get; private set; }

        [JsonPropertyName("mrkdwn")]
        public bool MarkDown { get; private set; } = true;
        private string _responseType;

        [JsonPropertyName("response_type")]
        private string ResponseType { get => string.IsNullOrWhiteSpace(_responseType) ? "ephemeral" : _responseType; set => _responseType = value; }

        [JsonPropertyName("attachments")]
        public List<Attachment> Attachments { get; private set; } = new List<Attachment>();


        /* Constructors */
        public Message(string username, string text) 
        {
            Username = username;
            Text = text;
        }
        public Message(string channelOverride, string username, string text)
        {
            Username = username;
            Text = text;
            Channel = channelOverride;
        }
        public Message(string channelOverride, string username, string iconEmoji, string iconUrl, string text, bool markdown = true)
        {
            Channel = channelOverride;
            Username = username;
            IconEmoji = iconEmoji;
            IconUrl = iconUrl;
            Text = text;
            MarkDown = markdown;
        }
        public Message(string channelOverride, string text, string username, List<Attachment> attachments)
        {
            Text = text;
            Username = username;
            Channel = channelOverride;
            if (attachments?.Any() == true) Attachments = attachments;
        }
        public Message(string channelOverride, string text, List<Attachment> attachments)
        {
            Text = text;
            Channel = channelOverride;
            if (attachments?.Any() == true) Attachments = attachments;
        }


        /* Methods */
        public Message SetText(string text)
        {
            Text = text;
            return this;
        }
        public Message SetChannel(string channelOverride = "")
        {
            Channel = channelOverride;
            return this;
        }
        public Message SetUserWithEmoji(string username, string iconEmoji)
        {
            Username = username;
            IconEmoji = iconEmoji;
            return this;
        }
        public Message SetUserWithIconUrl(string username, string iconUrl)
        {
            Username = username;
            IconUrl = iconUrl;
            return this;
        }
        public Message SetResponseType(EnumResponseType responseType)
        {
            ResponseType = responseType.ToString();
            return this;
        }
        public Message AddAttachment(Attachment attachment)
        {
            Attachments.Add(attachment);
            return this;
        }
        public Message AddAttachments(IEnumerable<Attachment> attachments)
        {
            Attachments.AddRange(attachments);
            return this;
        }
        public Message SetMarkdwon(bool markdown)
        {
            MarkDown = markdown;
            return this;
        }
        public Message ClearAttachments()
        {
            Attachments.Clear();
            return this;
        }
    }
}
