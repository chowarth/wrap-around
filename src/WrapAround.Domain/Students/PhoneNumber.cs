using WrapAround.Domain.Common.Models;

namespace WrapAround.Domain.Students;

public sealed class PhoneNumber : ValueObject
{
    public string CountryCode { get; }
    public string Value { get; }

    private PhoneNumber(string countryCode, string value)
    {
        CountryCode = countryCode;
        Value = value;
    }

    public static PhoneNumber Create(string countryCode, string value)
    {
        return new PhoneNumber(countryCode, value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return CountryCode;
        yield return Value;
    }
}
