using System;
using System.Collections.Generic;
using System.Configuration;
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
#if DEBUG
                //TODO
                con.ConnectionString =
                    ConfigurationManager
                    .ConnectionStrings[ "BankDBCon" ]
                    .ConnectionString;
#else
                con.ConnectionString = "production string";
#endif

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO Customer(FirstName, LastName, Address, Email)"
                    + " VALUES(@FName, @LName, @Address, @Email)";

                ////if this was a stored procedure
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandText = "INSERT_Customer";

                //add parameters
                cmd.Parameters.AddWithValue("@FName", c.FirstName);
                cmd.Parameters.AddWithValue("@LName", c.LastName);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Email", c.Email);

                int rows = cmd.ExecuteNonQuery(); // do something with rows, if necessary

            }
        }
    }
}
