﻿namespace ClothingStore.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set;}

        public int CategoryId { get; set; }

        public int SizeId { get; set; }

        public Category? Category { get; set; }

        public Size? Size { get; set; }


    }
}
