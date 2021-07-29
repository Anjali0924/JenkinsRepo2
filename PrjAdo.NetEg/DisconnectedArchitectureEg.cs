using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace PrjAdo.NetEg
{
    class DAL
    {
        SqlConnection con = null;
        //SqlCommand cmd = null; //this is only for connected architecture

        public SqlConnection GetConnection()
        {
            //user defined method            
            con = new SqlConnection("Data Source = DESKTOP-QS39884; Initial Catalog = Northwind; Integrated Security = true");
            con.Open();
            return con;
        }

        public void DisplayRegion()
        {
            try
            {
                con = GetConnection();
                SqlDataAdapter da = new SqlDataAdapter("select * from Region", con);  //sqldataadapter is only for disconnected architecture
                DataSet ds = new DataSet(); //collection of tables
                                            //putting the table inside dataset
                da.Fill(ds, "NWREGION");

                //reading the table info from dataset

                DataTable dt = ds.Tables["NWREGION"];

                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn col in dt.Columns)
                    {
                        Console.Write(row[col]);
                        Console.Write(" ");
                    }
                    Console.WriteLine(" ");
                }
                // adding one more table to dataset : Shipper
                /* Console.WriteLine(" -------------");
                 Console.WriteLine(" -----Shipper Table--------");
                 da = new SqlDataAdapter("Select * from Shippers", con);
                 da.Fill(ds, "NWSHIPPERS");
                 DataTable dt1 = ds.Tables["NWSHIPPERS"];
                 foreach (DataRow row in dt1.Rows)
                 {
                     foreach (DataColumn col in dt1.Columns)
                     {
                         Console.Write(row[col]);
                         Console.Write(" ");
                     }
                     Console.WriteLine(" ");
                 } */



                // Insert,Update, delete operation
                SqlCommandBuilder scb = new SqlCommandBuilder(da);
                da.Fill(ds);

                // Inserting or adding a new row
                //Creating a new row in NWREGION 
                DataRow row1 = ds.Tables["NWREGION"].NewRow();
                row1["RegionID"] = 12;
                row1["RegionDescription"] = "anju";
                // Adding row to database in datasete
                ds.Tables["NWREGION"].Rows.Add(row1); //added in the dataset

                da.Update(ds, "NWREGION");  //added in the database
                Console.WriteLine("------------");


                dt = ds.Tables["NWREGION"];
                foreach (DataRow Datarow in dt.Rows)
                {
                    foreach (DataColumn DataColumn in dt.Columns)
                    {
                        Console.Write(Datarow[DataColumn]);
                        Console.Write(" ");
                    }
                    Console.WriteLine(" ");
                }
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



    class DisconnectedArchitectureEg
    {
        static void Main()
        {
            DAL d = new DAL();
            d.DisplayRegion();
        }
    }





}
