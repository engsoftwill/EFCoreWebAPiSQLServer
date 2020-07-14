using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Dominio
{
    public class HeroBattle
    {
        public int HeroId { get; set; }
        public Hero Hero { get; set; }      //many heros were in this battle
        public int BattleId { get; set; }        
        public Battle Battle { get; set; }  //This hero fight in many battles

    }
}
