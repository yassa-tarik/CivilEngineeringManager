using System;
namespace BLL.Domain.Addresses
{
    internal class Address
    {
        public int ID { get; private set; }
        public int ID_Country { get; private set; }
        public int ID_City { get; private set; }
        public string APC { get; private set; }
        public string Street { get; private set; }
        public string PostalCode { get; private set; }
        public string PlaceName { get; private set; }
        public string Landmark { get; private set; }

        public Address(int id, int countryId, int cityId, string apc, string street, string codePostal, string placeName, string landmark)
        {
            if (countryId <= 0)
                throw new ArgumentException("Country Id must be greater than 0.");

            if (cityId <= 0)
                throw new ArgumentException("City Id must be greater than 0.");

            if (string.IsNullOrWhiteSpace(street))
                throw new ArgumentException("Street is required.");

            ID = id;
            ID_Country = countryId;
            ID_City = cityId;
            APC = apc?.Trim();
            Street = street.Trim();
            PostalCode = PostalCode?.Trim();
            PlaceName = placeName?.Trim();
            Landmark = landmark?.Trim();
        }
    }
}
