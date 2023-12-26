#pragma warning disable CS0649

using Karami.Core.Domain.Contracts.Abstracts;
using Karami.Core.Domain.Enumerations;
using Karami.Domain.Service.Events;

namespace Karami.Domain.Service.Entities;

public class Template : Entity<string>
{
    //Value Objects

    /*---------------------------------------------------------------*/
    
    //Relations

    /*---------------------------------------------------------------*/

    //EF Core
    private Template() {}

    /*---------------------------------------------------------------*/
    
    //Behaviors

    /// <summary>
    /// 
    /// </summary>
    public void Active()
    {
        IsActive = IsActive.Active;
        
        AddEvent(
            new TemplateActived {
                Id       = Id ,
                IsActive = IsActive == IsActive.Active
            }
        );
    }
    
    /// <summary>
    /// 
    /// </summary>
    public void InActive()
    {
        IsActive = IsActive.InActive;
        
        AddEvent(
            new TemplateInActived {
                Id       = Id ,
                IsActive = IsActive == IsActive.Active
            }
        );
    }
}