using System.ComponentModel.DataAnnotations;

namespace DevUtils.Core.Models
{
    public class DatabaseEnvironment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int DatabaseId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ConnectionString { get; set; }
    }
}
