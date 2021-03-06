using System.ComponentModel.DataAnnotations;

namespace Cars.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        public string Url { get; set; }
        public string Motor { get; set; }

    }

}