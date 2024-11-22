#pragma warning disable CS0649

using Domic.Core.Domain.Contracts.Abstracts;
using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.Domain.ValueObjects;

namespace Domic.Domain.Service.Entities;

public class SmsDelivery : Entity<string>
{
    //Value Objects | Properties
    
    public string PhoneNumber { get; private set; }
    public long LineNumber { get; private set; }
    public string MessageContent { get; private set; }
    public DateTime SendDateTime { get; private set; }
    public byte? DeliveryStatus { get; private set; }
    public DateTime? DeliveryDateTime { get; private set; }

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
        MessageContent = messageContent;
        DeliveryStatus = deliveryStatus;
        CreatedAt = new CreatedAt(nowDateTime, nowPersianDateTime);
    }

    /*---------------------------------------------------------------*/
    
    //Behaviors
}