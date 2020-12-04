using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CicekSepeti.API.DTO
{
    public class ProductDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is Name.")]
        public string Name { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}
