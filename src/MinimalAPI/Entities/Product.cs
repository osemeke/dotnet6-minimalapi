﻿namespace MinimalAPI.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public int CategoryId { get; set; }
    }
}
