namespace DefiningClasses
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
			try
            {
                Dice dice2 = null;
                dice2 = new Dice();
                
                dice2.Type = "Small";
                dice2.Sizes = 1;
                dice2.Roll();
               
                Console.WriteLine($"Sizes : {dice2.Sizes}, Type : {dice2.Type}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Dice dice3 = new Dice(6, "Big");               
                Console.WriteLine($"Sizes : {dice3.Sizes}, Type : {dice3.Type}");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
    
            Person person = new Person();
            person.FirstName = "Atanas";
            person.LastName = "Kambitov";
            string fullName = person.FullName();

            Console.WriteLine(fullName);
        }
    }
}
