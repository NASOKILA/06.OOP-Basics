using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards;

namespace DungeonsAndCodeWizards.Items
{
    public class PoisonPotion : Item
    {
        public PoisonPotion()
            : base(5)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health += 20;

            if (character.Health <= 0)
            {
                character.IsAlive = false;
            }

        }
    }
}
