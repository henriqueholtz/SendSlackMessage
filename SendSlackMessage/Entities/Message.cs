﻿using FluentValidation;
using SendSlackMessage.Enums;
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
        [JsonPropertyName("mrkdwn")]
        public bool MarkDown { get; private set; }
        private string _responseType;

        [JsonPropertyName("response_type")]
        private string ResponseType { get => string.IsNullOrWhiteSpace(_responseType) ? "ephemeral" : _responseType; set => _responseType = value; }

        public Message(string channel, string username, string iconEmoji, string iconUrl, string text, bool markdown = true)
        {
            Channel = channel;
            Username = username;
            IconEmoji = iconEmoji;
            IconUrl = iconUrl;
            Text = text;
            MarkDown = markdown;
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
