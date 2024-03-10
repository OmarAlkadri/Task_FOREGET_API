using Org.BouncyCastle.Pqc.Crypto.Lms;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_FOREGET.ViewModels
{
    public class CountriesCities
    {
        [NotMapped]
        public Dictionary<string, List<string>> Values { get; private set; }

        public CountriesCities()
        {
            Values = new Dictionary<string, List<string>>
            {
                { "USA", new List<string>() { "New York", "Los Angeles", "Miami", "Minnesota"} },
                { "China", new List<string>() { "Beijing", "Shanghai" } },
                { "Turkey", new List<string>() { "Istanbul", "Izmir" } }
            };
        }
    }
}
