using CarInsurance.BotAssistant.Application.Contracts.Telegram;
using CarInsurance.BotAssistant.Domain.Telegram;
using Microsoft.Extensions.Logging;

namespace CarInsurance.BotAssistant.Application.Telegram;

public class TgBotClientAppProxy : ITgBotClientAppProxy
{
    private readonly ILogger<TgBotClientAppProxy> _logger;
    private readonly ITgBotClient _tgBotClient;

    public TgBotClientAppProxy(
        ILogger<TgBotClientAppProxy> logger,
        ITgBotClient tgBotClient)
    {
        _logger = logger;
        _tgBotClient = tgBotClient;
    }

    public async Task<long> SendText(long chatId, string text)
    {
        _logger.LogInformation("TgBotClientAppProxy.SendText started");
        try
        {
            await _tgBotClient.SendText(chatId, text);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "TgBotClientAppProxy.SendText error occured");
            throw;
        }
        finally
        {
            _logger.LogInformation("TgBotClientAppProxy.SendText finished");
        }

        return 1;
    }
}
