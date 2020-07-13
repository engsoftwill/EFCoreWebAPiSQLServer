using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreWebAPI.Models
{
    public class Secretidentity
    {
        public int Id { get; set; }
        public string RealName { get; set; }
        public int HeroId { get; set; }
        public Hero Hero { get; set; }
    }
}
