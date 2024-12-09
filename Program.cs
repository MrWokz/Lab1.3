using System;

public class Employee
{
    private string _firstName;
    private string _lastName;
    private string _position;
    private int _experience;

    public Employee(string firstName, string lastName)
    {
        _firstName = firstName;
        _lastName = lastName;
    }

    public void SetPositionAndExperience(string position, int experience)
    {
        _position = position;
        _experience = experience;
    }

    public double CalculateSalary()
    {
        double baseSalary = 10000; // базова зарплата
        double multiplier = 1 + (_experience / 10.0); // підвищення на основі досвіду
        double positionBonus = _position switch
        {
            "Manager" => 1.5,
            "Developer" => 1.2,
            "Analyst" => 1.1,
            _ => 1.0
        };

        return baseSalary * multiplier * positionBonus;
    }

    public double CalculateTax()
    {
        return CalculateSalary() * 0.18; // податок 18%
    }

    public void DisplayEmployeeInfo()
    {
        Console.WriteLine($"Name: {_firstName} {_lastName}");
        Console.WriteLine($"Position: {_position}");
        Console.WriteLine($"Salary: {CalculateSalary():F2} UAH");
        Console.WriteLine($"Tax: {CalculateTax():F2} UAH");
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter first name: ");
        string firstName = Console.ReadLine();
        Console.Write("Enter last name: ");
        string lastName = Console.ReadLine();
        Console.Write("Enter position: ");
        string position = Console.ReadLine();
        Console.Write("Enter experience (in years): ");
        int experience = int.Parse(Console.ReadLine());

        Employee employee = new Employee(firstName, lastName);
        employee.SetPositionAndExperience(position, experience);

        employee.DisplayEmployeeInfo();
    }
}
