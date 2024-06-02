using CarInsurance.BotAssistant.Application.Contracts.Telegram;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace CarInsurance.BotAssistant.Telegram;

public class TgBotClient : ITgBotClient
{
    private readonly ILogger<TgBotClient> _logger;
    private readonly ITelegramBotClient _telegramBotClient;

    public TgBotClient(
        ILogger<TgBotClient> logger,
        ITelegramBotClient telegramBotClient)
    {
        _logger = logger;
        _telegramBotClient = telegramBotClient;
    }

    public void StartReceiving(IUpdateHandler updateHandler)
    {
        _logger.LogInformation("TgBotClient.StartReceiving started");
        try
        {
            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions();
            _telegramBotClient.StartReceiving(
                updateHandler,
                receiverOptions,
                cancellationToken
            );
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "TgBotClient.StartReceiving error occured");
            throw;
        }
        finally
        {
            _logger.LogInformation("TgBotClient.StartReceiving finished");
        }
    }

    //public async Task<long> SendMenu(long chatId, MenuData data)
    //{
    //    // delete messages in background as it can take long time
    //    TryClearChatExceptMenu(chatId);
    //    var existingMenuMsg = await _storage.GetMenuMessage(chatId);
    //    var needToSendMenu = true;
    //    if (existingMenuMsg != null)
    //    {
    //        var edited = await TryEditMessage(
    //            chatId,
    //            existingMenuMsg.MessageId,
    //            data.Text,
    //            MapKeyboard(data.Keyboard));
    //        if (!edited)
    //        {
    //            await TryDeleteMessage(chatId, existingMenuMsg.MessageId);
    //        }

    //        needToSendMenu = !edited;
    //    }

    //    if (!needToSendMenu)
    //    {
    //        return existingMenuMsg!.MessageId;
    //    }

    //    var sentMenuMsg = await _telegramBotClient.SendTextMessageAsync(
    //    chatId,
    //        data.Text,
    //        ParseMode.Html,
    //        replyMarkup: MapKeyboard(data.Keyboard));
    //    //await _storage.SaveMessage(new TgMessage(
    //    //    ChatId: chatId,
    //    //    DateTime: sentMenuMsg.Date,
    //    //    MessageId: sentMenuMsg.MessageId,
    //    //    Purpose: TgMessagePurpose.Menu,
    //    //    SenderId: sentMenuMsg.From!.Id,
    //    //    Type: (TgMessageType)sentMenuMsg.Type,
    //    //    Text: data.Text
    //    //));
    //    return sentMenuMsg.MessageId;
    //}

    //private static InlineKeyboardMarkup MapKeyboard(TgKeyboard keyboardDto)
    //{
    //    var keys = new List<List<InlineKeyboardButton>>();
    //    foreach (var rowDto in keyboardDto.Rows)
    //    {
    //        var row = rowDto
    //            .Select(btn =>
    //                InlineKeyboardButton.WithCallbackData(btn.Text, btn.Callback))
    //            .ToList();
    //        keys.Add(row);
    //    }

    //    var keyboard = new InlineKeyboardMarkup(keys);
    //    return keyboard;
    //}

    public async Task<long> SendText(long chatId, string text)
    {
        var me = await _telegramBotClient.GetMeAsync();
        Console.WriteLine(me);
        var message = await _telegramBotClient.SendTextMessageAsync(new ChatId(chatId),
                "text",
                null,
                ParseMode.Html);
        //await _storage.SaveMessage(new TgMessage(
        //    ChatId: chatId,
        //    DateTime: message.Date,
        //    MessageId: message.MessageId,
        //    Purpose: TgMessagePurpose.Message,
        //    SenderId: message.From!.Id,
        //    Type: (TgMessageType)message.Type,
        //    Text: text
        //));
        //return message.MessageId;
        return 1;
    }

    //public async Task<long> SendTextUnmanaged(long chatId, string text)
    //{
    //    var message =
    //        await _telegramBotClient.SendTextMessageAsync(new ChatId(chatId),
    //            text,
    //            ParseMode.Html);
    //    return message.MessageId;
    //}
}
