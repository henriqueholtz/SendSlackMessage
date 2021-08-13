using System;

namespace SendSlackMessage.Exceptions
{
    class InvalidUrlException : Exception
    {
        public InvalidUrlException(string url,string message = "This Url don't is valid. ") : base(message + url)
        {
        }
    }
}
