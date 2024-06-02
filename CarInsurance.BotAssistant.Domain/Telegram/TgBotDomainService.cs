using Microsoft.Extensions.Logging;

namespace CarInsurance.BotAssistant.Domain.Telegram;

public class TgBotDomainService
{
    private readonly ILogger<TgBotDomainService> _logger;
    private readonly ITgBotClientAppProxy _tgBotClient;

    public TgBotDomainService(
        ILogger<TgBotDomainService> logger,
        ITgBotClientAppProxy tgBotClient)
    {
        _logger = logger;
        _tgBotClient = tgBotClient;
    }

    public async Task Hello(long chatId, string text)
    {
        _logger.LogInformation("Start");
        await Task.Delay(100);
        await _tgBotClient.SendText(chatId, text);
        _logger.LogInformation("End");
    }
}