
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Car
{
    public Car()
    {

    }

    public Car(Model model, Engine engine, Cargo carco, List<Tire> tires)
    {
        this.Model = model;
        this.Engine = engine;
        this.Cargo = carco;
        this.Tires = tires;
    }

    public Model Model { get; set; }

    public Engine Engine { get; set; }

    public Cargo Cargo { get; set; }

    public List<Tire> Tires { get; set; }
}

