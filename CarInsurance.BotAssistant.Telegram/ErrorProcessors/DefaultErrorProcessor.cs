using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInsurance.BotAssistant.Telegram.ErrorProcessors;

public class DefaultErrorProcessor : IErrorProcessor
{
    public async Task ProcessAsync(Exception ex)
    {
        throw new NotImplementedException();
    }
}
