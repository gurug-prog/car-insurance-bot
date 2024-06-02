using CarInsurance.BotAssistant.Application.Contracts.Telegram;
using CarInsurance.BotAssistant.Telegram.ErrorProcessors;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using CarInsurance.BotAssistant.Telegram.UpdateProcessors;

namespace CarInsurance.BotAssistant.Telegram;

public class TgUpdateHandler : IUpdateHandler
{
    private readonly IDictionary<UpdateType, IUpdateProcessor> _updProcessorsMap;
    private readonly IErrorProcessor _errorProcessor;

    public TgUpdateHandler(ITelegramAppService telegramAppService)
    {
        _updProcessorsMap = new Dictionary<UpdateType, IUpdateProcessor>
        {
            { UpdateType.Message, new MessageUpdateProcessor(telegramAppService) },
            { UpdateType.CallbackQuery, new CallbackQueryUpdateProcessor() }
        };

        _errorProcessor = new DefaultErrorProcessor(/*telegramAppService*/);
    }

    public async Task HandleUpdateAsync(
        ITelegramBotClient botClient,
        Update update,
        CancellationToken cancellationToken)
    {
        try
        {
            await _updProcessorsMap[update.Type].ProcessAsync(update);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex);
        }
    }

    public async Task HandlePollingErrorAsync(
        ITelegramBotClient botClient,
        Exception exception,
        CancellationToken cancellationToken)
    {
        await _errorProcessor.ProcessAsync(exception);
    }
}
