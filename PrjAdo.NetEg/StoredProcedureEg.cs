using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;  //download system.data.common

namespace PrjAdo.NetEg
{
    //this data access layer class contains data related to database
    class DataAccessLayer
    {
        SqlConnection con = null;
        SqlCommand cmd = null;


        public SqlConnection GetConnection()
        {
            con = new SqlConnection(
                  "Data Source = DESKTOP-QS39884; Initial Catalog = Northwind; Integrated Security = true");
            con.Open();
            return con;
        }


        //cProcedure without parameter
        internal void CallTenMostExpensiveProduct()
        {
            try
            {
                con = GetConnection();
                //procedure name in sqlserver
                cmd = new SqlCommand("Ten Most Expensive Products", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr[0] + " " + dr[1]);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

            finally
            {
                con.Close();
            }
        }

        //cProcedure with parameter
        internal void CallCustOrdersOrder(string cid)
        {
            try
            {
                con = GetConnection();
                //procedure name in sqlserver
                cmd = new SqlCommand("CustOrdersOrders", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerId", cid);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr[0] + " " + dr[1] +" " +dr[2]);
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
    class StoredProcedureEg
    {
        //go to the clientprocedure class
       /* static void Main()
        {

            DataAccessLayer spobject = new DataAccessLayer();
            Console.WriteLine("1.First Procedure 2.Second");
            int n = Convert.ToInt32(Console.ReadLine());
            switch(n)
            {
                case 1:
                    
                    spobject.CallTenMostExpensiveProduct();
                    break;

                case 2:
                    Console.WriteLine("Enter the Customer Id");
                    string cid = Console.ReadLine();
                    spobject.CallCustOrdersOrder(cid);
                    break;

                default:
                    Console.WriteLine("enter Valid Number");
                    break;
            }
           
        */
            
        }
    }

