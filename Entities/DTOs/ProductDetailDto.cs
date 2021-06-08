using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ProductDetailDto:IDto
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public int MarketId { get; set; }
        public string MarketName { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int LikedNumber { get; set; }
        public string ImagePath { get; set; }


    }
}
