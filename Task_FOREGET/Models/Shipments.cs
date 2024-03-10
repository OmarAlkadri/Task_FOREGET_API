using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Security.Policy;
using Task_FOREGET.ViewModels;
using Task_FOREGET.Models.EnumTypes;

namespace Task_FOREGET.Models
{
   // [Index(nameof(UniqueIdentifier), IsUnique = true)]
    public class Shipments
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Mode mode { get; set; }
        [Required]
        public MovementType movementType { get; set; }
        [Required]
        public Incoterms incoterms { get; set; }
      
        [Required]
        public string country { get; set; }
     
        [Required]
        public string citiy { get; set; }

        [Required]
        public PackageType packageType { get; set; }
        [Required]
        public UnitFirst unitFirst { get; set; }
        [Required]
        public SecondUnit secondUnit { get; set; }
        [Required]
        public Currency currency { get; set; }

    }
}
