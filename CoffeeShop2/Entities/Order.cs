using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShop2.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int DrinkId { get; set; }
        public Drink Drink { get; set; }
        public int Count { get; set; }
        public float Price { get; set; }
        public DateTime Date { get; set; }
        
    }
}
