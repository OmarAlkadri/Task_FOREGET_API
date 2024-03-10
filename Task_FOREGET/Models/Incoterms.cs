
using System.ComponentModel.DataAnnotations;

namespace Task_FOREGET.Models
{
    public class Incoterms : IBaseEntity
    {
        [Key]
        public Guid Id { get ; set ; }
        [Required]
        public string Name { get ; set ; }
    }
}
