using System.ComponentModel.DataAnnotations;

namespace Boats.API.Models
{
    public class BoatDTO
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string County { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Zipcode { get; set; }
        [Required]
        public string JobTitle { get; set; }
        public string JobDesciption { get; set; }
        public string Date { get; set; }
        [Required]
        public float Amount { get; set; }
    }

    public class CreateBoatDTO
    {
        
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string County { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Zipcode { get; set; }
        [Required]
        public string JobTitle { get; set; }
        public string JobDesciption { get; set; }
        public string Date { get; set; }
        [Required]
        public float Amount { get; set; }

    }
}
