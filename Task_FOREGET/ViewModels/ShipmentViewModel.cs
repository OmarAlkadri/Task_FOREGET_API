using System.ComponentModel.DataAnnotations;

namespace Task_FOREGET.ViewModels
{
    public class ShipmentViewModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid ModeId { get; set; }
        public string? ModeName { get; set; }

        public Guid MovementTypeId { get; set; }
        public string? MovementTypeName { get; set; }

        public Guid IncotermId { get; set; }
        public string? IncotermName { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public Guid PackageTypeId { get; set; }
        public string? PackageTypeName { get; set; }


        public Guid UnitFirstId { get; set; }
        public string? UnitFirstName { get; set; }

        public Guid SecondUnitId { get; set; }
        public string? SecondUnitName { get; set; }


        public Guid CurrencyId { get; set; }
        public string? CurrencyName { get; set; }

    }
}
