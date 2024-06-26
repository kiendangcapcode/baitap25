using System;

public abstract class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public abstract override string ToString();
}

public interface KPI
{
    double CalculateKPI();
}

public class Student : Person, KPI
{
    public string Major { get; set; }
    public float GPA { get; set; }

    public Student(string name, int age, string major, float gpa) : base(name, age)
    {
        Major = major;
        GPA = gpa;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}, Major: {Major}, GPA: {GPA}";
    }

    public double CalculateKPI()
    {
        return GPA;
    }
}

public class Teacher : Person, KPI
{
    public string Major { get; set; }
    public int Publications { get; set; }

    public Teacher(string name, int age, string major, int publications) : base(name, age)
    {
        Major = major;
        Publications = publications;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}, Major: {Major}, Publications: {Publications}";
    }

    public double CalculateKPI()
    {
        return 1.5 * Publications;
    }
}

class Program
{
    static void Main()
    {
        Student student = new Student("Nguyễn Tiến Dũng", 20, "CNTT&TT", 3.8f);
        Teacher teacher = new Teacher("Vũ Đức Việt", 38, "CNTT&TT", 5);

        Console.WriteLine(student.ToString());
        Console.WriteLine($"Student KPI: {student.CalculateKPI()}");

        Console.WriteLine(teacher.ToString());
        Console.WriteLine($"Teacher KPI: {teacher.CalculateKPI()}");
    }
}
