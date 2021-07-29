using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient; // 1.Installing the package for working with Mssqlserver 

namespace PrjAdo.NetEg
{
    class Shipper
    {
        public int ShipperId { get; set; }
        public string Companyname { get;set; }
        public string Phone { get; set; }

        #region GetShipper
        public void GetShipper()
        {
            Console.WriteLine("Enter the shipper name or company name");
            Companyname = Console.ReadLine();
            Console.WriteLine("Enter the Phoneno");
            Phone = Console.ReadLine();
        }
        #endregion


        public void LooseShipper()
        {
            Console.WriteLine("Enter the Shipper name or company name");
            Companyname = Console.ReadLine();
        }

        public void EditShipper()
        {
            Console.WriteLine("Enter the Shipper id");
            ShipperId = Convert.ToInt32(Console.ReadLine());
            GetShipper();
        }
    }
    class ConnectedArchitectureEg1
    {
        static void Main()
        {
            //2. Create sqlconnection object
            SqlConnection con = null;

            //creating command object
            SqlCommand cmd = null; //this is only for connected architecture

            try
            {
                //3 Windows Authentication
                con = new SqlConnection(
                 "Data Source = DESKTOP-QS39884; Initial Catalog = Northwind; Integrated Security = true");



                //Sql server authentication
                // con = new SqlConnection(
                // "Data Source= DESKTOP-U8J1M3C\\MSSQLSERVER01;Initial Catalog=Northwind;User ID=sa;Password=newuser123#");


                //4
                con.Open();

                //creating object of shipper class
                Shipper shipper = new Shipper();



                //INSERTION
                //calling getshipper method

                 /*shipper.GetShipper();

                 cmd = new SqlCommand("insert into Shippers(CompanyName,Phone) values(@cname,@phone)", con);
                 cmd.Parameters.AddWithValue("@cname", shipper.Companyname);
                 cmd.Parameters.AddWithValue("@phone", shipper.Phone);
                 int i = cmd.ExecuteNonQuery(); //returns int or number of rows affected
                 Console.WriteLine("No of Rows affected:{0}", i);  */



                //DELETION
                //calling looseshipper method

                 /*shipper.LooseShipper();
                 cmd = new SqlCommand("delete from Shippers where CompanyName=@cname", con);
                 cmd.Parameters.AddWithValue("@cname", shipper.Companyname);
                 int i = cmd.ExecuteNonQuery();  //returns int or number of rows affected
                 Console.WriteLine("No of Rows deleted:{0}", i);
                 cmd.Parameters.Clear(); //to clear  the object values */


                //SELECT

                /* SqlDataReader dr;
                 cmd = new SqlCommand("select * from Shippers", con);
                 dr = cmd.ExecuteReader();
                 while (dr.Read())
                 {
                     //Console.WriteLine(dr[0] + " " + dr[1] + " " + dr[2]);
                     Console.WriteLine(dr["CompanyName"] + " " + dr["Phone"]);
                 }
                */

                //UPDATE
                //calling edit shipper method

                /*shipper.EditShipper();
                cmd = new SqlCommand("update Shippers set CompanyName=@cname, Phone=@phone where ShipperID=@id", con);
                cmd.Parameters.AddWithValue("@id", shipper.ShipperId);
                cmd.Parameters.AddWithValue("@cname", shipper.Companyname);
                cmd.Parameters.AddWithValue("@phone", shipper.Phone);
                
                int i = cmd.ExecuteNonQuery();  //returns int or number of rows affected
                Console.WriteLine("No of Rows Updated:{0}", i); 
                */

                //SCALAR VALUE
                /*cmd = new SqlCommand("select count(ShipperID) from Shippers", con);
                Console.WriteLine("Total Shippers :{0}", Convert.ToInt32(cmd.ExecuteScalar())); 
               */





            }

            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            finally
            {
                con.Close();
            }
        }

    }
}
