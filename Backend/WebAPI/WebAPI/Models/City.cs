using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; } 
        [Required]
        public int CountryId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}