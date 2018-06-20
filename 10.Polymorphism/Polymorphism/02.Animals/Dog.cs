using System;
using System.Collections.Generic;
using System.Text;


public class Dog : Animal
{
    public Dog(string name, string favoriteFood)
        :base(name, favoriteFood)
    {}



    public override string ExplainSelf()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(base.ExplainSelf());
        sb.AppendLine("DJAAF");

        return sb.ToString().TrimEnd();
    }
}

