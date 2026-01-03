#pragma warning disable CS0649

using Domic.Core.Domain.Contracts.Abstracts;
using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.Domain.ValueObjects;
using Domic.Domain.Email.Events;

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
    /// <param name="identityUser"></param>
    /// <param name="address"></param>
    /// <param name="messageContent"></param>
    /// <param name="sendDateTime"></param>
    public EmailDelivery(IGlobalUniqueIdGenerator globalUniqueIdGenerator, IDateTime dateTime, 
        IIdentityUser identityUser, ISerializer serializer, string address, string messageContent,
        string verifyCode
    )
    {
        var nowDateTime = DateTime.Now;
        var nowPersianDateTime = dateTime.ToPersianShortDate(nowDateTime);
        
        Id = globalUniqueIdGenerator.GetRandom(6);
        Address = address;
        MessageContent = messageContent;
        
        //audit
        CreatedBy   = identityUser.GetIdentity();
        CreatedRole = serializer.Serialize(identityUser.GetRoles());
        CreatedAt   = new CreatedAt(nowDateTime, nowPersianDateTime);
        
        AddEvent(
            new EmailVerifyCodeSended {
                Id = Id,
                EmailAddress = address,
                VerifyCode = verifyCode,
                CreatedBy = CreatedBy,
                CreatedRole = CreatedRole,
                CreatedAt_EnglishDate = nowDateTime,
                CreatedAt_PersianDate = nowPersianDateTime
            }
        );
    }

    /*---------------------------------------------------------------*/
    
    //Behaviors
}