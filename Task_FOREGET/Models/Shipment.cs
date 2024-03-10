using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Security.Policy;
using Task_FOREGET.ViewModels;

namespace Task_FOREGET.Models
{
   // [Index(nameof(UniqueIdentifier), IsUnique = true)]
    public class Shipment
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid ModeId { get; set; }

        [Required]
        public Guid MovementTypeId { get; set; }

        [Required]
        public Guid IncotermId { get; set; }
      
        [Required]
        public string country { get; set; }
     
        [Required]
        public string citiy { get; set; }

        [Required]
        public Guid PackageTypeId { get; set; }
        [Required]
        public Guid UnitFirstId { get; set; }

        [Required]
        public Guid SecondUnitId { get; set; }
        [Required]
        public Guid CurrencyId { get; set; }


        public virtual Mode Mode { get; set; }
        public virtual MovementType MovementType { get; set; }
        public virtual Incoterms Incoterm { get; set; }
        public virtual PackageType PackageType { get; set; }
        public virtual UnitFirst UnitFirst { get; set; }
        public virtual SecondUnit SecondUnit { get; set; }
         public virtual Currency Currency { get; set; }
    }
}
