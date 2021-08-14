using FluentValidation.Results;
using SendSlackMessage.Entities;
using SendSlackMessage.Exceptions;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace SendSlackMessage
{
    public class SsmClient
    {
        private static readonly MessageValidator _validator = new MessageValidator();
        private List<ValidationFailure> _errors = new List<ValidationFailure>();
        private static Uri WebHookUri { get; set; }
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine();
                Console.WriteLine("Trying validate {Message}...");
                Message msg = new Message("", "username", "iconEmoji", "iconUrl", "");
                var results = _validator.Validate(msg);
                if (!results.IsValid) Console.WriteLine(results.ToString());
                Console.ReadLine();
            } while (true);
        }

        public SsmClient(string webHookUrl)
        {
            CreateUri(webHookUrl);
        }

        public Task<string> Send(Message message)
        {
            if (ValidateRequest(message))
            {
                var requestBody = JsonSerializer.Serialize(message);
                return SsmRequest.Process(WebHookUri, requestBody);
            }
            throw new Exception("Don't can Send message. Error of validation!");
        }

        public Task<string> SendAsync(Message message)
        {
            if (ValidateRequest(message))
            {
                var requestBody = JsonSerializer.Serialize(message);
                return SsmRequest.ProcessAsync(WebHookUri, requestBody);
            }
            throw new Exception("Don't can Send message (async). Error of validation!");
        }


        private bool ValidateRequest(Message message)
        {
            ValidationResult result = _validator.Validate(message);
            if (result.IsValid && Uri.IsWellFormedUriString(WebHookUri.AbsoluteUri, UriKind.RelativeOrAbsolute))
            {
                _errors.Clear();
                return true;
            }
            _errors.AddRange(result.Errors);
            return false;
        }

        private void CreateUri(string url)
        {
            Uri webHookUri;
            if (Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute) && Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out webHookUri) && webHookUri.IsWellFormedOriginalString())
            {
                WebHookUri = webHookUri;
                return;
            }
            throw new InvalidUrlException(url);
        }
    }
}
