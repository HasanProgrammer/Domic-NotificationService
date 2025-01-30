namespace Domic.UseCase.Commons.DTOs;

public sealed class Result
{
    public byte Status { get; set; }
    public string Message { get; set; }
    public Data Data { get; set; }
}

public sealed class Data
{
    public long LineNumber { get; set; }
    public int MessageId { get; set; }
    public string MessageText { get; set; }
    public long SendDateTime { get; set; }
    public byte? DeliveryStatus { get; set; }
    public double Cost { get; set; }
    public long? DeliveryDateTime { get; set; }
}