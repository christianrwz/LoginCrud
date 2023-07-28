using System.ComponentModel.DataAnnotations;

namespace LoginCrud.Data
{
    public class Product
    {
        [Key, Required]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }

    }
}
