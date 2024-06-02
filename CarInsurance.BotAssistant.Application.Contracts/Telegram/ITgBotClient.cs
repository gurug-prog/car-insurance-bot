using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInsurance.BotAssistant.Application.Contracts.Telegram;

public interface ITgBotClient
{
    Task<long> SendText(long chatId, string text);
}
