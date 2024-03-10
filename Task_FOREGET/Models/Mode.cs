using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Security.Policy;
using Task_FOREGET.ViewModels;

namespace Task_FOREGET.Models
{
   // [Index(nameof(UniqueIdentifier), IsUnique = true)]
    public class Mode : IBaseEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Name { get; set; }
        }
}
