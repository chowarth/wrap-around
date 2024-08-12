using WrapAround.Domain.Common.Models;

namespace WrapAround.Domain.Students;

public sealed class Address : ValueObject
{
    public string StreetLine1 { get; }
    public string StreetLine2 { get; }
    public string StreetLine3 { get; }
    public string TownOrCity { get; }
    public string County { get; }
    public string PostCode { get; }
    public string Country { get; }

    private Address(string streetLine1, string streetLine2, string streetLine3, string city, string county, string postCode, string country)
    {
        StreetLine1 = streetLine1;
        StreetLine2 = streetLine2;
        StreetLine3 = streetLine3;
        TownOrCity = city;
        County = county;
        PostCode = postCode;
        Country = country;
    }

    public static Address Create(string streetLine1, string streetLine2, string streetLine3, string city, string county, string postCode, string country)
    {
        return new Address(streetLine1, streetLine2, streetLine3, city, county, postCode, country);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return StreetLine1;
        yield return StreetLine2;
        yield return StreetLine3;
        yield return TownOrCity;
        yield return County;
        yield return PostCode;
        yield return Country;
    }
}
