using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards
{
    public abstract class Character
    {


        

        protected Character(string name,
            double health, double armor,
            double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;

            this.BaseHealth = health;
            this.Health = health;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            
            this.BaseArmor = armor;

            this.Armor = armor;
            this.Status = "Alive";
            
        }
        
        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                name = value;
            }
        }

        public double BaseHealth { get; private set; }
        private double health;

        public double Health
        {
            get { return health; }
            set
            {

                if (value < 0)
                {
                    value = 0;
                }
                if (value > this.BaseHealth)
                {
                    value = this.BaseHealth;
                }


                health = value;
            }
        }
        

        public Faction Faction { get; private set; }

        public double BaseArmor { get; private set; }

        private double armor;

        public double Armor
        {
            get { return armor; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                if (value > this.BaseArmor)
                {
                    value = this.BaseArmor;
                }
                armor = value;
            }
        }


        public string Status { get; set; }

        public double AbilityPoints { get; private set; }

        public Bag Bag { get; private set; }

        public bool IsAlive { get; set; } = true;

        virtual public double RestHealMultiplier { get; private set; } = 0.2;

        // EXAMPLE: Health: 100, Armor: 30, Hit Points: 40  Health: 90, Armor: 0
        public void TakeDamage(double hitPoints)
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }


            double originalHitPoints = hitPoints; //5

            //5          //15
            originalHitPoints = hitPoints - this.Armor; //-10

            if (this.Armor - hitPoints < 0)
            {
                this.Armor = 0;
            }
            else
            {
                //15          //5
                this.Armor -= hitPoints; //10

            }


            if (originalHitPoints > 0)
            {
                this.Health -= originalHitPoints;
            }


            if (this.Health < 0)
            {
                this.IsAlive = false;
            }

        }

        //Example: Health: 50, BaseHealth: 100, RestHealMultiplier: 0.2  Health: 50 + (100 * 0.2)  70
        public void Rest()
        {
            if (this.IsAlive == true)
            {
                this.Health += (this.BaseHealth * this.RestHealMultiplier);
            }
        }
        
        public void UseItem(Item item)
        {
            if (this.IsAlive == true)
            {

                item.AffectCharacter(this);
            }
        }
        
        public void UseItemOn(Item item, Character character)
        {
            if (this.IsAlive == true && character.IsAlive == true)
            {
                character.UseItem(item);
            }
        }
        
        public void GiveCharacterItem(Item item, Character character)
        {
            if (this.IsAlive == true && character.IsAlive == true)
            {
                character.ReceiveItem(item);
            }
        }

        public void ReceiveItem(Item item) {
            this.Bag.AddItem(item);
        }

        
    }
}






