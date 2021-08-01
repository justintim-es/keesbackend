using System;

namespace backend.Models.Dto
{
    public class ProductOut {
        public string Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string ImageId { get; set; }
        public DateTime Date { get; set; }       

    }
}