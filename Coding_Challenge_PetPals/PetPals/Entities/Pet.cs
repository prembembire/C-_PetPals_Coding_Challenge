using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetPals.Util;

namespace PetPals.Entities
{
    internal class Pet
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Breed { get; set; }

        public string Type {  get; set; }

        public Pet() { }

        public Pet(string name, int age, string breed)
        {
            Name = name;
            Age = age;
            Breed = breed;
        }

        public override string ToString()
        {
            return $"Name: {Name}\t Age: {Age}\t Type: {Type}\t Breed: {Breed}";
        }
    }
}
