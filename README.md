# Love.Net.Services

This repo contains some Asp.Net Core common services abstraction, such as SMS sender, Email sender and App message push and so on. The ApiInvoker as the default implementation by invoking RESTful API.

[![Join the chat at https://gitter.im/lovedotnet/Love.Net.Services](https://badges.gitter.im/lovedotnet/Love.Net.Services.svg)](https://gitter.im/lovedotnet/Love.Net.Services?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)


# How to use

To install Love.Net.Services, run the following command in the Package Manager Console

`PM> Install-Package Love.Net.Services`

## Configure services

```C#
public void ConfigureServices(IServiceCollection services) {
    services.AddMvcCore().AddJsonFormatters(options => {
        options.ContractResolver = new DefaultContractResolver();
    });
    services.AddApiInvoker(options => {
        options.AppPushApiUrl = "http://localhost:11122/api/sender";
        options.EmailApiUrl = "http://localhost:11122/api/sms";
        options.SmsApiUrl = "http://localhost:11122/api/email";
        options.HeaderRetriever = (url) => {
            return new[] {
                        new Tuple<string, string>("xunit", "16b5d757-ad54-4fd7-979e-44b00ff97704")
                    };
        };
    });
}
```
