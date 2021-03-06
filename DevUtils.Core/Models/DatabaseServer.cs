using System.ComponentModel.DataAnnotations;

namespace DevUtils.Core.Models
{
    public class DatabaseServer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string DatabaseName { get; set; }
        [Required]
        public string DbServerName { get; set; }
        [Required]
        public string StorageType { get; set; }
    }
}
