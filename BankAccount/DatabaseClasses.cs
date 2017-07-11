using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    /// <summary>
    /// Represents a bank customer.
    /// </summary>
    class Customer
    {
        public Customer()
        {}
        /// <summary>
        /// Customer bank account number
        /// </summary>
        public int AcctNo { get; set; }
        /// <summary>
        /// Bank customer first name
        /// </summary>
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

    }

    /// <summary>
    /// Helper class: Provides methods to interact with database.
    /// </summary>
    static class BankDB
    {
        /// <summary>
        /// adds a customer to the database
        /// </summary>
        /// <param name="c">the customer to be added</param>
        /// <exception cref="SqlException">Thrown when any database issues occur</exception>
        /// <exception cref="NullReferenceException"></exception>
        public static void AddCustomer(Customer c)
        {
            if (c == null)
            {
                throw new NullReferenceException();
            }
            //using statement compiles into a try/finally
            //and calls dispose in the finally
            using (var con = new SqlConnection() )
            {
                //TODO
                con.ConnectionString = "";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "query here...";
                //add parameters 

                ////if this was a stored procedure
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandText = "StoredProdedure name here...";

                int rows = cmd.ExecuteNonQuery(); // do something with rows, if necessary

            }
        }
    }
}
