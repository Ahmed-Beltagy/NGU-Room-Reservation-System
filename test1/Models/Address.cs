using System.ComponentModel.DataAnnotations;
namespace test1.Models
{
    public class Address
    {
        [Key]
        public string roomName { get; set; }
        [Required]

        public string Capacity { get; set; }

        [Required]
        public string Public { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string buildingName { get; set; }

    }
}
