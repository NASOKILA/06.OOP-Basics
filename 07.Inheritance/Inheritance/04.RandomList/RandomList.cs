using System;
using System.Collections.Generic;
using System.Text;


public class RandomList : List<string>
{

    public string RandomString() {

        this.RandomString().Remove(1);
        return this.RandomString();
    }
}

