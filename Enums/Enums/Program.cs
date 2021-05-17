using System;

namespace Enums
{
    class Program
    {
        static DayOfWeek GetDayOfWeek(int day)
        {
            if (Enum.IsDefined(typeof(DayOfWeek), day))
            {
                // true, when day represents a valid label
                return (DayOfWeek)day;
            }
            else
            {
                throw new ArgumentException($"{day} doesn't represent a valid value of the {typeof(DayOfWeek)} enum");
            }
        }

        static DayOfWeek GetDayOfWeekFromString(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine($"A null / empty / whitespaces only string is not a valid value");
                return DayOfWeek.None;
            }

            if (Enum.TryParse(typeof(DayOfWeek), value, out object result))
            {
                return (DayOfWeek)result;
            }
            else
            {
                string[] labels = Enum.GetNames(typeof(DayOfWeek));
                Console.WriteLine($"Value '{value}' doesn't match any of the enum labels [{string.Join(",", labels)}]");
                return DayOfWeek.None;
            }
        }

        static void Main(string[] args)
        {
            // DayOfWeek weekend = DayOfWeek.Saturday | DayOfWeek.Sunday;

            /*
            DayOfWeek dayofWeek = DayOfWeek.Monday |
                                  DayOfWeek.Tuesday |
                                  DayOfWeek.Wednesday |
                                  DayOfWeek.Thursday |
                                  DayOfWeek.Friday;
            */

            DayOfWeek dayofWeek = GetDayOfWeekFromString("Monday, Tuesday");
            Console.WriteLine(dayofWeek);

            // check if a given label is part of the combo:
            bool isMonday = dayofWeek.HasFlag(DayOfWeek.Monday);
            bool isTuesday = dayofWeek.HasFlag(DayOfWeek.Tuesday);
            bool isWednesday = dayofWeek.HasFlag(DayOfWeek.Wednesday);
            bool isThursday = dayofWeek.HasFlag(DayOfWeek.Thursday);
            bool isFriday = dayofWeek.HasFlag(DayOfWeek.Friday);
            // or using bitwise operators:
            bool isSaturday = (dayofWeek & DayOfWeek.Saturday) == DayOfWeek.Saturday;
            bool isSunday = (dayofWeek & DayOfWeek.Sunday) == DayOfWeek.Sunday;

            Console.WriteLine($"Is Monday={isMonday}");
            Console.WriteLine($"Is Tuesday={isTuesday}");
            Console.WriteLine($"Is Wednesday={isWednesday}");
            Console.WriteLine($"Is Thursday={isThursday}");
            Console.WriteLine($"Is Friday={isFriday}");
            Console.WriteLine($"Is Saturday={isSaturday}");
            Console.WriteLine($"Is Sunday={isSunday}");

            // Beware: this doesn't throw, but produces an unexpected value!!!
            DayOfWeek day = (DayOfWeek)125;

            // Better way: validate that the value is valid
            // DayOfWeek day = GetDayOfWeek(125);

            // Or take in account unexpected values in logic
            switch (day)
            {
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    Console.WriteLine("You are in weekend, enjoy!");
                    break;

                case DayOfWeek.Monday:
                case DayOfWeek.Tuesday:
                case DayOfWeek.Wednesday:
                case DayOfWeek.Thursday:
                case DayOfWeek.Friday:
                    Console.WriteLine("You need to work!");
                    break;

                default:
                    Console.WriteLine($"{day} doesn't represent a valid value of the {typeof(DayOfWeek)} enum");
                    break;
            }

            Console.WriteLine(day);
        }
    }
}
