using NUnit.Framework;
using SendSlackMessage.Demo;
using SendSlackMessage.Entities;

namespace SendSlackMessage.Tests
{
    public class BasicTests
    {
        private static readonly string _webHookUrl = "";
        private static readonly SsmClient client = new SsmClient(_webHookUrl);
        
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void Test1(int option)
        {
            Message message = Options.GetOptionByCode(option);
            var response = client.Send(message);
            Assert.Pass("ok", response.Result);
        }
    }
}