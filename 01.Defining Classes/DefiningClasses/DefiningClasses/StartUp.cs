namespace DefiningClasses
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
/*
            Dice dice = new Dice() {
                Sizes = 6
            };
            
            Console.WriteLine($"Sizes : {dice.Sizes}");
      */      //Taka ni suzdava pole v klasa POLETATA VINAGI SA private,   private int sizes;
            //i posle si go setvame v get i set; 

            //this sochi kum tekushtiq obekt, polzva se i za drugi neshta.

    
            //mojem da imame mnogo instancii na tozi obekt t.e. mnogo zarcheta.
            try
            {

                //mojem da go setnem na null i posle da mu dadem stoinost
                Dice dice2 = null;
                dice2 = new Dice();

                //Ako polzvam .Sizes shte minem prez proverkata v settera
                dice2.Type = "Small";
                dice2.Sizes = 1;
                dice2.Roll();
                //bi trqbvalo da grunme sus exception
                Console.WriteLine($"Sizes : {dice2.Sizes}, Type : {dice2.Type}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            try
            {
                //Mojem i taka da gi setvame
                Dice dice3 = new Dice(6, "Big");
                

                //Taka minava zashtoto go setvame v konstruktora i ne minava prez settera
                //No mojem i da slojim proverka v konstruktora
                Console.WriteLine($"Sizes : {dice3.Sizes}, Type : {dice3.Type}");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            /*Po princip validaciqta se pravi v settera, no ima i sluchai se slaga v konstruktora.*/


            /*
             Ako napravim neshto da e 'private' znachi ne moje da se polzva ot vseki, 
             moje da se polzva samo ot sebesi.


             */



            Person person = new Person();
            person.FirstName = "Atanas";
            person.LastName = "Kambitov";
            string fullName = person.FullName();

            Console.WriteLine(fullName);





            //DOBRE E VALIDACIITE DA SE PRAVQT V KONTRUKTORA ILI PROPERTITO NA DADENIQ CLAS 
            //OT KOLKOTO V Main() METODA.

            /*
             Mojem da imame private konstruktori koito sa dostupni samo ot 
             klasa obache mojem da imame i publichni koito polzvat tezi koito sa private.
             TOVA SE NARICHA KONSTRUKTOR CHAINING.
             
             Pravi se s :this() SLED DEKLARIRANETO NA VTORIQ KONSTRUKTOR
             
               IZVIKVAME DADENIQ KONSTRUKTOR SPORED PARAMETRITE 
             */


        }
    }
}





