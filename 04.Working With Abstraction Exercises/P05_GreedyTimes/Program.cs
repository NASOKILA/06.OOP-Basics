using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{

    public class Potato
    {
        static void Main(string[] args)
        {
            long input = long.Parse(Console.ReadLine());
            string[] safe = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, Dictionary<string, long>> bag;

            long gold, stones, cash;

            Initialize(out bag, out gold, out stones, out cash);

            RobTheSafe(input, safe, bag, ref gold, ref stones, ref cash);

            PrintRobbedItems(bag);
        }

        private static void Initialize(out Dictionary<string, Dictionary<string, long>> bag, out long gold, out long stones, out long cash)
        {
            bag = new Dictionary<string, Dictionary<string, long>>();
            gold = 0;
            stones = 0;
            cash = 0;
        }

        private static void RobTheSafe(long input, string[] safe, Dictionary<string, Dictionary<string, long>> bag, ref long gold, ref long stones, ref long cash)
        {
            for (int i = 0; i < safe.Length; i += 2)
            {
                string name = safe[i];
                long count = long.Parse(safe[i + 1]);

                string item = string.Empty;

                //get item method
                item = GetItem(name, item);

                //invalidItem or bag is Full
                if (item == "")
                    continue;
                else if (input < bag.Values.Select(x => x.Values.Sum()).Sum() + count)
                    continue;


                //CheckBagCapacityOfItem
                switch (item)
                {
                    case "Gem":
                        if (!bag.ContainsKey(item))
                        {
                            if (bag.ContainsKey("Gold"))
                            {
                                if (count > bag["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[item].Values.Sum() + count > bag["Gold"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                    case "Cash":
                        if (!bag.ContainsKey(item))
                        {
                            if (bag.ContainsKey("Gem"))
                            {
                                if (count > bag["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[item].Values.Sum() + count > bag["Gem"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                    default:
                        break;
                }


                //FillBag
                FillTheBag(bag, ref gold, ref stones, ref cash, name, count, item);
            }
        }

        private static void FillTheBag(Dictionary<string, Dictionary<string, long>> bag, ref long gold, ref long stones, ref long cash, string name, long count, string item)
        {
            if (!bag.ContainsKey(item))
            {
                bag[item] = new Dictionary<string, long>();
            }

            if (!bag[item].ContainsKey(name))
            {
                bag[item][name] = 0;
            }

            bag[item][name] += count;
            if (item == "Gold")
            {
                gold += count;
            }
            else if (item == "Gem")
            {
                stones += count;
            }
            else if (item == "Cash")
            {
                cash += count;
            }
        }

        private static string GetItem(string name, string item)
        {
            if (name.Length == 3)
            {
                item = "Cash";
            }
            else if (name.ToLower().EndsWith("gem"))
            {
                item = "Gem";
            }
            else if (name.ToLower() == "gold")
            {
                item = "Gold";
            }

            return item;
        }

        private static void PrintRobbedItems(Dictionary<string, Dictionary<string, long>> bag)
        {
            foreach (var item in bag)
            {
                string name = item.Key;
                long totalQuantity = item.Value.Values.Sum();
                Console.WriteLine($"<{name}> ${totalQuantity}");

                PrintCurrentItemTypeAndQuantity(item);
            }
        }

        private static void PrintCurrentItemTypeAndQuantity(KeyValuePair<string, Dictionary<string, long>> item)
        {
            foreach (var item2 in item.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
            {
                string type = item2.Key;
                long currentQuantity = item2.Value;
                Console.WriteLine($"##{type} - {item2.Value}");
            }
        }
    }
}