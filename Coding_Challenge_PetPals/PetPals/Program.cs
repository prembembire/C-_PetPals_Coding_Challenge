using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PetPals.Dao;
using PetPals.Entities;
using PetPals.Exceptions;

namespace PetPals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("\t\t\t------------------------------------PetPals--------------------------------\n");
                    Console.WriteLine("Select any option from below : \n");
                    Console.WriteLine(" 1. Adoption Events");
                    Console.WriteLine(" 2. Donation");
                    Console.WriteLine(" 3. Pet Management");
                    
                    Console.WriteLine(" 4. Exit");
                    Console.Write("\nEnter your choice: ");
                    string number = Console.ReadLine();
                    switch (number)
                    {
                        case "1":
                            bool value = false;
                            while (!value)
                            {
                                Console.Clear();
                                Console.WriteLine("-----------------------------Adoption event!----------------------------------");
                                Console.WriteLine("\n 1. Adopt a pet");
                                
                                Console.WriteLine(" 2. List of Events");
                                Console.WriteLine(" 3. show participants");
                                Console.WriteLine(" 4. Register for an event");
                                
                                Console.WriteLine(" 5. Host an Event");

                                Console.WriteLine(" 6. Back to menu");
                                Console.WriteLine(" 7. Exit");
                                Console.Write("\nEnter your choice: ");
                                string eventChoice = Console.ReadLine();
                                switch (eventChoice)
                                {
                                    case "1":
                                        try
                                        {
                                            Console.Clear();
                                            AdoptionEvent adoption = new AdoptionEvent();
                                            Console.WriteLine("--------------------Pet Adoption---------------");
                                            Console.WriteLine("\nEnter Id of the Pet : ");
                                            int petId = int.Parse(Console.ReadLine());
                                            Console.WriteLine("\nEnter Customer id: ");
                                            int  customerId= int.Parse(Console.ReadLine());
                                            Console.WriteLine();
                                            string Adopted = adoption.Adopt(petId, customerId);

                                            if (Adopted != null)
                                            {
                                                Console.WriteLine(Adopted);
                                                Console.Write("\nReturning to previous menu...");
                                                Thread.Sleep(2000);
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine(ex.Message);
                                            Console.Write("\nReturning to previous menu...");
                                            Thread.Sleep(2000);
                                        }
                                        break;
                                    

                                    case "2":
                                        try
                                        {
                                            Console.Clear();
                                            Console.WriteLine("------------------------List of Pets available for adoption:------------------\n");
                                            AdoptionEvent AllEvents = new AdoptionEvent();
                                            List<AdoptionEvent> events = AllEvents.showAllEvents();
                                            foreach (AdoptionEvent ae in events)
                                            {
                                                Console.WriteLine(ae);
                                            }
                                            Console.Write("\n\n\n\nPress any key to return to previous menu...");
                                            Console.ReadLine();
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine(ex.Message);
                                            Console.Write("\nReturning to previous menu...");
                                            Thread.Sleep(2000);
                                        }
                                        break;

                                    case "3":
                                        try
                                        {
                                            Console.Clear();
                                            Console.WriteLine("\t\t\tParticipant Registration for an event\n");
                                            Participants participant = new Participants();
                                            Console.WriteLine("\nEnter Participant Name: ");
                                            participant.ParticipantName = Console.ReadLine();
                                            Console.WriteLine("\nEnter Participant Type: ");
                                            participant.ParticipantType = Console.ReadLine();
                                            Console.WriteLine("\nEnter the Event ID you want to participate in: ");
                                            participant.EventId = int.Parse(Console.ReadLine());
                                            AdoptionEvent registerParticipent = new AdoptionEvent();

                                            Console.WriteLine();
                                            string participantRes = registerParticipent.RegisterParticipant(participant);

                                            if (participantRes != null)
                                            {
                                                Console.WriteLine(participantRes);
                                                Console.Write("\nReturning to previous menu...");
                                                Thread.Sleep(2000);
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine(ex.Message);
                                            Console.Write("\nReturning to previous menu...");
                                            Thread.Sleep(2000);
                                        }
                                        break;

                                    case "4":
                                        try
                                        {
                                            Console.Clear();
                                            Console.WriteLine("\t\tHere is a list of all participants:\n");
                                            AdoptionEvent listParticipants = new AdoptionEvent();
                                            List<Participants> participants = listParticipants.GetAllParticipants();
                                            foreach (Participants p in participants)
                                            {
                                                Console.WriteLine(p);
                                            }
                                            Console.Write("\n\n\n\nPress any key to return to previous menu...");
                                            Console.ReadLine();
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine(ex.Message);
                                            Console.Write("\nReturning to previous menu...");
                                            Thread.Sleep(2000);
                                        }
                                        break;
                                    case "5":
                                        try
                                        {
                                            Console.Clear();
                                            AdoptionEvent adoptionEvent = new AdoptionEvent();
                                            Console.WriteLine("\t\t\tEvent Registration");
                                            Console.WriteLine("\nEnter Event Name: ");
                                            adoptionEvent.EventName = Console.ReadLine();
                                            Console.WriteLine("\nEnter Event Location: ");
                                            adoptionEvent.Location = Console.ReadLine();
                                            Console.WriteLine("\nEnter the date of hosting the event (dd-MM-yyyy): ");
                                            if (DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
                                            {
                                                adoptionEvent.EventDate = parsedDate;
                                                Console.WriteLine();
                                                string hostRes = adoptionEvent.HostEvent();

                                                if (hostRes != null)
                                                {
                                                    Console.WriteLine(hostRes);
                                                    Console.Write("\nReturning to previous menu...");
                                                    Thread.Sleep(2000);
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine("Invalid date format.");
                                                Console.Write("\nReturning to previous menu...");
                                                Thread.Sleep(2000);
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine(ex.Message);
                                            Console.Write("\nReturning to previous menu...");
                                            Thread.Sleep(2000);
                                        }
                                        break;
                                    case "6":
                                        value = true;
                                        break;

                                    case "7":
                                        Exit();
                                        break;

                                    default:
                                        Console.Write("\nEnter a valid Number");
                                        Thread.Sleep(2000);
                                        break;
                                }
                            }
                            break;
                        case "2":
                            bool val= false;
                            while (!val)
                            {
                                Console.Clear();
                                Console.WriteLine("\t\t\t\tDonation Page\n");
                                Console.WriteLine("You can make a donation in the following ways:\n");
                                Console.WriteLine(" 1. Donate an Item");
                                Console.WriteLine(" 2. Donate Amount");
                                Console.WriteLine(" 3. Back to menu");
                                Console.WriteLine(" 4. Exit");
                                Console.Write("\nSelect the type of donation you would like to make: ");
                                string choice = Console.ReadLine();
                                switch (choice)
                                {
                                    

                                    case "1":
                                        Console.Clear();
                                        Console.WriteLine("-----------------------------------Donate an Item----------------\n");
                                        ItemDonation itemDonation = new ItemDonation();
                                        Console.Write("\nEnter Name: ");
                                        itemDonation.DonorName = Console.ReadLine();
                                        Console.Write("\nItem name to be donated : ");
                                        itemDonation.ItemType = Console.ReadLine();

                                        string itemRes = itemDonation.RecordDonation();
                                        if (itemRes != null)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine(itemRes);
                                            Console.Write("\nReturning to previous menu...");
                                            Thread.Sleep(2000);
                                        }
                                        break;
                                    case "2":
                                        Console.Clear();
                                        Console.WriteLine("--------------------------------------Donate Cash--------------\n");
                                        CashDonation cashDonation = new CashDonation();
                                        Console.Write("\nEnter your Name: ");
                                        cashDonation.DonorName = Console.ReadLine();
                                        Console.Write("\nEnter Amount you want to Donate : ");
                                        try
                                        {
                                            cashDonation.Amount = double.Parse(Console.ReadLine());
                                            if (cashDonation.Amount > 0)
                                            {
                                                string cashRes = cashDonation.RecordDonation();
                                                if (cashRes != null)
                                                {
                                                    Console.WriteLine();
                                                    Console.WriteLine(cashRes);
                                                    Console.Write("\nReturning to previous menu...");
                                                    Thread.Sleep(2500);
                                                }
                                            }
                                            else
                                                throw new InsufficientFundsException("Donation amount is less than 1000.0");
                                        }
                                        catch (InsufficientFundsException ex)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine(ex.Message);
                                            Console.Write("\nReturning to previous menu...");
                                            Thread.Sleep(2000);
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine(ex.Message);
                                            Console.Write("\nReturning to previous menu...");
                                            Thread.Sleep(2000);
                                        }
                                        break;

                                    case "3":
                                        val = true;
                                        break;

                                    case "4":
                                        Exit();
                                        break;

                                    default:
                                        Console.Write("\nPlease enter a valid choice");
                                        Thread.Sleep(2000);
                                        break;
                                }
                            }
                            break;

                        case "3":
                            bool petReturn = false;
                            while (!petReturn)
                            {
                                Console.Clear();
                                Console.WriteLine("\t\t\tWelcome to Pet management portal");
                                Console.WriteLine("\n 1. Available pets for adoption");
                                Console.WriteLine(" 2. Add a pet data");
                                Console.WriteLine(" 3. Remove a pet data");
                                Console.WriteLine(" 4. Return to main menu");
                                Console.WriteLine(" 5. Exit");
                                Console.Write("\nEnter your choice: ");
                                string petChoice = Console.ReadLine();
                                switch (petChoice)
                                {
                                    case "1":
                                        Console.Clear();
                                        Console.WriteLine("\tHere are all the pets that are currently available for adoption: ");
                                        IPetShelter listAvailablePets = new PetShelter();
                                        List<Pet> availablePets = listAvailablePets.ListAvailablePets();
                                        foreach (Pet pet in availablePets)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine(pet);
                                        }
                                        Console.Write("\n\n\n\nPress any key to return to previous menu...");
                                        Console.ReadLine();
                                        break;

                                    case "2":
                                        try
                                        {
                                            Console.Clear();
                                            IPetShelter addPet = new PetShelter();
                                            Pet petDetails = new Pet();
                                            Console.WriteLine("\t\t\t\tNew Pet Regesitration\n\n");
                                            Console.WriteLine("To add details of a pet in our system, please provide following info:\n");
                                            Console.Write("Enter the Name of pet: ");
                                            petDetails.Name = Console.ReadLine();
                                            Console.Write("\nEnter the Age of pet: ");
                                            petDetails.Age = int.Parse(Console.ReadLine());
                                            if (petDetails.Age > 0)
                                            {
                                                Console.Write("\nEnter the Type(E.g. Cat, Dog, etc.): ");
                                                petDetails.Type = Console.ReadLine();
                                                Console.Write("\nEnter the Breed: ");
                                                petDetails.Breed = Console.ReadLine();

                                                Console.WriteLine();
                                                string res = addPet.AddPet(petDetails);

                                                if (res != null)
                                                {
                                                    Console.WriteLine(res);
                                                    Console.Write("\nReturning to previous menu...");
                                                    Thread.Sleep(2000);
                                                }
                                            }
                                            else throw new InvalidPetAgeException("Age should be a positive integer value.");
                                        }
                                        catch (InvalidPetAgeException ipae)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine(ipae.Message);
                                            Console.Write("\nReturning to previous menu...");
                                            Thread.Sleep(2000);
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                            Console.Write("\nReturning to previous menu...");
                                            Thread.Sleep(2000);
                                        }
                                        break;

                                    case "3":
                                        Console.Clear();
                                        Console.WriteLine("\t\t\t\tPet Details Deletion\n");
                                        Console.Write("To remove data of a specific pet from our system, please enter the ID of the pet: ");
                                        try
                                        {
                                            int removePetId = int.Parse(Console.ReadLine());
                                            IPetShelter removePet = new PetShelter();
                                            Console.WriteLine();
                                            string removePetRes = removePet.RemovePet(removePetId);
                                            if (removePetRes != null)
                                            {
                                                Console.WriteLine(removePetRes);
                                                Console.Write("\nReturning to previous menu...");
                                                Thread.Sleep(3500);
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine(ex.Message);
                                            Console.Write("\nReturning to previous menu...");
                                            Thread.Sleep(2000);
                                        }
                                        break;

                                    case "4":
                                        petReturn = true;
                                        break;

                                    case "5":
                                        Exit();
                                        break;

                                    default:
                                        Console.WriteLine();
                                        Console.Write("Please enter a valid choice");
                                        Thread.Sleep(2000);
                                        break;
                                }
                            }
                            break;

                        

                        case "4":
                            Exit();
                            break;

                        default:
                            Console.Write("\nPlease enter a valid choice");
                            Thread.Sleep(2000);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
            }
        }

        public static void Exit()
        {
            Console.WriteLine();
            Console.Write("Exiting...");
            Thread.Sleep(2000);
            Console.WriteLine();
            Environment.Exit(0);
        }
    }
}
