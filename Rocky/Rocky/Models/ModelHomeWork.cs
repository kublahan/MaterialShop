using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace Rocky.Models
{
    public class ModelHomeWork
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
