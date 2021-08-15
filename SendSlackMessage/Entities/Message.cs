using FluentValidation;
using SendSlackMessage.Helpers;
using System.Collections.Generic;
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

        public Message(string channel, string username, string iconEmoji, string iconUrl, string text)
        {
            Channel = channel;
            Username = username;
            IconEmoji = iconEmoji;
            IconUrl = iconUrl;
            Text = text;
        }
    }

    #region Validator
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(msg => new List<KeyValuePair<string, string>> { 
                new KeyValuePair<string, string>(nameof(msg.Username), msg.Username),
                new KeyValuePair<string, string>(nameof(msg.Text), msg.Text)
                }).Custom((list, context) =>
            {
                KeyValuePair<bool, string> customResult = SsmHelper.ValidateStrings(list);
                if (!customResult.Key) context.AddFailure(customResult.Value);
            });
        }
    }
    #endregion
}
