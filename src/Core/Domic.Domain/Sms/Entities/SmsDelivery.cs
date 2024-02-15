#pragma warning disable CS0649

using Domic.Core.Domain.Contracts.Abstracts;
using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.Domain.ValueObjects;

namespace Domic.Domain.Service.Entities;

public class SmsDelivery : Entity<string>
{
    //Value Objects | Properties
    
    public string PhoneNumber { get; set; }
    public long LineNumber { get; set; }
    public int MessageId { get; }
    public string MessageContent { get; set; }
    public DateTime SendDateTime { get; set; }
    public byte? DeliveryStatus { get; set; }
    public DateTime? DeliveryDateTime { get; set; }

    /*---------------------------------------------------------------*/
    
    //Relations

    /*---------------------------------------------------------------*/

    //EF Core
    private SmsDelivery() {}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="globalUniqueIdGenerator"></param>
    /// <param name="dateTime"></param>
    /// <param name="phoneNumber"></param>
    /// <param name="lineNumber"></param>
    /// <param name="messageId"></param>
    /// <param name="messageContent"></param>
    /// <param name="deliveryStatus"></param>
    public SmsDelivery(IGlobalUniqueIdGenerator globalUniqueIdGenerator, IDateTime dateTime, 
        string phoneNumber, long lineNumber, int messageId, string messageContent, byte? deliveryStatus
    )
    {
        var nowDateTime = DateTime.Now;
        var nowPersianDateTime = dateTime.ToPersianShortDate(nowDateTime);
        
        Id = globalUniqueIdGenerator.GetRandom(6);
        PhoneNumber = phoneNumber;
        LineNumber = lineNumber;
        MessageId = messageId;
        MessageContent = messageContent;
        DeliveryStatus = deliveryStatus;
        CreatedAt = new CreatedAt(nowDateTime, nowPersianDateTime);
    }

    /*---------------------------------------------------------------*/
    
    //Behaviors
}