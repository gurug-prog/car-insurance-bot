using CarInsurance.BotAssistant.Domain.Shared.Telegram;

namespace CarInsurance.BotAssistant.Application.Contracts.Telegram;

public class TgMessageDto
{
    public long MessageId { get; set; }
    public long FromId { get; set; }
    public long ChatId { get; set; }
    public DateTime Date { get; set; }
    public TgMessageType Type { get; set; }
    public string? Text { get; set; }
}
