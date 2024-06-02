using CarInsurance.BotAssistant.Application.Contracts.Telegram;
using CarInsurance.BotAssistant.Domain.Telegram;

namespace CarInsurance.BotAssistant.Application.Telegram;

public class TelegramAppService : ITelegramAppService
{
    private readonly TgBotDomainService _tgBotDomainService;

    public TelegramAppService(TgBotDomainService tgBotDomainService)
    {
        _tgBotDomainService = tgBotDomainService;
    }

    public Task HandleCallbackQuery(TgCallbackQueryDto tgCallback)
    {
        throw new NotImplementedException();
    }

    public async Task HandleMessage(TgMessageDto msg)
    {
        await _tgBotDomainService.Hello(msg.ChatId, msg.Text);
    }

    public async Task HandleCommand(TgCommandDto command)
    {
        await _tgBotDomainService.Hello(command.ChatId, command.Command);
    }

    public Task HandleError(Exception error)
    {
        throw new NotImplementedException();
    }
}
