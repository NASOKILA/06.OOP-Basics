using System;
using System.Collections.Generic;
using System.Text;


public interface ILeutantGeneral : IPrivate
{
    IReadOnlyCollection<ISoldier> Privates { get; }

    void AddPrivate(ISoldier soldier);
}