using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PetPals.Entities;
using PetPals.Exceptions;
using PetPals.Util;

namespace PetPals.Dao
{
    internal class PetShelter : IPetShelter
    {
        SqlConnection conn=null;
        /*SqlCommand cmd = null;*/

        public PetShelter()
        {
            /*conn = DBConnUtil.GetConnection();*/
            /*cmd = new SqlCommand();*/
        }

        public string AddPet(Pet pet)
        {
            string response = null;
            try
            {
                using (conn=DBConnUtil.GetConnection())
                {
                    bool petAvailability = true;
                    SqlCommand cmd = new SqlCommand($"insert into Pets OUTPUT INSERTED.PetID values ('{pet.Name}', '{pet.Age}', '{pet.Breed}', '{pet.Type}', '{petAvailability}')", conn);
                    /*cmd.CommandText = "insert into Pets OUTPUT INSERTED.PetID values (@name, @age, @breed, @type, @petAvailability)";
                    cmd.Parameters.AddWithValue("@name", pet.Name);
                    cmd.Parameters.AddWithValue("@age", pet.Age);
                    cmd.Parameters.AddWithValue("@breed", pet.Breed);
                    cmd.Parameters.AddWithValue("@type", pet.Type);
                    
                    cmd.Parameters.AddWithValue("@petAvailability", petAvailability);

                    cmd.Connection = conn;*/
                    conn.Open();
                    object newId = cmd.ExecuteScalar();

                    if (newId != null)
                    {
                        response = "Pet added Successfully ID =" + newId;
                    }
                    else
                    {
                        response = "Something went wrong";
                    }
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
                Console.Write("\nReturning to previous menu...");
                Thread.Sleep(2000);
            }
            return response;
        }

        public List<Pet> ListAvailablePets()
        {
            List<Pet> availablePets = new List<Pet>();
            try
            {
                using (conn=DBConnUtil.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("select * from Pets where AvailableForAdoption=1", conn);
                    
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Pet pet = new Pet((string)reader["Name"], (int)reader["age"], (string)reader["Breed"]);
                        pet.Type = (string)reader["Type"];
                        availablePets.Add(pet);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
                Console.Write("\nReturning to previous menu...");
                Thread.Sleep(2000);
            }
            return availablePets;
        }

        public string RemovePet(int petId)
        {
            string response = null;
            try
            {
                using (conn = DBConnUtil.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand($"Delete from Pets Where PetId={petId}",conn);
                    
                    conn.Open();
                    int removePetStatus = cmd.ExecuteNonQuery();
                    if (removePetStatus > 0)
                        response = $"Data of pet having ID : {petId} has been deleted succefully.";
                    else
                        response = $"No pet having id : {petId}";
                }
            }
            catch ( Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
                Console.Write("\nReturning to previous menu...");
                Thread.Sleep(2000);
            }
            return response;
        }

        //        Methods:
        //• AddPet(Pet pet) : Adds a pet to the list of available pets.
        //• RemovePet(Pet pet) : Removes a pet from the list of available pets.
        //• ListAvailablePets() : Lists all available pets in the shelter.
    }
}
