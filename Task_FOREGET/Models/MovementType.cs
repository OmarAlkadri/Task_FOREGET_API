
using System.ComponentModel.DataAnnotations;

namespace Task_FOREGET.Models
{
    public class MovementType : IBaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
