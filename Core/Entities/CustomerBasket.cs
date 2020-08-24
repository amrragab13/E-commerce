using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    public class CustomerBasket
    {
        public CustomerBasket()
        {
        }

        public CustomerBasket(string id)
        {
            Id = id;
        }
        [Required]
        public string Id { get; set; }
        [Required]
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
    }
}
