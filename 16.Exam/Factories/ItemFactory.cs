using DungeonsAndCodeWizards.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Factories
{
    public class ItemFactory
    {

        public Item CreateItem(string itemName)
        {

            if (itemName == "HealthPotion")
            {
                return new HealthPotion();
            }
            else if (itemName == "ArmorRepairKit")
            {
                return new ArmorRepairKit();
            }
            else if (itemName == "PoisonPotion")
            {
                return new PoisonPotion();
            }
            else
            {
                throw new ArgumentException($"Invalid item \"{itemName}\"!");
            }

            
        }
    }
}
