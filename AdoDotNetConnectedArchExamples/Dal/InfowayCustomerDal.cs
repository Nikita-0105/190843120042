using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using AdoDotNetConnectedArchExamples.Validations;

namespace AdoDotNetConnectedArchExamples.Dal
{
    public class InfowayCustomerDal
    {
        public DataTable GetAllCustomers()
        {
            DataTable customerTable = new DataTable("Customers");
            using (MySqlConnection CN = new MySqlConnection(ConfigurationManager.ConnectionStrings["InfowayMySqlConStr"].ConnectionString))
            {
                CN.Open();
                MySqlCommand CMD = new MySqlCommand();
                CMD.Connection = CN;
                CMD.CommandType = CommandType.StoredProcedure;
                CMD.CommandText = "GetAllInfowayCustomers";
                MySqlDataReader DR = CMD.ExecuteReader();
                customerTable.Load(DR);
                DR.Close();
                CN.Close();
            }
            return customerTable;
        }
        public DataTable InsertCustomer(InfowayCustomer customer)
        {
            DataTable customerTable = new DataTable("Customers");
            int result = 0;
            using (MySqlConnection CN = new MySqlConnection(ConfigurationManager.ConnectionStrings["InfowayMySqlConStr"].ConnectionString))
            {
                CN.Open();
                MySqlCommand CMD = new MySqlCommand();
                CMD.Connection = CN;
                CMD.CommandType = CommandType.StoredProcedure;
                CMD.CommandText = "InsertInfowayCustomers";
                CMD.Parameters.AddWithValue("p_CustomerId", customer.CustomerId);
                CMD.Parameters.AddWithValue("p_ContactName", customer.ContactName);
                CMD.Parameters.AddWithValue("p_City", customer.City);
                result = CMD.ExecuteNonQuery();
                CN.Close();
            }
            if (result>0)
            {
                return GetAllCustomers();
            }
            else
            {
                throw new Exception("Insert Optioration failed! Please retry!");
            }
        }
        public DataTable UpdateCustomer(InfowayCustomer customer)
        {
            DataTable customerTable = new DataTable("Customers");
            int result = 0;
            using (MySqlConnection CN = new MySqlConnection(ConfigurationManager.ConnectionStrings["InfowayMySqlConStr"].ConnectionString))
            {
                CN.Open();
                MySqlCommand CMD = new MySqlCommand();
                CMD.Connection = CN;
                CMD.CommandType = CommandType.StoredProcedure;
                CMD.CommandText = "UpdateInfowayCustomers";
                CMD.Parameters.AddWithValue("p_CustomerId", customer.CustomerId);
                CMD.Parameters.AddWithValue("p_ContactName", customer.ContactName);
                CMD.Parameters.AddWithValue("p_City", customer.City);
                result = CMD.ExecuteNonQuery();
                CN.Close();
            }
            if (result > 0)
            {
                return GetAllCustomers();
            }
            else
            {
                throw new Exception("Insert Optioration failed! Please retry!");
            }
        }
        public DataTable DeleteCustomer(InfowayCustomer customer)
        {
            DataTable customerTable = new DataTable("Customers");
            int result = 0;
            using (MySqlConnection CN = new MySqlConnection(ConfigurationManager.ConnectionStrings["InfowayMySqlConStr"].ConnectionString))
            {
                CN.Open();
                MySqlCommand CMD = new MySqlCommand();
                CMD.Connection = CN;
                CMD.CommandType = CommandType.StoredProcedure;
                CMD.CommandText = "DeleteInfowayCustomers";
                CMD.Parameters.AddWithValue("p_CustomerId", customer.CustomerId);
                result = CMD.ExecuteNonQuery();
                CN.Close();
            }
            if (result > 0)
            {
                return GetAllCustomers();
            }
            else
            {
                throw new Exception("Insert Optioration failed! Please retry!");
            }
        }
    }
}
