public class Person
{
    public string name;
    public int age;
    public string gender;

    public Person(string name, int age, string gender)
    {
        this.name = name;
        this.age = age;
        this.gender = gender;
    }
    public virtual void PrintInfo()
    {
        Console.WriteLine($"Name: {name}  Age: {age} Gender: {gender}");
    }
}
