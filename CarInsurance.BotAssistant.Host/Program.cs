using CarInsurance.BotAssistant.Application.Contracts.Telegram;
using CarInsurance.BotAssistant.Application.Telegram;
using CarInsurance.BotAssistant.Domain.Telegram;
using CarInsurance.BotAssistant.Telegram;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;
using Telegram.Bot.Polling;

var botToken = "7454317978:AAE8FFjajo3PFSBiNtY1ZoHCofoUHV9ave8";
//var botToken = Environment.GetEnvironmentVariable("TG_BOT_TOKEN")
//    ?? throw new Exception("Unassigned value for TG_BOT_TOKEN env variable");

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddLogging();

        services
            .AddTransient<ITelegramBotClient>(_ => new TelegramBotClient(botToken));

        services
            .AddTransient<ITgBotClient, TgBotClient>()
            .AddTransient<ITelegramAppService, TelegramAppService>()
            .AddTransient<ITgBotClientAppProxy, TgBotClientAppProxy>()
            .AddTransient<TgBotDomainService>();

        services
            .AddTransient<IUpdateHandler, TgUpdateHandler>();
    }).Build();

var tgBotClient = host.Services.GetRequiredService<ITgBotClient>() as TgBotClient;
var updateHandler = host.Services.GetRequiredService<IUpdateHandler>();
tgBotClient?.StartReceiving(updateHandler);

await host.RunAsync();
//using (var dbContext = host.Services.GetService<>)
//{
//    dbContext.Database.Migrate();
//}
