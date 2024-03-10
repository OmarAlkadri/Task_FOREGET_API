using System.ComponentModel.DataAnnotations;

namespace Task_FOREGET.Models
{
    public class Users : IBaseEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; }
        public string? HashPassword { get; set; }
    }
}
