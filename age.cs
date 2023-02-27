// Version: 1.0
// This C# version of the program uses DateTime objects to represent dates, which makes it simpler and more concise than the C++ version.
// It also uses string interpolation ($"{variable}") to format strings, which makes the output code easier to read.
// The Parse() method of the DateTime class is used to convert the user input string into a DateTime object,
// and the DayOfWeek property is used to determine the day of the week of the birthdate.

using System;

namespace AgeCalculator
{
    class Program
    {
        static int CalculateAge(DateTime birthdate, DateTime today)
        {
            int age = today.Year - birthdate.Year;
            if (today.Month < birthdate.Month || (today.Month == birthdate.Month && today.Day < birthdate.Day))
            {
                age--;
            }
            return age;
        }

        static int CalculateDaysUntilNextBirthday(DateTime birthdate, DateTime today)
        {
            DateTime nextBirthday = birthdate.AddYears(today.Year - birthdate.Year);
            if (nextBirthday < today)
            {
                nextBirthday = nextBirthday.AddYears(1);
            }
            return (nextBirthday - today).Days;
        }

        static void Main(string[] args)
        {
            Console.Write("Enter your birthdate (MM/DD/YYYY): ");
            DateTime birthdate = DateTime.Parse(Console.ReadLine());

            DateTime today = DateTime.Today;

            int age = CalculateAge(birthdate, today);
            int daysUntilNextBirthday = CalculateDaysUntilNextBirthday(birthdate, today);

            Console.WriteLine($"You were born on {birthdate:MM-dd-yyyy}, which was a {birthdate.DayOfWeek}");
            Console.WriteLine($"You are currently {age} years old.");
            Console.WriteLine($"Your next birthday is in {daysUntilNextBirthday} days.");
        }
    }
}


// Version: 1.0.2
// An optimized version of the previous C# program:
// This optimized version of the program uses the DayOfYear property of DateTime objects to calculate the age and the days until the next birthday.
// The DayOfYear property returns the day of the year (1-365) for a given DateTime object, which simplifies the calculation.
// Additionally, the conditional operator (?:) is used to simplify the age calculation.

using System;

namespace AgeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your birthdate (MM/DD/YYYY): ");
            DateTime birthdate = DateTime.Parse(Console.ReadLine());
            DateTime today = DateTime.Today;

            int age = today.Year - birthdate.Year - (today.DayOfYear < birthdate.DayOfYear ? 1 : 0);
            int daysUntilNextBirthday = (birthdate.AddYears(age + 1) - today).Days;

            Console.WriteLine($"You were born on {birthdate:MM-dd-yyyy}, which was a {birthdate.DayOfWeek}");
            Console.WriteLine($"You are currently {age} years old.");
            Console.WriteLine($"Your next birthday is in {daysUntilNextBirthday} days.");
        }
    }
}
