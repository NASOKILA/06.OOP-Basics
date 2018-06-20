using System;
using System.Collections.Generic;
using System.Text;


public interface ILeutantGeneral : IPrivate
{
    //Pravim si kolekciq
    IReadOnlyCollection<ISoldier> Privates { get; }

    //metod aza dobavqne na voinik
    void AddPrivate(ISoldier soldier);
}

