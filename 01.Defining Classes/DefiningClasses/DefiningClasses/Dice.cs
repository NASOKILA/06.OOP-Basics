namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class Dice
    {      
        private int sizes;
        private string type;
        public Dice()
        {}

        public Dice(int sizes, string type)
        {
            this.type = type;
            if (sizes < 6 || sizes > 6)
                throw new ArgumentException($"A dice cannot have {sizes} sizes!");        
            this.sizes = sizes;
        }
        
        public int Sizes
        {     
            get
            {
                return sizes;
            }
            set
            {
                sizes = value;
                if (sizes < 6 || sizes > 6)
                {
                    throw new ArgumentException($"A dice cannot have {sizes} sizes!");
                }              
            }
        }

        public string Type {

            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        public void Roll() {

        }       
    }

    class directory
    {
        directory parentDirectory;
    }
}
