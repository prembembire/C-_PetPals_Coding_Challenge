using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetPals.Entities;

namespace PetPals.Dao
{
    internal interface IPetShelter
    {
        string AddPet(Pet pet);
        string RemovePet(int petId);
        List<Pet> ListAvailablePets();
    }
}
