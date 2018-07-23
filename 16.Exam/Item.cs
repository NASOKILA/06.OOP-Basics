using DungeonsAndCodeWizards;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards
{
    public abstract class Item
    {
        protected Item(int weight)
        {
            this.Weight = weight;
        }
       
        public int Weight { get; private set; }
        
        public virtual void AffectCharacter(Character character) {

            if (!character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }        
        }

        public int GetWeight()
        {
            return this.Weight;
        }
    }
}