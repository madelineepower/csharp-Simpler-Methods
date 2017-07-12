using System;
using System.Collections.Generic;

namespace expression_members
{
    class Program
    {
        static void Main(string[] args)
        {   
            Bug bug1 = new Bug ("Olivia", "Ladybug", new List<string>(){"Spider", "Frog"}, new List<string>(){"Aphid"});
            Bug bug2 = new Bug ("John", "Spider", new List<string>(){"Humans", "Murphy"}, new List<string>(){"Ladybug", "Flies"});

            Console.WriteLine($"This is a bug: {bug1.Name}");
            Console.WriteLine($"This is also a bug: {bug2.Name}");
            Console.WriteLine($"The {bug1.Species}'s predators: {bug1.PredatorList()}");
            Console.WriteLine($"The {bug1.Species}'s prey: {bug1.PreyList()}");
            Console.WriteLine($"The {bug2.Species}'s predators: {bug2.PredatorList()}");
            Console.WriteLine($"The {bug2.Species}'s prey: {bug2.PreyList()}");

            string response = bug1.Eat("Aphid");
            string response2 = bug2.Eat("french fries");

            Console.WriteLine(response);
            Console.WriteLine(response2);

        }
    }
}

public class Bug
{
    /*
        You can declare a typed public property, make it read-only,
        and initialize it with a default value all on the same
        line of code in C#. Readonly properties can be set in the
        class' constructors, but not by external code.
    */
    public string Name { get; } = "";
    public string Species { get; } = "";
    public ICollection<string> Predators { get; } = new List<string>();
    public ICollection<string> Prey { get; } = new List<string>();

    // Convert this readonly property to an expression member
    public string FormalName => $"{this.Name} the {this.Species}";

    // Class constructor
    public Bug(string name, string species, List<string> predators, List<string> prey)
    {
        this.Name = name;
        this.Species = species;
        this.Predators = predators;
        this.Prey = prey;
    }

    // Convert this method to an expression member
    public string PreyList() => string.Join(",", this.Prey);

    // Convert this method to an expression member
    public string PredatorList() => string.Join(",", this.Predators); 

    // Convert this to expression method (hint: use a C# ternary)
    public string Eat(string food) => this.Prey.Contains(food) ? $"{this.Name} ate the {food}." : $"{this.Name} is still hungry.";  
    // {
    //     if (this.Prey.Contains(food))
    //     {
    //         return $"{this.Name} ate the {food}.";
    //     } else {
    //         return $"{this.Name} is still hungry.";
    //     }
    // }
}
