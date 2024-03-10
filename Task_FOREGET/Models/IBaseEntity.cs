using System.ComponentModel.DataAnnotations;

namespace Task_FOREGET.Models
{
    public interface IBaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string Name{ get; set; }
    }
}
