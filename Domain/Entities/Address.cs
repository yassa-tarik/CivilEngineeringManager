using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Address
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
            // Validate mandatory fields
            if (ID <= 0)
                throw new ArgumentException("ID must be greater than 0", nameof(ID));

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

            if (ID_Country <= 0)
            {
                throw new InvalidOperationException("Country ID must be greater than zero.");
            }

            if (ID_City <= 0)
            {
                throw new InvalidOperationException("City ID must be greater than zero.");
            }

            // Check if string properties are not null or whitespace.
            // The use of string.IsNullOrWhiteSpace() is a robust way to check for null, empty,
            // or strings consisting only of whitespace characters.
            if (string.IsNullOrWhiteSpace(APC))
            {
                throw new InvalidOperationException("APC cannot be null or empty.");
            }

            if (string.IsNullOrWhiteSpace(Street))
            {
                throw new InvalidOperationException("Street cannot be null or empty.");
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
        public void Update(int idCountry, int idCity, string apc, string street, string postalCode, string placeName, string landmark)
        {
            ID_Country = idCountry;
            ID_City = idCity;
            APC = apc;
            Street = street;
            PostalCode = postalCode;
            PlaceName = placeName;
            Landmark = landmark;

            Validate();
        }
    }
}
