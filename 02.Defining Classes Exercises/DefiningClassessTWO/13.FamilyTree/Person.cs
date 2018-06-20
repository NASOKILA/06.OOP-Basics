using System;
using System.Collections.Generic;
using System.Text;


class Person
{

    private string name;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private string birthday;
    public string Birthday
    {
        get { return birthday; }
        set { birthday = value; }
    }

    private List<Person> parents;
    public List<Person> Parents
    {
        get { return parents; }
        set { parents = value; }
    }

    private List<Person> children;
    public List<Person> Children
    {
        get { return parents; }
        set { parents = value; }
    }


    public Person()
    {
        this.Children = new List<Person>();
        this.Parents = new List<Person>();
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Birthday}";
    }

}

