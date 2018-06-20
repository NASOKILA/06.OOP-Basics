using System;
using System.Collections.Generic;
using System.Text;


public interface IBuyer : IEntity
{
    int Food { get; }

    int BuyFood();
}

