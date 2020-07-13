using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreWebAPI.Models
{
    public class Battle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BattleId { get; set; }
        public DateTime Dtbegin { get; set; }
        public DateTime Dtfinish { get; set; }
    }
}
