using System;

namespace HomeWork5
{
    public enum UserType
    {
        Buyer,
        Seller
    }

    public class User
    {
        protected string username, password;
        protected Address address;

        
        public User(string username, string password, Address address)
        {
            Username = username;
            Password = password;
            Address = address;
        }

        public User(User other) : this(other.username, other.password, other.address) { }

        public string Username
        {
            get { return username; }
            set
            {
                if (value == null || value.Length == 0)
                {
                    throw new ArgumentNullException(nameof(value), "Username cannot be null or empty.");
                }
                username = value;
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                if (value == null || value.Length == 0)
                {
                    throw new ArgumentNullException(nameof(value), "Password cannot be null or empty.");
                }
                password = value;
            }
        }

        public Address Address
        {
            get { return address; }
            set
            {
                address = value ?? throw new ArgumentNullException(nameof(value), "Address cannot be null.");
            }
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