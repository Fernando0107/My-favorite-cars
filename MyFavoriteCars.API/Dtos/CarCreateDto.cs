using System.ComponentModel.DataAnnotations;

namespace Cars.Dtos
{
    public class CarCreateDto
    {
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