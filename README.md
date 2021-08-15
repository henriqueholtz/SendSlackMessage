# <img align="center" alt="Henrique-Csharp" height="40" width="40" src="./SendSlackMessage/logo.ico" /> SendSlackMessage 

A package .net to send slack message by webhooks

- Made with .net 5.0;
- Using `System.text.json` (don't used NetownSoft.json);
- Using FluentValidation;

[Nuget Package](https://www.nuget.org/packages/SendSlackMessage/)

[Create your web hook from Slack here](https://my.slack.com/services/new/incoming-webhook/)

## Demo

- **How to view the demo ?**

1. Create or get you web hook url from Slack (Access the link above)

2. Only clone this repository, configure the keys in `app.config`, build and execute the console application `SendSlackMessage.Demo`


## Use cases (Examples)
- **Add link:** `<https://myurl.example.com|Click here or text>`;
- **Break line:** `\n`;
- **@channel notification:** `<!channel> Hello channel!`; 
- **@group notification:** `<!group> Hello Group!`; 
- **@here notification:** `<!here> Hello!`; 
- **@here notification:** `<!everyone> Hello Everyone!`; 
- **Override channel:** Send property `Channel` to override channel of web-hook
