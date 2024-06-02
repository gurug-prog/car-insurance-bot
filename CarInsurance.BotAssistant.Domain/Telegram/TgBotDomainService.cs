using Microsoft.Extensions.Logging;

namespace CarInsurance.BotAssistant.Domain.Telegram;

public class TgBotDomainService
{
    private readonly ILogger<TgBotDomainService> _logger;
    private readonly ITgBotClientAppProxy _tgBotClientProxy;

    public TgBotDomainService(
        ILogger<TgBotDomainService> logger,
        ITgBotClientAppProxy tgBotClientProxy)
    {
        _logger = logger;
        _tgBotClientProxy = tgBotClientProxy;
    }

    public async Task Hello(long chatId, string text)
    {
        _logger.LogInformation("Start");
        await Task.Delay(100);
        await _tgBotClientProxy.SendText(chatId, text);
        _logger.LogInformation("End");
    }
}
