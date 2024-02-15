namespace Domic.UseCase.Commons.DTOs;

public sealed class Result
{
    public long LineNumber { get; set; }
    public int MessageId { get; set; }
    public string MessageContent { get; set; }
    public DateTime SendDateTime { get; set; }
    public byte? DeliveryStatus { get; set; }
    public DateTime? DeliveryDateTime { get; set; }
}