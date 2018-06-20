using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Book
{

    const int MIN_PRICE = 0;
    const int MIN_TITLE_LENGTH = 3;

    private string title;
    private string author;
    private decimal price;


    public Book()
    {}

    public Book(string author, string title, decimal price)
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }

    public decimal Price
    {
        get { return price; }
        set
        {
            if (value <= MIN_PRICE)
                throw new ArgumentException("Price not valid!");
            price = value;
        }
    }

    public string Author
    {
        get { return author; }
        set
        {
            string[] authorNames = value.Split();
            if (authorNames.Length == 2 
                && Char.IsDigit(authorNames[1][0]))
            {
                throw new ArgumentException("Author not valid!");
            }

            author = value;
        }
    }

    public string Title
    {
        get { return title; }
        set
        {
            if (value.Length < MIN_TITLE_LENGTH)
                throw new ArgumentException("Title not valid!");
            
            title = value;
        }
    }
    
    public override string ToString()
    {
        //Sus this.GetType().Name vzimame imeto na klasa
        return $"Type: {this.GetType().Name}\nTitle: {this.Title}\nAuthor: {this.Author}\nPrice: {this.Price:f2}".TrimEnd();
    }

}



