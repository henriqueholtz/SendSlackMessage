using FluentValidation;
using SendSlackMessage.Helpers;
using System.Collections.Generic;

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

    #region Validator
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(msg => new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>(nameof(msg.Channel), msg.Channel) }).Custom((list, context) =>
            {
                KeyValuePair<bool, string> customResult = SsmHelper.ValidateStrings(list);
                if (!customResult.Key) context.AddFailure(customResult.Value);
            });
        }
    }
    #endregion
}
