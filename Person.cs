class Person
{
    private string SomePrivStr;
    public string name;
    public int age;
    public string gender;

    //Конструктор 1
    public Person() {
        name = "Неизвестно"; 
        age = 0; 
        gender = "Неизвестно";
    }

    //Конструктор 2
    public Person(string name, int age,string gender) {
        this.name = name; 
        this.age = age; 
        this.gender = gender;   
    }
    public virtual void PrintInfo()
    {
        Console.WriteLine($"Name: {name}  Age: {age} Gender: {gender}");
    }
    public virtual void MethFromA()
    {
        Console.WriteLine($"Called meth from A");
    }
}