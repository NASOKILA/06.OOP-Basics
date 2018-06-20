using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    static void Main(string[] args)
    {

        List<Pokemon> pokemons = new List<Pokemon>();

        List<Trainer> trainers = new List<Trainer>();


        while (true)
        {
            string[] input = Console.ReadLine().Split(new Char[] { ' ' })
                .ToArray();

            if (input[0] == "Tournament")
                break;
            
            Pokemon pokemon = new Pokemon()
            {
                Name = input[1],
                Element = input[2],
                Health = int.Parse(input[3])
            };
            pokemons.Add(pokemon);
            

            if (!trainers.Any(t => t.Name == input[0]))
            {

                Trainer trainer = new Trainer()
                {
                    Name = input[0]
                };

                trainer.Pokemons.Add(pokemon);
                trainers.Add(trainer);

            }
            else
            {
                //ako sushtestvuva traniora
                Trainer currentTrainer = trainers
                    .SingleOrDefault(t => t.Name == input[0]);

                //ako ne sudurja pokemona mu go dobavqme
                if(!currentTrainer.Pokemons.Contains(pokemon))
                    currentTrainer.Pokemons.Add(pokemon);
            }
            
        }


        while (true)
        {
            string command = Console.ReadLine();
            if (command == "End")
                break;

            if (command == "Fire")
            {
                foreach (var t in trainers)
                {
                    if (t.Pokemons.Any(p => p.Element == command))
                        t.NumberOfBadges++;
                    else
                    {
                        foreach (var pok in t.Pokemons)
                        {
                            if (pok.Health - 10 < 0)
                            {
                                //pokemon dies
                                t.Pokemons.Remove(pok);
                            }
                            else
                                pok.Health = pok.Health - 10;
                        }
                    }
                }
            }
            else if (command == "Water")
            {
                foreach (var t in trainers)
                {
                    if (t.Pokemons.Any(p => p.Element == command))
                        t.NumberOfBadges++;
                    else
                    {
                        foreach (var pok in t.Pokemons)
                        {
                            if (pok.Health - 10 < 0)
                            {
                                //pokemon dies
                                t.Pokemons.Remove(pok);
                            }
                            else
                                pok.Health = pok.Health - 10;
                        }
                    }
                }
            }
            else if (command == "Electricity")
            {
                foreach (var t in trainers)
                {
                    if (t.Pokemons.Any(p => p.Element == command))
                        t.NumberOfBadges++;
                    else
                    {
                        foreach (var pok in t.Pokemons)
                        {
                            if (pok.Health - 10 < 0)
                            {
                                //pokemon dies
                                t.Pokemons.Remove(pok);

                                if (t.Pokemons.Count == 0)
                                    break;
                            }
                            else
                                pok.Health = pok.Health - 10;
                        }
                    }
                }
            }
            
        }
        
        foreach (var t in trainers.OrderByDescending(t => t.NumberOfBadges))
        {
            Console.WriteLine($"{t.Name} {t.NumberOfBadges} {t.Pokemons.Count}");
        }


    }
}

