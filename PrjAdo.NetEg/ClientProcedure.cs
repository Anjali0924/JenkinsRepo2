using System;
using System.Collections.Generic;
using System.Text;

namespace PrjAdo.NetEg
{
    //Storeprocedure class connected to client class clientprocedure
    class ClientProcedure
    {
        static void Main()
        {

            DataAccessLayer spobject = new DataAccessLayer();
            Console.WriteLine("1.First Procedure 2.Second");
            int n = Convert.ToInt32(Console.ReadLine());
            switch (n)
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
        }
    }
}
