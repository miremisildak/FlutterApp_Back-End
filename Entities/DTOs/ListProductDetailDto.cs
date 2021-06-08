using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ListProductDetailDto:IDto
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public string ProductName { get; set; }
    }
}
