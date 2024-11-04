using BeautyLand.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Domain.Users
{
    [AudiTable]
    public class UserAddress
    {
        public int Id { get; set; }
        public string UserId { get; private set; }
        public string Name { get; private set; }
        public string State { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string PostalAddress { get; private set; }

        public UserAddress(string userId, string name, string city, string state, string postalCode, string postalAddress)
        {
            UserId = userId;
            Name = name;
            City = city;
            State = state;
            PostalCode = postalCode;
            PostalAddress = postalAddress;
        }
        public UserAddress()
        {

        }
    }
}
