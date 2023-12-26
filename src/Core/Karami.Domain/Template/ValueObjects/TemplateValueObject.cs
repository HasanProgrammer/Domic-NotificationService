using Karami.Core.Domain.Contracts.Abstracts;
using Karami.Core.Domain.Exceptions;

namespace Karami.Domain.Service.ValueObjects;

public class TemplateValueObject : ValueObject
{
    public readonly string Value;

    /// <summary>
    /// 
    /// </summary>
    public TemplateValueObject() {}
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <exception cref="InValidValueObjectException"></exception>
    public TemplateValueObject(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException("فیلد مربوطه الزامی می باشد !");

        if (value.Length is > 500 or < 100)
            throw new DomainException("فیلد مربوطه نباید بیشتر از 500 و کمتر از 100 عبارت داشته باشد !");

        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}