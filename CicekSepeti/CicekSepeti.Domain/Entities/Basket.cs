using System;
using System.Collections.Generic;
using System.Text;

namespace CicekSepeti.Domain.Entities
{
    public class Basket
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }

        public int Count { get; set; }

        public Product Product { get; set; }
        public User User { get; set; }

    }
}
