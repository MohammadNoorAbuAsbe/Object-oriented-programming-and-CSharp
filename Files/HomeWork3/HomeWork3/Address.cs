using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    public class Address
    {
        private string streetName;
        private int buildingNumber;
        private string city;
        private string country;

        public Address(string streetName, int buildingNumber, string city, string country)
        {
            SetStreetName(streetName);
            SetBuildingNumber(buildingNumber);
            SetCity(city);
            SetCountry(country);
        }

        public Address(Address otherAddress) : this(otherAddress.streetName, otherAddress.buildingNumber, otherAddress.city, otherAddress.country) { }

        public string GetStreetName()
        {
            return streetName;
        }

        public int GetBuildingNumber()
        {
            return buildingNumber;
        }

        public string GetCity()
        {
            return city;
        }

        public string GetCountry()
        {
            return country;
        }

        public bool SetStreetName(string streetName)
        {
            if (streetName != null)
            {
                this.streetName = streetName;
                return true;
            }
            return false;
        }

        public bool SetBuildingNumber(int buildingNumber)
        {
            if (buildingNumber >= 0)
            {
                this.buildingNumber = buildingNumber;
                return true;
            }
            return false;
        }

        public bool SetCity(string city)
        {
            if (city != null)
            {
                this.city = city;
                return true;
            }
            return false;
        }

        public bool SetCountry(string country)
        {
            if (country != null)
            {
                this.country = country;
                return true;
            }
            return false;
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
