using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.OnlineRadioDB
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Song> songsList = new List<Song>();

            for (int i = 0; i < n; i++)
            {

                try
                {
                    string[] songDetails = Console.ReadLine()
                        .Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    string artistName = songDetails[0];
                    string songName = songDetails[1];

                    string[] time = songDetails[2]
                        .Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                   

                    int minutes = int.Parse(time[0]);
                    int seconds = int.Parse(time[1]);

                    Artist artist = new Artist(artistName);
                    Song song = new Song(artist, songName, minutes, seconds);

                    songsList.Add(song);
                    Console.WriteLine("Song added.");

                }
                catch (ArgumentException e) {
                    Console.WriteLine(e.Message);
                }
                
            }

            PrintPlaylistSummary(songsList);
        }

        private static void PrintPlaylistSummary(List<Song> playlist)
        {
            Console.WriteLine($"Songs added: {playlist.Count}");

            var totalSeconds = playlist.Select(s => s.Seconds).Sum();
            var secondsToMinutes = totalSeconds / 60;
            var seconds = totalSeconds % 60;

            var totalMinutes = playlist.Select(s => s.Minutes).Sum() + secondsToMinutes;
            var minutesToHours = totalMinutes / 60;
            var minutes = totalMinutes % 60;

            var hours = minutesToHours;

            Console.WriteLine($"Playlist length: {hours}h {minutes}m {seconds}s");
        }

    }
}
