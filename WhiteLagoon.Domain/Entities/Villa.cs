using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteLagoon.Domain.Entities
{
    public class Villa
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Villa name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        [DisplayName("Villa Name")]
        public string Name { get; set; } = string.Empty;

        [DisplayName("Description")]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(50, 10000, ErrorMessage = "Price must be between $50 and $10,000.")]
        [DisplayName("Price Per Night")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        [Required(ErrorMessage = "Square feet is required.")]
        [Range(100, 10000, ErrorMessage = "Square feet must be between 100 and 10,000.")]
        [DisplayName("Square Feet")]
        public int sqft { get; set; }

        [Required(ErrorMessage = "Occupancy is required.")]
        [Range(1, 20, ErrorMessage = "Occupancy must be between 1 and 20 people.")]
        [DisplayName("Occupancy (No. of People)")]
        public int Occupancy { get; set; }

        [Url(ErrorMessage = "Please enter a valid image URL.")]
        [DisplayName("Image URL")]
        public string? ImageUrl { get; set; }

        [DisplayName("Created Date")]
        [DataType(DataType.DateTime)]
        public DateTime? CreatedDate { get; set; }

        [DisplayName("Updated Date")]
        [DataType(DataType.DateTime)]
        public DateTime? UpdatedDate { get; set; }
    }
}
