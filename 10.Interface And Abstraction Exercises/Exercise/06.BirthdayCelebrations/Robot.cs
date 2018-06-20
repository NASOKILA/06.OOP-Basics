using System;
using System.Collections.Generic;
using System.Text;


public class Robot : IEntity
{
    public string Model { get; set; }
    
    public string Id { get; set; }

    public string Birthdate { get; set; }

    public Robot(string model, string id)
    {
        this.Id = id;
        this.Model = model;
        this.Birthdate = string.Empty;
    }

}

