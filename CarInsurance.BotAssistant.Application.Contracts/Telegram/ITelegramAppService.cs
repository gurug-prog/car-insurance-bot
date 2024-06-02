namespace CarInsurance.BotAssistant.Application.Contracts.Telegram;

public interface ITelegramAppService
{
    Task HandleCallbackQuery(TgCallbackQueryDto tgCallback);
    Task HandleMessage(TgMessageDto msg);
    Task HandleCommand(TgCommandDto command);
    Task HandleError(Exception error);
}
