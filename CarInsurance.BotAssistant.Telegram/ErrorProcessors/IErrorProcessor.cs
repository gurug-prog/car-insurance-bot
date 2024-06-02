using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInsurance.BotAssistant.Telegram.ErrorProcessors;

public interface IErrorProcessor
{
    Task ProcessAsync(Exception ex);
}
