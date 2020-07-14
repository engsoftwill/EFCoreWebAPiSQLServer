using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace EFCore.Dominio
{
    public class Hero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Secretidentity Secretidentity { get; set; }
        public int BattleId { get; set; }
        public List<Weapon> Weapons { get; set; }
        public List<HeroBattle>   HeroBattles { get; set; }

    }
}
