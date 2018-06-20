public class Person
{
    public Person()
    {}

    public Person(string name, int age)
    {
        this.age = age;
        this.name = name;
    }

    private string name;
    private int age;

    public string Name
    {
        get { return this.name; }
        set
        {
            this.name = value;
        }
    }

    public int Age
    {
        get { return this.age; }
        set
        {
            this.age = value;
        }
    }

}
















