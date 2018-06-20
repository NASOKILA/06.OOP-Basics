
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    static void Main(string[] args)
    {

        int[] input = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        int rectanglesNum = input[0];
        int intercectionsNum = input[1];

        List<Rectangle> recs = new List<Rectangle>();

        for (int i = 0; i < rectanglesNum; i++)
        {       
            string[] rectArgs = Console.ReadLine()
                .Split(' ')
                .ToArray();
                
            string id = rectArgs[0];

            List<int> coordinates = new List<int>();

            int x1 = int.Parse(rectArgs[1]);
            coordinates.Add(x1);

            int x2 = int.Parse(rectArgs[2]);
            coordinates.Add(x2);

            int y1 = int.Parse(rectArgs[3]);
            coordinates.Add(y1);

            int y2 = int.Parse(rectArgs[4]);
            coordinates.Add(y2);

            int width = x1 + y1;
            
            int height = x2 + y2;

            Rectangle rect = new Rectangle(id, width, height, coordinates);

            recs.Add(rect);
        }


        for (int i = 0; i < intercectionsNum; i++)
        {

            string[] pairs = Console.ReadLine().Split(' ').ToArray();

            string rectOneId = pairs[0];

            string rectTwoId = pairs[1];

            Rectangle recOne = recs.SingleOrDefault(r => r.ID == rectOneId);

            Rectangle recTwo = recs.SingleOrDefault(r => r.ID == rectTwoId);

            bool result = recOne.Intercect(recTwo);

            if(result)
                Console.WriteLine("true");
            else
                Console.WriteLine("false");

        }


    }
}               

