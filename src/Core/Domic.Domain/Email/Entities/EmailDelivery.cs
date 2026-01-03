#pragma warning disable CS0649

using Domic.Core.Domain.Contracts.Abstracts;
using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.Domain.ValueObjects;

namespace Domic.Domain.Email.Entities;

public class EmailDelivery : Entity<string>
{
    //Value Objects | Properties
    
    public string Address { get; set; }
    public string MessageContent { get; set; }

    /*---------------------------------------------------------------*/
    
    //Relations

    /*---------------------------------------------------------------*/

    //EF Core
    private EmailDelivery() {}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="globalUniqueIdGenerator"></param>
    /// <param name="dateTime"></param>
    /// <param name="address"></param>
    /// <param name="messageContent"></param>
    /// <param name="createdBy"></param>
    /// <param name="createdRole"></param>
    public EmailDelivery(IGlobalUniqueIdGenerator globalUniqueIdGenerator, IDateTime dateTime, 
        string address, string messageContent, string createdBy, string createdRole
    )
    {
        var nowDateTime = DateTime.Now;
        var nowPersianDateTime = dateTime.ToPersianShortDate(nowDateTime);
        
        Id = globalUniqueIdGenerator.GetRandom(6);
        Address = address;
        MessageContent = messageContent;
        
        //audit
        CreatedBy   = createdBy;
        CreatedRole = createdRole;
        CreatedAt   = new CreatedAt(nowDateTime, nowPersianDateTime);
    }

    /*---------------------------------------------------------------*/
    
    //Behaviors
}