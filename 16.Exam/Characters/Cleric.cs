using DungeonsAndCodeWizards.Bags;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Characters
{
    public class Cleric : Character, IHealable
    {
        public Cleric(string name, Faction faction) 
            : base(name, 50, 25, 40, new Backpack(), faction)
        {
        }

        public override double RestHealMultiplier => 0.5;

        public void Heal(Character character)
        {

            if (this.IsAlive == true && character.IsAlive == true)
            {
                if (this.Faction != character.Faction)
                {
                    throw new InvalidOperationException($"Cannot heal enemy character!");
                }

                character.Health += this.AbilityPoints; 

            }

        }
    }
}
