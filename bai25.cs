using System;

public abstract class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    protected string BankAccount;

    public Person(string name, int age, string gender)
    {
        Name = name;
        Age = age;
        Gender = gender;
    }

    public abstract string GetRole();
}

public interface KPIEvaluator
{
    double CalculateKPI();
}

public class TeachingAssistant : Person, KPIEvaluator
{
    public string EmployeeID { get; set; }
    private int NumberOfCourses;

    public TeachingAssistant(string name, int age, string gender, string employeeID, int numberOfCourses) : base(name, age, gender)
    {
        EmployeeID = employeeID;
        NumberOfCourses = numberOfCourses;
    }

    public override string GetRole()
    {
        return "Teaching Assistant";
    }

    public double CalculateKPI()
    {
        return NumberOfCourses * 5.0;
    }
}

public class Lecturer : Person, KPIEvaluator
{
    public string EmployeeID { get; set; }
    private int NumberOfPublications;

    public Lecturer(string name, int age, string gender, string employeeID, int numberOfPublications) : base(name, age, gender)
    {
        EmployeeID = employeeID;
        NumberOfPublications = numberOfPublications;
    }

    public override string GetRole()
    {
        return "Lecturer";
    }

    public double CalculateKPI()
    {
        return NumberOfPublications * 7.0;
    }
}

public sealed class Professor : Lecturer
{
    public static int CountProfessors = 0;
    private int NumberOfProjects;

    public Professor(string name, int age, string gender, string employeeID, int numberOfPublications, int numberOfProjects) : base(name, age, gender, employeeID, numberOfPublications)
    {
        NumberOfProjects = numberOfProjects;
        CountProfessors++;
    }

    public override string GetRole()
    {
        return "Professor";
    }

    public override double CalculateKPI()
    {
        return base.CalculateKPI() + NumberOfProjects * 10.0;
    }
}

class Program
{
    static void Main()
    {
        int n = GetValidNumber();
        Person[] people = new Person[n];
        InputPeople(people);
        DisplayPeople(people);
        Console.WriteLine("Number of Professors: " + Professor.CountProfessors);
    }

    static int GetValidNumber()
    {
        int n;
        do
        {
            Console.Write("Enter the number of people (2-10): ");
        } while (!int.TryParse(Console.ReadLine(), out n) || n < 2 || n > 10);
        return n;
    }

    static void InputPeople(Person[] people)
    {
        for (int i = 0; i < people.Length; i++)
        {
            Console.Write("Enter type (ta, lec, gs): ");
            string type = Console.ReadLine().ToLower();
            switch (type)
            {
                case "ta":
                    Console.Write("Enter name, age, gender, employee ID, number of courses: ");
                    people[i] = new TeachingAssistant(Console.ReadLine(), int.Parse(Console.ReadLine()), Console.ReadLine(), Console.ReadLine(), int.Parse(Console.ReadLine()));
                    break;
                case "lec":
                    Console.Write("Enter name, age, gender, employee ID, number of publications: ");
                    people[i] = new Lecturer(Console.ReadLine(), int.Parse(Console.ReadLine()), Console.ReadLine(), Console.ReadLine(), int.Parse(Console.ReadLine()));
                    break;
                case "gs":
                    Console.Write("Enter name, age, gender, employee ID, number of publications, number of projects: ");
                    people[i] = new Professor(Console.ReadLine(), int.Parse(Console.ReadLine()), Console.ReadLine(), Console.ReadLine(), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
                    break;
                default:
                    i--; // Incorrect input, try again
                    Console.WriteLine("Invalid type, please enter 'ta', 'lec', or 'gs'.");
                    break;
            }
        }
    }

    static void DisplayPeople(Person[] people)
    {
        foreach (Person p in people)
        {
            Console.WriteLine($"{p.GetRole()} - {p.Name}, Age: {p.Age}, Gender: {p.Gender}, KPI: {((KPIEvaluator)p).CalculateKPI()}");
        }
    }
}
