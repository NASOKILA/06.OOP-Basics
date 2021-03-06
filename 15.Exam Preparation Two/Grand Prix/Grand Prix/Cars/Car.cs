﻿using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    private int hp;
    private double fuelAmount;
    private Tyre tyre;
	
    const int FUEL_TANK_MAXIMUM_CAPACITY = 160;

    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }
    
    public double FuelAmount
    {
        get { return fuelAmount; }
        set
        { 
            if (value < 0)
                throw new ArgumentException("Out of fuel");
			
            if (value > FUEL_TANK_MAXIMUM_CAPACITY)
                fuelAmount = FUEL_TANK_MAXIMUM_CAPACITY;
            else
                fuelAmount = value;
        }
    }
    
    public Tyre Tyre
    {
        get { return tyre; }
        set { tyre = value; }
    }
}