using System;
using System.Collections.Generic;
using System.Linq;
using KD;

namespace KD
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        // constructor
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}

namespace TodoL
{
    class Tdl
    {

        static List<Person> people = new List<Person> { };
        static void ViewRecs()
        {
            if (people.Count == 0)
            {
                Console.WriteLine("No Records");
            }
            else
            {
                foreach (var person in people)
                {
                    Console.WriteLine($"{person.Name} is {person.Age} years old.");
                }
            }
        }
        static void AddRec()
        {
            try
            {
                Console.WriteLine("Enter name: ");
                string? name = Console.ReadLine();
                Console.WriteLine("Enter age: ");
                int age = Convert.ToInt32(Console.ReadLine());

                if (string.IsNullOrEmpty(name) || int.IsNegative(age))
                {
                    Console.WriteLine("You did not input anything.");
                    return;
                }
                Person data = new Person(name, age);

                people.Add(data);

                Console.WriteLine($"Successfully added {name} that is {age} years old!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input for age! Please enter a valid number.");
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input!");
            }

        }
        static void DeleteRec()
        {
            if (people.Count == 0)
            {
                Console.WriteLine("No records to delete.");
                return;
            }
            for (int i = 0; i < people.Count; i++)
            {
                Console.WriteLine($"{i + 1}). {people[i].Name} {people[i].Age}");
            }
            Console.WriteLine("Choose the record would you like to delete: ");

            try
            {
                int deleteRec = Convert.ToInt32(Console.ReadLine());
                if (-1 < deleteRec && deleteRec <= people.Count)
                {
                    Console.WriteLine($"{people[deleteRec - 1].Name} {people[deleteRec - 1].Age} Years old Record has been successfully deleted.");
                    people.RemoveAt(deleteRec - 1);

                }
                else
                {
                    Console.WriteLine("Invalid Index.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid type input. Please enter a valid number.");
            }


        }
        static void TDL()
        {
            while (true)
            {
                Console.WriteLine(@"Welcome to TDL Console based app.
1. View Records
2. Add Records
3. Delete a record
4. Delete all records
5. Exit

Enter: ");
                long choice = Convert.ToInt64(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ViewRecs();
                        break;
                    case 2:
                        AddRec();
                        break;
                    case 3:
                        DeleteRec();
                        break;
                    case 4:
                        Console.WriteLine("Cleared all records.");
                        people.Clear();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                }

                Console.WriteLine("Do it again? y?");
                string? answ = Console.ReadLine();
                if (string.Equals(answ, "y", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
        }
    }
}