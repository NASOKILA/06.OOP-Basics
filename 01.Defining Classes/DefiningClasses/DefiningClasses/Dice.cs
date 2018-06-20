namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class Dice
    {
        //VAJNO !!! AKO NA POLETATA NE IM SLOJIM 'public' ZNACHI PO DEFAULT SA 'private' !!!
        //No polse nqma da imame direkten dostub ot obekta do poleto I MOJE DA POLZVAME FUNKCII ILI
        //PROPERTITA KOITO SA KATO Setteri i Getteri koito da sa public TAKA SI ZASHTITAVAME POLETATA

        //Tova ni e poleto
        private int sizes;

        private string type;

        public Dice()
        {

        }

        public Dice(int sizes, string type)
        {
            this.type = type;

            if (sizes < 6 || sizes > 6)
                throw new ArgumentException($"A dice cannot have {sizes} sizes!");
            
            this.sizes = sizes;
        }
        
        //SLEDNOTO E PROPERTY KOETO VZIMA sides I GO SETVA da PODADENATA OT NAS STOINOST.
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

        //SLEDNOTO E PROPERTY KOETO NI type I GO SETVA da PODADENATA OT NAS STOINOST.
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

        //pravim publichen metod koito moje da se polzva ot vseki napraven obekt n tozi klas
        public void Roll() {

        }


        //ako metoda beshte private znachi go enkasulirame i moje da se polzva samo v tozi klas !!!
    }



    //Vseki klas moje da vzima neshta ot drug klas koito se naricha pod direktoriq:

    class directory
    {
        directory parentDirectory;
        // . . .
    }

}
