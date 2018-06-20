using System;
using System.Collections.Generic;
using System.Text;


public class Song
{

    const int MIN_SONG_NAME_LENGTH = 3;
    const int MAX_SONG_NAME_LENGTH = 30;

    const int MIN_MNUTES = 0;
    const int MAX_MINUTES = 14;

    const int MIN_SECONDS = 0;
    const int MAX_SECONDS = 59;

    private string name;
    private int seconds;
    private int minutes;
    private Artist artist;

    public Song()
    {}

    public Song(Artist artist, string name, int minutes, int seconds)
    {
        this.Artist = artist;
        this.Name = name;
        this.Minutes = minutes;
        this.Seconds = seconds;
    }


    public string Name
    {
        get { return name; }
        set
        {
            if (value.Length < MIN_SONG_NAME_LENGTH || value.Length > MAX_SONG_NAME_LENGTH)
                throw new ArgumentException("Song name should be between 3 and 30 symbols.");

            name = value;
        }
    }
    
    public int Minutes
    {
        get { return minutes; }
        set
        {
            if (value < MIN_MNUTES || value > MAX_MINUTES)
                throw new ArgumentException("Song minutes should be between 0 and 14.");

            minutes = value;
        }
    }
    
    public int Seconds
    {
        get { return seconds; }
        set
        {
            if (value < MIN_SECONDS || value > MAX_SECONDS)
                throw new ArgumentException("Song seconds should be between 0 and 59.");
            
            seconds = value;
        }
    }
    
    public Artist Artist
    {
        get { return artist; }
        set { artist = value; }
    }

}



