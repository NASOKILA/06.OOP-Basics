using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards
{
    public abstract class Bag
    {

        protected Bag(int capacity)
        {

            this.Capacity = capacity;
            this.Items = new List<Item>();
            this.Load = Items.Select(i => i.GetWeight()).Sum();
        }

        private int Capacity { get; set; }

        public ICollection<Item> Items { get; }

        private double Load { get; set; }

        public virtual void AddItem(Item item)
        {

            if ((this.Load + item.GetWeight()) > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            this.Items.Add(item);

        }


        public virtual Item GetItem (string name)
        {
            if (this.Items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            Item item = this.Items.FirstOrDefault(i => i.GetType().Name == name);

            if (item == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            this.Items.Remove(item);

            return item;
        }


    }
}



