using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4
{
    class Person
    {
        //A two private fields
        private string _name;
        private int _birthYear;
        //B two properties for access
        public string Name 
        {
            get
            {
                return _name;
            }
        }
        public int BirthYear
        {
            get
            {
                return _birthYear;
            }
        }
        //C default constructor and constructor with 2 parameters 
        public Person() {}
        public Person(string name, int birthYear)
        {
            _name = name;
            _birthYear = birthYear;
        }
        //D methods
        //calculate the age 
        public int Age()
        {
            return DateTime.Now.Year - _birthYear; ;
        }
        //input information about person
        public void Input()// public Person Input() було / переробив на просто войд щоб не клонувати щоразу нову персону *1
        {
            Console.Write("Name: ");
            _name = Console.ReadLine();
            Console.Write("The birthday year: ");
            while (!Int32.TryParse(Console.ReadLine(), out _birthYear) || (_birthYear > DateTime.Now.Year)
                || (_birthYear <= (DateTime.Now.Year - 120)))
            {
                Console.WriteLine("You have entered invalid value for 'year'. Check please and try again.");
                Console.Write("\nThe birthday year: ");
            }
            //return new Person(_name, _birthYear);//*1
        }
        //change the name of person
        public string ChangeName()
        {
            this._name = "Very Young";
            return this._name;
        }
        //output information about person
        public override string ToString()
        {
            return "Name - " + _name + "\nThe birthday year - " + _birthYear.ToString();
        }
        public void Output()
        {
            Console.WriteLine(ToString());
        }
        //Persons with the same names
        public static bool operator == (Person first, Person second)
        {
            return first._name == second._name;
        }
        public static bool operator !=(Person first, Person second)
        {
            return !(first == second);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //An array of data for six people
            Person[] persons = new Person[6];        
            Console.WriteLine("\n\tPlease enter information about each person.");
            for (int i = 0; i < 6; i++)
            {
                Person p = new Person();
                persons[i] = p;
                Console.WriteLine("\n Person #{0}", (i + 1));
                persons[i].Input(); //*1
            }
            //Output information about the name and age of each person
            Console.WriteLine("\n\tInformation about all persons:\n");
            foreach (Person person in persons)
            {
                int age = person.Age();
                Console.WriteLine("Name - {0},\tAge - {1} years.", person.Name, age);
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            //Output information about person with changed name (if age<16)
            Console.WriteLine("\n\tInformation about each person:");
            foreach (Person person in persons)
            {
                int x = person.Age();
                if (x < 16)
                {
                    person.ChangeName();
                }
                person.Output();
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            //Output information about persons with the same names 
            Console.WriteLine("\n\tPersons with the same names:");
            for (int i = 0; i < 6; i++)
            {
                for (int j = i + 1; j < 6; j++)
                {
                    if (persons[i] == persons[j])
                    {
                        Console.Write("Person #{0}\n", (i + 1));
                        persons[i].Output();
                        Console.Write("Person #{0}\n", (j + 1));
                        persons[j].Output();
                        Console.WriteLine();
                    }
                }
            }            
            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
