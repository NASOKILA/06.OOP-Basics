using DungeonsAndCodeWizards.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Factories
{
    public class CharacterFactory
    {
        public Character CreateCharacter(string faction, string characterType, string name)
        {
            
            

            if (faction != "CSharp" && faction != "Java")
            {
                throw new ArgumentException($"Invalid faction \"{ faction }\"!");
            }

            Faction fact = Faction.CSharp;

            if (faction == "Java") {

                fact = Faction.Java;
            }


            if (characterType == "Warrior")
            {
                return new Warrior(name, fact);
            }
            else if (characterType == "Cleric")
            {
                return new Cleric(name, fact);
            }
            else
            {
                throw new ArgumentException($"Invalid character type \"{ characterType }\"!");
            }

            
        }

    }
}
