using CafeManiaApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CafeManiaApi.Application.DTOs
{
    public class AddOrderDTO
    {
        public int Id { get; set; }
        public int[]  Products { get; set; }
        public int User { get; set; }

    }


    public class OrderRetornoDTO
    {
        public int Id { get; set; }
        public DateTime DateOrder { get; set; }
        public ICollection<Product> Products { get; set; }
        public bool Finished { get; set; }
        public User User { get; set; }

    }





}