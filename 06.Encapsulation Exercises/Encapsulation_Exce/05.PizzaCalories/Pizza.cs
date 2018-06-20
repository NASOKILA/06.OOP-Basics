using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Pizza
{
    //fields
    private const int MIN_LENGTH = 1;
    private const int MAX_LENGTH = 15;

    private const int MIN_TOPPINGS = 0;
    private const int MAX_TOPPINGS = 10;


    private string name;
    private Dough dough;
    private List<Topping> toppings;

    
    //constructors
    public Pizza()
    {
        this.Toppings = new List<Topping>();
    }

    public Pizza(string name)
        :this()
    {
        this.Name = name;
    }

    //properties

    public decimal ToppingCalories
    {
        get
        {

            if (this.Toppings.Count == MIN_TOPPINGS) {
                return 0;
            }

            //Inache da sumira kaloriite

                return this.Toppings.Select(t => t.Calories).Sum();

        }
        
    }

    private List<Topping> Toppings
    {
        get { return toppings; }
        set { toppings = value; }
    }


    private Dough Dough
    {
        get { return dough; }
        set { dough = value; }
    }


    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < MIN_LENGTH || value.Length > MAX_LENGTH)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }

            name = value;
        }
    }

    //ako ne e setnato go setvame.  
    public void SetDough(Dough dough) {

        if (this.Dough != null)
        {
            throw new InvalidOperationException("Dough already set!");
        }

        this.Dough = dough;
    }
    
    public void AddTopic(Topping topping) {
        
            Toppings.Add(topping);

        if (this.Toppings.Count > MAX_TOPPINGS || this.Toppings.Count < MIN_TOPPINGS)
        {
            throw new ArgumentException($"Number of toppings should be in range [0..10].");
        }

    }

    public override string ToString()
    {
        return $"{this.Name} - {this.ToppingCalories:f2} Calories."; 
    }



}




