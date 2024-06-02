using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace CarInsurance.BotAssistant.Telegram.UpdateProcessors;

public class CallbackQueryUpdateProcessor : IUpdateProcessor
{
    public async Task ProcessAsync(Update update)
    {
        var callback = update.CallbackQuery!;
        if (string.IsNullOrEmpty(callback.Data))
        {
            return;
        }

        var parts = callback.Data.Split();
        string? menuId, btnId;
        List<string> args;
        try
        {
            menuId = parts[0];
            btnId = parts[1];
            args = parts.Skip(2)
                .ToList();
        }
        catch (Exception)
        {
            return;
        }

        //var userState =
        //    await _storage.GetUserState(callback.Message!.Chat.Id, callback.From.Id);

        // await _updateHandler.HandleCallback(new TgCallbackUpdate(
        //     DateTime: DateTime.Now,
        //     MenuId: menuId,
        //     ButtonId: btnId,
        //     Arguments: args,
        //     ChatId: callback.Message!.Chat.Id,
        //     SenderId: callback.From.Id,
        //     State: userState.values
        // ));
    }
}
