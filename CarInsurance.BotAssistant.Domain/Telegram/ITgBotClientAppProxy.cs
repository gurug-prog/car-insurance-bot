namespace CarInsurance.BotAssistant.Domain.Telegram;

public interface ITgBotClientAppProxy
{
    Task<long> SendText(long chatId, string text);
}
