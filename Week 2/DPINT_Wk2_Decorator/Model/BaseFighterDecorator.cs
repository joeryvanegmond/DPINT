using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk2_Decorator.Model
{
    public abstract class BaseFighterDecorator : IFighter
    {
        protected IFighter Fighter;

        public int Lives { get => Fighter.Lives; set => Fighter.Lives = value ; }
        public int AttackValue { get => Fighter.AttackValue; set => Fighter.AttackValue = value; }
        public int DefenseValue { get => Fighter.DefenseValue; set => Fighter.DefenseValue = value; }

        public BaseFighterDecorator(IFighter fighter) 
        {
            Fighter = fighter;
        }


        public virtual Attack Attack() 
        {
            return Fighter.Attack();
        }

        public virtual void Defend(Attack attack)
        {
            Fighter.Defend(attack);
        }
    }
}
