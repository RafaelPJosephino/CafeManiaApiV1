using CafeManiaApi.Domain.Validation;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CafeManiaApi.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }

        public Product(int id, string image, string title, string description, string price)
        {
            DomainExceptionValidation.When(id < 0, "Error: Invalid Id");

            Id = id;
            ValidateDomain( image, title, description, price);
        }

        public Product(string image, string title, string description, string price)
        {
            ValidateDomain( image, title, description, price); 
        }

        public void Update(string image, string title, string description, string price) 
        {
            ValidateDomain(image, title, description, price);
        }

        public void ValidateDomain(string image, string title, string description, string price)
        {
            
            DomainExceptionValidation.When(title.Length > 200, "Error: Title exceeds maximum length of 200 characters");
            DomainExceptionValidation.When(description.Length > 200, "Error: Description exceeds maximum length of 200 characters");
            DomainExceptionValidation.When(price.Length > 200, "Error: Price exceeds maximum length of 200 characters");

            Image = image;
            Title = title;
            Description = description;
            Price = price;
        }

    }
}
