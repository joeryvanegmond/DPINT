using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk2_Decorator.Model
{
    class StrengthenFighterDecorator : BaseFighterDecorator
    {
        public StrengthenFighterDecorator(IFighter fighter) : base(fighter) 
        {
            //increase with 10% (should be 16.5 but is rounded to 16)
            fighter.AttackValue = Convert.ToInt32((fighter.AttackValue * 0.1) + fighter.AttackValue); 
            fighter.DefenseValue = Convert.ToInt32((fighter.DefenseValue * 0.1) + fighter.DefenseValue);
        }
    }
}
