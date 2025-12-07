using System;

namespace Domain.Entities
{
    public class Address
    {
        public int Country_ID { get; private set; }
        public int City_ID { get; private set; }
        public string Municipality { get; private set; }
        public string PostalCode { get; private set; }
        public string PlaceName { get; private set; }
        public string Landmark { get; private set; }

        public Address(int country_ID, int city_ID, string municipality, string postalCode, string placeName, string landmark)
        {
            if (city_ID <= 0)
                throw new ArgumentException("City Id must be greater than 0.");

            if (string.IsNullOrWhiteSpace(municipality))
                throw new ArgumentException("Municipality cannot be empty.");

            if (string.IsNullOrWhiteSpace(postalCode))
                throw new ArgumentException("CodePostal cannot be empty.");

            if (string.IsNullOrWhiteSpace(placeName))
                throw new ArgumentException("PlaceName cannot be empty.");

            if (string.IsNullOrWhiteSpace(landmark))
                throw new ArgumentException("Landmark cannot be empty.");

            Country_ID = country_ID;
            City_ID = city_ID;
            Municipality = municipality?.Trim();
            PostalCode = postalCode?.Trim();
            PlaceName = placeName?.Trim();
            Landmark = landmark?.Trim();
        }

        /// <summary>
        /// Validates the state of the address model.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if any validation check fails.</exception>
        internal void Validate()
        {

            if (Country_ID < 0)
            {
                throw new InvalidOperationException("Country ID must be greater than -1.");
            }

            if (City_ID <= 0)
            {
                throw new InvalidOperationException("City ID must be greater than zero.");
            }

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
