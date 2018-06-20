using DungeonsAndCodeWizards.Characters;
using DungeonsAndCodeWizards.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards
{
    public class DungeonMaster
    {
        public DungeonMaster()
        {

            this.CharactersFactory = new CharacterFactory();
            this.ItemsFactory = new ItemFactory();
            this.Party = new List<Character>();
            this.ItemPool = new List<Item>();
            this.LastSurvivourRounds = 0;
        }


        public int LastSurvivourRounds { get; set; }
        public List<Character> Party { get; set; }
        public List<Item> ItemPool { get; set; }

        public CharacterFactory CharactersFactory { get; set; }
        public ItemFactory ItemsFactory { get; set; }


        public string JoinParty(string[] args)
        {

            string faction = args[0];
            string characterType = args[1];
            string name = args[2];


            Character character = CharactersFactory.CreateCharacter(faction, characterType, name);

            this.Party.Add(character);

            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {

            string itemName = args[0];
            

            Item item = ItemsFactory.CreateItem(itemName);
            
            this.ItemPool.Add(item);

            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string name = args[0];

            //get the character
            Character character = Party.FirstOrDefault(c => c.Name == name);

            if (character == null)
            {
                throw new ArgumentException($"Character {name} not found!");
            }

            if (ItemPool.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }


            Item lastItem = ItemPool.Last();

            character.ReceiveItem(lastItem);

            var type = lastItem.GetType().Name;

            return $"{character.Name} picked up {type}!";
            
        }

        public string UseItem(string[] args)
        {
            string charName = args[0];
            string itemName = args[1];

            //get character
            Character character = Party.
                FirstOrDefault(c => c.Name == charName);

            if (character == null)
            {
                throw new ArgumentException($"Character {charName} not found!");
            }


            //get item from their bag
            Item item = character.Bag.GetItem(itemName);

            character.UseItem(item);

            return $"{character.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = Party.FirstOrDefault(c => c.Name == giverName);

            if (giver == null)
            {
                throw new ArgumentException($"Character {giverName} not found!");
            }

            Character receiver = Party.FirstOrDefault(c => c.Name == receiverName);

            if (receiver == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }


            //get item from their bag
            Item item = giver.Bag.GetItem(itemName);

            giver.UseItemOn(item, receiver);

            return $"{giverName} used {itemName} on {receiverName}.";

        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = Party.FirstOrDefault(c => c.Name == giverName);

            if (giver == null)
            {
                throw new ArgumentException($"Character {giverName} not found!");
            }

            Character receiver = Party.FirstOrDefault(c => c.Name == receiverName);

            if (receiver == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }


            //get item from their bag
            Item item = giver.Bag.GetItem(itemName);

            receiver.ReceiveItem(item);

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {

            List<Character> orderedCharacters = this.Party
                .OrderByDescending(c => c.IsAlive)
                .ThenByDescending(c => c.Health)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (Character charact in orderedCharacters)
            {
                if (charact.IsAlive)
                    charact.Status = "Alive";
                else
                    charact.Status = "Dead";

                sb.AppendLine($"{charact.Name} - HP: {charact.Health}/{charact.BaseHealth}, AP: {charact.Armor}/{charact.BaseArmor}, Status: {charact.Status}");
            }

            return sb.ToString().Trim();
        }

        public string Attack(string[] args)
        {

            string attackerName = args[0];
            string receiverName = args[1];

            Character attacker = Party.FirstOrDefault(c => c.Name == attackerName);
            Character receiver = Party.FirstOrDefault(c => c.Name == receiverName);

            if (attacker == null)
            {
                throw new ArgumentException($"Character {attackerName} not found!");
            }

            if (receiver == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            //ako ne e warrior
            var type = attacker.GetType().Name;
            if (type != "Warrior")
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            
            Warrior attackerWarior = (Warrior)attacker;

            attackerWarior.Attack(receiver);

            StringBuilder sb = new StringBuilder();

            sb.Append($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! ");
            sb.Append($"{receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and ");
            sb.Append($"{receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (receiver.Health <= 0)
            {
                receiver.IsAlive = false;
                sb.Append(Environment.NewLine + $"{receiver.Name} is dead!");
            }

            return sb.ToString().Trim();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            Character healer = Party.FirstOrDefault(c => c.Name == healerName);
            Character receiver = Party.FirstOrDefault(c => c.Name == healingReceiverName);

            if (healer == null)
            {
                throw new ArgumentException($"Character {healerName} not found!");
            }

            if (receiver == null)
            {
                throw new ArgumentException($"Character {healingReceiverName} not found!");
            }

            //ako ne e healer
            var type = healer.GetType().Name;

            if (type != "Cleric")
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }


            Cleric healerParsed = (Cleric)healer;

            healerParsed.Heal(receiver);

            StringBuilder sb = new StringBuilder();

            sb.Append($"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!");

            return sb.ToString().Trim();

        }

        public string EndTurn(string[] args)
        {
            List<Character> aliveCharacters = this.Party
                .Where(c => c.IsAlive == true).ToList();



            if (aliveCharacters.Count == 0 || aliveCharacters.Count == 1)
            {
                this.LastSurvivourRounds++;
            }


            StringBuilder sb = new StringBuilder();

            foreach (Character charact in aliveCharacters)
            {

                double healthBeforeRest = charact.Health;

                charact.Rest();

                double currentHealth = charact.Health;

                sb.AppendLine($"{charact.Name} rests ({healthBeforeRest} => {currentHealth})");
            }


            return sb.ToString().Trim();
        }


        public bool IsGameOver()
        {
            if (LastSurvivourRounds > 1)
                return true;

            return false;
        }

    }
}
