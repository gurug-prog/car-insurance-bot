using Telegram.Bot.Types;

namespace CarInsurance.BotAssistant.Telegram.UpdateProcessors;

public interface IUpdateProcessor
{
    Task ProcessAsync(Update update);
}
