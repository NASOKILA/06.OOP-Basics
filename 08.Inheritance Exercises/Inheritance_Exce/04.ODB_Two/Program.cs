namespace _04.Online_Radio_Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Exceptions;

    public class StartUp
    {
        public static void Main()
        {
            var songs = GetSongs();
            PrintPlaylistSummary(songs);
        }

        private static void PrintPlaylistSummary(Stack<Song> playlist)
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

        private static Stack<Song> GetSongs()
        {
            var numberOfSongs = int.Parse(Console.ReadLine());
            var songs = new Stack<Song>(numberOfSongs);

            while (numberOfSongs > 0)
            {
                var songDetails = Console.ReadLine().Split(';');

                try
                {
                    var indexOfMinuteSecondSeparation = songDetails[2].IndexOf(':');

                    if (songDetails.Length < 3 || indexOfMinuteSecondSeparation < 1 ||
                        indexOfMinuteSecondSeparation > songDetails[2].Length - 2)
                    {
                        throw new InvalidSongException();
                    }

                    var artist = songDetails[0];
                    var songName = songDetails[1];
                    var minutes = int.Parse(songDetails[2].Substring(0, indexOfMinuteSecondSeparation));
                    var seconds = int.Parse(songDetails[2].Substring(indexOfMinuteSecondSeparation + 1));

                    songs.Push(new Song(artist, songName, minutes, seconds));
                    Console.WriteLine("Song added.");
                }
                catch (InvalidSongException ise)
                {
                    Console.WriteLine(ise.Message);
                }
                catch (FormatException fex)
                {
                    Console.WriteLine("Invalid song length.");
                }

                numberOfSongs--;
            }

            return songs;
        }
    }

    

    public class Song
    {
        private const int ArtistMinLength = 3;
        private const int ArtistMaxLength = 20;
        private const int NameMinLength = 3;
        private const int NameMaxLength = 30;
        private const int MinutesMin = 0;
        private const int MinutesMax = 14;
        private const int SecondsMin = 0;
        private const int SecondsMax = 59;

        private string artist;
        private string name;
        private int minutes;
        private int seconds;

        public Song(string artist, string name, int minutes, int seconds)
        {
            this.Artist = artist;
            this.Name = name;
            this.Minutes = minutes;
            this.Seconds = seconds;
        }

        private string Artist
        {
            set
            {
                if (value.Length < ArtistMinLength || value.Length > ArtistMaxLength)
                {
                    throw new InvalidArtistNameException(ArtistMinLength, ArtistMaxLength);
                }

                this.artist = value;
            }
        }

        private string Name
        {
            set
            {
                if (value.Length < NameMinLength || value.Length > NameMaxLength)
                {
                    throw new InvalidSongNameException(NameMinLength, NameMaxLength);
                }

                this.name = value;
            }
        }

        public int Minutes
        {
            get
            {
                return this.minutes;
            }

            private set
            {
                if (value < MinutesMin || value > MinutesMax)
                {
                    throw new InvalidSongMinutesException(MinutesMin, MinutesMax);
                }

                this.minutes = value;
            }
        }

        public int Seconds
        {
            get
            {
                return this.seconds;
            }

            private set
            {
                if (value < SecondsMin || value > SecondsMax)
                {
                    throw new InvalidSongSecondsException(SecondsMin, SecondsMax);
                }

                this.seconds = value;
            }
        }
    }
}
