using System;
using System.Collections.Generic;
using System.Text;

public class Spy : Soldier, ISpy
{
    public Spy(int id, string firstName, string lastname, 
        int codeNumber) : 
        base(id, firstName, lastname)
    {
        this.CodeNumber = codeNumber;
    }

    public int CodeNumber { get; private set; }

    public override string ToString()
    {
        return $"{base.ToString()}{Environment.NewLine}Code Number: {this.CodeNumber}";
    }
}