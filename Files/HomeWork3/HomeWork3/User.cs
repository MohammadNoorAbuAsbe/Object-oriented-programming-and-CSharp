using System;

namespace HomeWork3
{
    public enum UserType
    {
        Buyer,
        Seller
    }
    public class User
    {
        protected string username;
        protected string password;
        protected Address address;

        public User(string username, string password, Address address)
        {
            SetUsername(username);
            SetPassword(password);
            SetAddress(address);
        }

        public User(User other) : this(other.username, other.password, other.address) { }

        public string GetUsername()
        {
            return username;
        }

        public bool SetUsername(string username)
        {
            if (username != null)
            {
                this.username = username;
                return true;
            }
            return false;
        }

        public string GetPassword()
        {
            return password;
        }

        public bool SetPassword(string password)
        {
            if (password != null)
            {
                this.password = password;
                return true;
            }
            return false;
        }

        public Address GetAddress()
        {
            return address;
        }

        public bool SetAddress(Address address)
        {
            if (address != null)
            {
                this.address = address;
                return true;
            }
            return false;
        }


        public override string ToString()
        {
            string details = "";
            details += $"Username: {username}\n";
            details += $"Password: {password}\n";
            details += $"Address: {address}\n";
            return details;
        }

        public override bool Equals(object obj)
        {
            if (obj is User other)
            {
                return username == other.username && password == other.password && address.Equals(other.address);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return username.GetHashCode() + password.GetHashCode() + address.GetHashCode();
        }
    }
}