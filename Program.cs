using System;
using System.Linq;
using System.Collections.Generic;

interface IMethods
{
    void InfoAnimal();
}
class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }
    public bool IsAlive { get; set; }

    public Animal(string name, int age, bool isAlive)
    {
        Name = name;
        Age = age;
        IsAlive = isAlive;
    }

    public virtual void InfoAnimal()
    {
        Console.WriteLine($" ");
    }
}

class Dog : Animal, IMethods
{
    public string Breed { get; set; }
    public Dog(string name, int age, bool isAlive, string breed) : base(name, age, isAlive)
    {
        Breed = breed;
    }

    public override void InfoAnimal()
    {
        Console.WriteLine($"{Name} is a breed of {Breed} that is {Age} years old.");
        Console.WriteLine(IsAlive ? $"{Name} is still alive" : "Is no longer alive");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Dog dog = new Dog("Roger", 19, true, "Husky");
        dog.InfoAnimal();
    }
}
