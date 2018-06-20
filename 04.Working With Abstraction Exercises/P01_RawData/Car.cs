using System;
using System.Collections.Generic;
using System.Text;

public class Car
{

    private string model;
    private Engine engine;
    private Cargo cargo;
    private List<Tire> tiresList;

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public Engine Engine
    {
        get { return engine; }
        set { engine = value; }
    }
    
    public Cargo Cargo
    {
        get { return cargo; }
        set { cargo = value; }
    }
    
    public List<Tire> TiresList
    {
        get { return tiresList; }
        set { tiresList = value; }
    }



    public Car()
    {

    }

    public Car(string model, Engine engine, Cargo cargo, List<Tire> tiresList)
    {
        this.Model = model;
        this.Engine = engine;
        this.Cargo = cargo;
        this.TiresList = tiresList;
    }

}