using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Product {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public double Price { get; set; }

        [Required]
        public string Description { get; set; }

        public Image Image { get; set; }
        [Required]
        public string ImageId { get; set; }
        [Required]
        public DateTime Date { get; set; }

        public ICollection<Cart> Carts { get; set; }
        public Product()
        {
            Carts = new Collection<Cart>();
        }
    }
}