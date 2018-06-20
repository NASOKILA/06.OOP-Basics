using System;
using System.Collections.Generic;
using System.Text;


public class Cat : Animal
{
    public Cat(string name, string favoriteFood)
        : base(name, favoriteFood)
    { }

    public override string ExplainSelf()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(base.ExplainSelf());
        sb.AppendLine("MEEOW");

        return sb.ToString().TrimEnd();
    }

}

