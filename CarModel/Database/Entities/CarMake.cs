using System.ComponentModel.DataAnnotations;

namespace CarModel.Entities
{
    public class CarMake
    {
        [Key]
        public int Id { get; set; }
        public string? MakeId { get; set; }
        public string? MakeName { get; set; }
        public string? ModelId { get; set; }
        public string? ModelName { get; set; }
    }
}
