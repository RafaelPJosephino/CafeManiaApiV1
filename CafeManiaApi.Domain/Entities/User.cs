using CafeManiaApi.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CafeManiaApi.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool IsAdmin { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }

        public User(int id, string name, string username, string email, string password, bool isAdmin, string street, string city, string state, string zipCode)
        {
            DomainExceptionValidation.When(id < 0, "Error: Invalid Id");

            Id = id;
            ValidateDomain(name, username, email, password, isAdmin, street, city, state, zipCode);
        }

        public User(string name, string username, string email, string password, bool isAdmin, string street, string city, string state, string zipCode)
        {
            ValidateDomain(name, username, email, password, isAdmin, street, city, state, zipCode);
        }


        public void Update(string name, string username, string email, string password, bool isAdmin, string street, string city, string state, string zipCode) 
        {
            ValidateDomain(name, username, email, password, isAdmin, street, city, state, zipCode);
        }

        public void ValidateDomain(string name, string username, string email, string password, bool isAdmin, string street, string city, string state, string zipCode)
        {
            DomainExceptionValidation.When(name.Length > 200, "Error: Name exceeds maximum length of 200 characters");
            DomainExceptionValidation.When(username.Length > 200, "Error: Username exceeds maximum length of 200 characters");
            DomainExceptionValidation.When(email.Length > 200, "Error: Email exceeds maximum length of 200 characters");
            DomainExceptionValidation.When(password.Length > 200, "Error: Password exceeds maximum length of 200 characters");
            DomainExceptionValidation.When(street.Length > 200, "Error: Name exceeds maximum length of 200 characters");
            DomainExceptionValidation.When(city.Length > 200, "Error: Name exceeds maximum length of 200 characters");
            DomainExceptionValidation.When(state.Length > 200, "Error: Name exceeds maximum length of 200 characters");
            DomainExceptionValidation.When(zipCode.Length > 20, "Error: Name exceeds maximum length of 20 characters");

            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
            Name = name;
            Username = username;
            Email = email;
            Password = password;
            IsAdmin = isAdmin;
        }
      
    }
}
