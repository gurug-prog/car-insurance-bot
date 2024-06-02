using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarInsurance.BotAssistant.Application.Contracts.Telegram;
using CarInsurance.BotAssistant.Domain.Shared.Telegram;
using Telegram.Bot.Types;

namespace CarInsurance.BotAssistant.Telegram.UpdateProcessors;

public class MessageUpdateProcessor : IUpdateProcessor
{
    private readonly ITelegramAppService _telegramAppService;
    
    public MessageUpdateProcessor(
        ITelegramAppService telegramAppService)
    {
        _telegramAppService = telegramAppService;
    }

    public async Task ProcessAsync(Update update)
    {
        var msg = update.Message!;
        // Todo ...

        if (msg.From is null)
        {
            return;
        }

        //var msgText = msg.Caption ?? msg.Text ?? msg.Document?.FileName ?? msg.Audio?.Title;


        //await _storage.SaveMessage(new TgMessage(
        //    ChatId: msg.Chat.Id,
        //    DateTime: msg.Date,
        //    MessageId: msg.MessageId,
        //    Purpose: TgMessagePurpose.Message,
        //    SenderId: msg.From!.Id,
        //    Type: (TgMessageType)msg.Type,
        //    Text: msgText
        //));
        //var userState =
        //    await _storage.GetUserState(msg.Chat.Id, msg.From.Id);
        
        var isCommand = msg.Text?.StartsWith('/') == true;
        if (isCommand)
        {
            var command = new string(msg.Text!.Skip(1).ToArray());
            if (command == string.Empty)
            {
                return;
            }

            await _telegramAppService.HandleCommand(new TgCommandDto
            {
                ChatId = msg.Chat.Id,
                FromId = msg.From.Id,
                Date = msg.Date,
                Command = command
            });
        }
        else
        {
            await _telegramAppService.HandleMessage(new TgMessageDto
            {
                MessageId = msg.MessageId,
                ChatId = msg.Chat.Id,
                FromId = msg.From.Id,
                Date = msg.Date,
                Text = msg.Text,
                Type = (TgMessageType)msg.Type
            });
        }
    }
}
