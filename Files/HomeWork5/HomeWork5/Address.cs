using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    public class Address
    {
        private string streetName;
        private int buildingNumber;
        private string city;
        private string country;

        public Address(string streetName, int buildingNumber, string city, string country)
        {
            StreetName = streetName;
            BuildingNumber = buildingNumber;
            City = city;
            Country = country;
        }

        public Address(Address otherAddress) : this(otherAddress.streetName, otherAddress.buildingNumber, otherAddress.city, otherAddress.country) { }

        public string StreetName
        {
            get { return streetName; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "Street name cannot be null.");
                }
                streetName = value;
            }
        }

        public int BuildingNumber
        {
            get { return buildingNumber; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Building number cannot be negative.");
                }
                buildingNumber = value;
            }
        }

        public string City
        {
            get { return city; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "City cannot be null.");
                }
                city = value;
            }
        }

        public string Country
        {
            get { return country; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "Country cannot be null.");
                }
                country = value;
            }
        }

        public override string ToString()
        {
            return $"\nStreet Name: {streetName}\nBuilding Number: {buildingNumber}\nCity: {city}\nCountry: {country}";
        }

        public override bool Equals(object other)
        {
            if (other is Address otherAddress)
            {
                return this.streetName == otherAddress.streetName &&
                       this.city == otherAddress.city &&
                       this.country == otherAddress.country &&
                       this.buildingNumber == otherAddress.buildingNumber;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return streetName.GetHashCode() + city.GetHashCode() + country.GetHashCode() + buildingNumber.GetHashCode();
        }
    }
}
