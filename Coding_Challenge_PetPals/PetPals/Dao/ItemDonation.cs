using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PetPals.Entities;
using PetPals.Util;

namespace PetPals.Dao
{
    internal class ItemDonation : Donation
    {
        SqlConnection conn=null;
        /*SqlCommand cmd = null;*/

        /*public ItemDonation()
        {
            conn = DBConnUtil.GetConnection();
            cmd = new SqlCommand();
            Date = DateTime.Now;
        }*/
        public string ItemType { get; set; }


        public override string RecordDonation()
        {
            string response = null;
            try
            {
                using (conn=DBConnUtil.GetConnection())
                {
                    string donationType = "Item";
                    SqlCommand cmd = new SqlCommand($"Insert into Donations (DonorName, DonationType, DonationItem, DonationDate) OUTPUT INSERTED.DonationID values('{DonorName}', '{donationType}','{ItemType}','{Date}')",conn);
                    
                    conn.Open();
                    object NewId = cmd.ExecuteScalar();
                    if (NewId != null)
                    {
                        response = "Thank you for donating the Item : " + ItemType;
                    }
                    else
                        response = "Something went wrong";
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
    }
}
