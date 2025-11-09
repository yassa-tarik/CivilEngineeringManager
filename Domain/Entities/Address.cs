using System;

namespace Domain.Entities
{
    public class Address
    {
        public int ID { get; private set; }
        public int Country_ID { get; private set; }
        public int City_ID { get; private set; }
        public string Municipality { get; private set; }
        public string PostalCode { get; private set; }
        public string PlaceName { get; private set; }
        public string Landmark { get; private set; }

        public Address(int id, int countryId, int cityId, string municipality, string codePostal, string placeName, string landmark)
        {
            // Validate mandatory fields
            if (ID <= 0)
                throw new ArgumentException("ID must be greater than 0", nameof(ID));

            if (countryId <= 0)
                throw new ArgumentException("Country Id must be greater than 0.");

            if (cityId <= 0)
                throw new ArgumentException("City Id must be greater than 0.");

            ID = id;
            Country_ID = countryId;
            City_ID = cityId;
            Municipality = municipality?.Trim();
            PostalCode = codePostal?.Trim();
            PlaceName = placeName?.Trim();
            Landmark = landmark?.Trim();
        }

        /// <summary>
        /// Validates the state of the address model.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if any validation check fails.</exception>
        internal void Validate()
        {
            // Check if the integer IDs are valid (greater than 0).
            if (ID <= 0)
            {
                throw new InvalidOperationException("Address ID must be greater than zero.");
            }

            if (Country_ID <= 0)
            {
                throw new InvalidOperationException("Country ID must be greater than zero.");
            }

            if (City_ID <= 0)
            {
                throw new InvalidOperationException("City ID must be greater than zero.");
            }

            // Check if string properties are not null or whitespace.
            // The use of string.IsNullOrWhiteSpace() is a robust way to check for null, empty,
            // or strings consisting only of whitespace characters.
            if (string.IsNullOrWhiteSpace(Municipality))
            {
                throw new InvalidOperationException("APC cannot be null or empty.");
            }

            if (string.IsNullOrWhiteSpace(PostalCode))
            {
                throw new InvalidOperationException("PostalCode cannot be null or empty.");
            }

            if (string.IsNullOrWhiteSpace(PlaceName))
            {
                throw new InvalidOperationException("PlaceName cannot be null or empty.");
            }

            // Assuming Landmark is also a required field for a complete address.
            if (string.IsNullOrWhiteSpace(Landmark))
            {
                throw new InvalidOperationException("Landmark cannot be null or empty.");
            }
        }

        /// <summary>
        /// Updates the address properties and validates the new state.
        /// </summary>
        public void Update(int idCountry, int idCity, string municipality, string postalCode, string placeName, string landmark)
        {
            Country_ID = idCountry;
            City_ID = idCity;
            Municipality = municipality;
            PostalCode = postalCode;
            PlaceName = placeName;
            Landmark = landmark;

            Validate();
        }
    }
}
