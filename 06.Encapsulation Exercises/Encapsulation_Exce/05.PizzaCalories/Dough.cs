using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Dough
{
    private const int MIN_WEIGHT = 1; 
    private const int MAX_WEIGHT = 200;
    private const int DEFAULT_MULTIPLIER = 2;

    //TOVA IMA SAMO GETTER
    private decimal FlourMultiplier => validFlourTypes[this.FlourType];

    //TOVA IMA SAMO GETTER
    private decimal BakingTechniquesMultiplier => validBakingTechniques[this.BakingTechnique];

    //TOVA IMA SAMO GETTER     SMQTAME KALORIITE  I  E PUBLICHNO
    public decimal Calories 
        => DEFAULT_MULTIPLIER * this.Weight * FlourMultiplier * BakingTechniquesMultiplier;


    private Dictionary<string, decimal> validFlourTypes = new Dictionary<string, decimal>()
    {
        ["white"] = (decimal)1.5,
        ["wholegrain"] = (decimal)1.0
    };


    private Dictionary<string, decimal> validBakingTechniques = new Dictionary<string, decimal>()
    {
        ["crispy"] = (decimal)0.9,
        ["chewy"] = (decimal)1.1,
        ["homemade"] = (decimal)1.0
    };



    private decimal weight;
    private string flourType;
    private string bakingTechnique;

    public string BakingTechnique
    {
        get { return bakingTechnique; }
        set
        {
            if (!this.validBakingTechniques.Any(bt => bt.Key == value.ToLower()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            bakingTechnique = value.ToLower();
        }
    }


    public string FlourType
    {
        get { return flourType; }
        set
        {
            if (!this.validFlourTypes.Any(ft => ft.Key == value.ToLower()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            flourType = value.ToLower();
        }
    }


    public decimal Weight
    {
        get { return weight; }
        set
        {
            if (value < MIN_WEIGHT || value > MAX_WEIGHT)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }

            weight = value;
        }
    }


    public Dough()
    {}

    public Dough(string flourType, string bakingTechnique, decimal weight)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
    }

}

