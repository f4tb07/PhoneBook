using System;
using System.Collections.Generic;
using System.Linq;

namespace jointest
{
    class Program
    {
        static void Main(string[] args)
        {
             
                Person magnus = new Person { Name = "Hedlund, Magnus" };
                Person terry = new Person { Name = "Adams, Terry" };
                Person charlotte = new Person { Name = "Weiss, Charlotte" };

                Pet barley = new Pet { Name = "Barley", Owner = terry };
                Pet boots = new Pet { Name = "Boots", Owner = terry };
                Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
                Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

                List<Person> people = new List<Person> { magnus, terry, charlotte };
                List<Pet> pets = new List<Pet> { barley, boots, whiskers, daisy };

            // Create a list of Person-Pet pairs where 
            // each element is an anonymous type that contains a
            // Pet's name and the name of the Person that owns the Pet.
            //var query =
            //    people.Join(pets,
            //                person => person,
            //                pet => pet.Owner,
            //                (person, pet) =>
            //                    new { OwnerName = person.Name, Pet = pet.Name });
            var q = people.Join(pets, p => p, pet => pet.Owner, (ps, pt) => new { OwnerName = ps.Name, Pet = pt.Name });

                foreach (var obj in q)
                {
                    Console.WriteLine(
                        "{0} - {1}",
                        obj.OwnerName,
                        obj.Pet);
                }
            }

        }
    }

