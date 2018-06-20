class Person
{

    public string Name { get; set; }
    public int Age { get; set; }

    /*Zd 2*/

    public Person()
    {
        this.Name = "No name";
        this.Age = 1;
    }


    public Person(int age)
    {
        this.Name = "No name";
        this.Age = age;
    }

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }
}

