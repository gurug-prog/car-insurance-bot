using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInsurance.BotAssistant.Application.Contracts.Telegram;

public class TgCommandDto
{
    public long ChatId { get; set; }
    public long FromId { get; set; }
    public DateTime Date { get; set; }
    public string Command { get; set; }
}