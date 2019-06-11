using System.Collections.Generic;
using Library.Infrastructure.Model;

namespace Library.Infrastructure
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public IEnumerable<RentInfo> RentInfos { get; set; }
    }
}