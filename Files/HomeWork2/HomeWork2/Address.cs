using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
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
        public string Print(int numberOfTabs)
        {
            string tabs = "";
            for (int i = 0; i < numberOfTabs; i++)
            {
                tabs += "\t";
            }

            return $"\n{tabs}Street Name: {streetName}\n{tabs}Building Number: {buildingNumber}\n{tabs}City: {city}\n{tabs}Country: {country}";
        }
    }
}
