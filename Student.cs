class Student : Person
{
    public string playce;
    public Student(string name, int age, string gender, string playce)
        : base(name,age,gender)
    {
        this.playce = playce;
    }
    public override void PrintInfo()
    {
        Console.WriteLine($"{name} study in {playce}");
    }

    public void MethFromB()
    {
        Console.WriteLine($"Called meth from B!");
    }
}