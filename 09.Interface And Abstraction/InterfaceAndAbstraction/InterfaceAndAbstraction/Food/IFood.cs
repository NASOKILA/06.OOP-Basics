using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceAndAbstraction.Food
{
    public interface IFood
    {
        //vsichki interfeisi zapochvat sus 'I'
        //Ideqta na interfeisite e da imat samo DEFINICII KAKVO TRQBVA DA IMA VSEKI KLAS KOITO GI NASLEDQVA !!!!!
        //TUK VSICHKO E ABSTRAKTNO t.e. NE MOJEM DA GO POLZVAME A SAMO DA GO DEFINIRAME.
            //I POSLE DA SE POLZVA OT DRUGI KLASOVE.

        //TUK VSICHKO E PUBLIC PO DEFAULT ZATOVA NE PISHEM NISHTO OTPRED
        string Name { get; set; }

        decimal Price { get; }

        decimal Weight { get; }

        void Information();
    }
}
