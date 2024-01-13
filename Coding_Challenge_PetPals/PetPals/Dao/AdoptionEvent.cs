using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using PetPals.Entities;
using PetPals.Util;

namespace PetPals.Dao
{
    internal class AdoptionEvent
    {
        SqlConnection conn=null;
       
        public int EventID { get; set; }

        public string EventName { get; set; }

        public DateTime EventDate { get; set; }

        public string Location { get; set; }

        public List<AdoptionEvent> showAllEvents()
        {
            List<AdoptionEvent> allEvents = new List<AdoptionEvent>();
            try
            {
                using (conn=DBConnUtil.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("select * from AdoptionEvents", conn);
                    
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        AdoptionEvent adoptionEvent = new AdoptionEvent();
                        adoptionEvent.EventID = (int)reader["EventID"];
                        adoptionEvent.EventName = (string)reader["EventName"];
                        adoptionEvent.EventDate = (DateTime)reader["EventDate"];
                        adoptionEvent.Location = (string)reader["Location"];
                        allEvents.Add(adoptionEvent);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.Message);
                Console.Write("\nReturning to previous menu...");
                Thread.Sleep(2000);
            }
            return allEvents;
        }

        public string Adopt(int petId, int userId)
        {
            string response = null;
            try
            {
                using (conn=DBConnUtil.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand($"update Pets set AvailableForAdoption=0 where PetID={petId}", conn);
                    
                    conn.Open();
                    int petUpdate = cmd.ExecuteNonQuery();
                    cmd.CommandText = "insert into Adoption values(@petid, @userid);";
                    cmd.Parameters.AddWithValue("@userid", userId);
                    int userUpdate = cmd.ExecuteNonQuery();
                    if (userUpdate > 0 && petUpdate > 0)
                    {
                        response = "Congratulations! You have successfully adopted a pet!";
                    }
                    else
                        response= "Something went wrong";
                }
            }
            catch (SqlException se)
            {
                if (se.Class == 16)
                {
                    Console.WriteLine();
                    Console.WriteLine("Ivalid petid or userid.Please enter valid details.");
                    Console.Write("\nReturning to previous menu...");
                    Thread.Sleep(3000);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.Message);
                Console.Write("\nReturning to previous menu...");
                Thread.Sleep(2000);
            }
            return response;
        }

        public string HostEvent()
        {
            string response = null;
            try
            {
                using (conn = DBConnUtil.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand($"insert into AdoptionEvents OUTPUT INSERTED.EventID values ('{EventName}', '{EventDate}', '{Location}')", conn);
                    cmd.CommandText = "insert into AdoptionEvents OUTPUT INSERTED.EventID values (@name, @date, @location)";
                    
                    conn.Open();
                    object newId = cmd.ExecuteScalar();

                    if (newId != null)
                    {
                        response = "Event Registered Successfully. ID : " + newId;
                    }
                    else
                    {
                        response = "Something went wrong";
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
            return response;
        }

        public string RegisterParticipant(Participants participant)
        {
            string response = null;
            try
            {
                using (conn)
                {
                    SqlCommand cmd = new SqlCommand($"INSERT into Participants OUTPUT INSERTED.EventID values ('{participant.ParticipantName}','{participant.ParticipantType}','{participant.EventId}')",conn);
                    
                    object newId = cmd.ExecuteScalar();

                    if (newId != null)
                    {
                        response = "Thank you for registering and Your ID is : " + newId;
                    }
                    else
                    {
                        response = "Something went wrong";
                    }
                }
            }
            catch (SqlException se)
            {
                if(se.Class == 16)
                {
                    Console.WriteLine();
                    Console.WriteLine($"There is no event present with id : {participant.EventId}. Please enter an existing event id.");
                    Console.Write("\nReturning to previous menu...");
                    Thread.Sleep(3000);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
                Console.Write("\nReturning to previous menu...");
                Thread.Sleep(2000);
            }
            return response;
        }

        public List<Participants> GetAllParticipants()
        {
            List<Participants> participants = new List<Participants>();
            try
            {
                using (conn = DBConnUtil.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("Select * from Participants",conn);
                   
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            participants.Add(new Participants() { ParticipantID = (int)dr[0], ParticipantName = dr[1].ToString(), ParticipantType = dr[2].ToString(), EventId = (int)dr[3] });
                        }
                        dr.Close();
                        return participants;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.Message);
                Console.Write("\nReturning to previous menu...");
                Thread.Sleep(2000);
            }
            finally
            {
                conn.Close();
            }
            return new List<Participants>();
        }

        public override string ToString()
        {
            return $"Event ID : {EventID}\n Name: {EventName}\n Date: {EventDate}\n Location: {Location}\n\n";
        }
    }
}