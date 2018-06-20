using System;
using System.Linq;

namespace _05.MordorsCruelPlan
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = Console.ReadLine()
                .Split(new string[] {" ", ","},StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int points = 0;

            for (int i = 0; i < input.Length; i++)
                points += GetPoints(input[i], points);
            
            MoodFactory moodFactory = new MoodFactory(points);

            Console.WriteLine(moodFactory.Mood);

        }

        private static int GetPoints(string food, int points)
        {
            if (food == "Cram")
                points += (int)FoodFactory.Cram;
            else if (food == "Lembas")
                points += (int)FoodFactory.Lembas;
            else if (food == "Apple")
                points += (int)FoodFactory.Apple;
            else if (food == "Melon")
                points += (int)FoodFactory.Melon;
            else if (food == "HoneyCake")
                points = (int)FoodFactory.HoneyCake;
            else if (food == "Mushrooms")
                points = (int)FoodFactory.Mushrooms;
            else
                points -= (int)FoodFactory.Else;


            return points;

        }
    }
}
