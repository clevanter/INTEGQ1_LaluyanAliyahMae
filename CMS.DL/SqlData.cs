using System;
using System.Data.SqlClient;

namespace CMS.DL
{
    public class SqlData
    {
        static string connectionString = "Data Source=LAPTOP-L1JVRRHR;Initial Catalog=ClientManagementSystem;Integrated Security=True";
        static SqlConnection sqlConnection = new SqlConnection(connectionString);
        

        
        static public string ValidateUser(string username, string password)
        {
            var selectStatement = "SELECT Username FROM [ClientManagementSystem].[dbo].[Log] WHERE Username = @Username AND Password = @Password";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@Username", username);
            selectCommand.Parameters.AddWithValue("@Password", password);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            var authorizedPersonnel = reader.Read().ToString(); 
            sqlConnection.Close();
            return authorizedPersonnel; 
        }

        static public string CompanyNameValidation(string companyname)
        {
            var selectStatement = "SELECT CompanyName FROM [ClientManagementSystem].[dbo].[Lead] WHERE CompanyName = @CompanyName";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@CompanyName", companyname);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            var companyNameValidated = reader.Read().ToString();
            sqlConnection.Close();
            return companyNameValidated;
        }

        static public string ConvertLead()
        {
            var selectStatement = "INSERT INTO dbo.Contacts (LeadSource, FirstName, LastName, Position, EmailAdd, MobileNum, PhoneNum," +
                "SkypeID) SELECT LeadSource, FirstName, LastName, Position, EmailAdd, MobileNum, PhoneNum," +
                "SkypeID FROM dbo.Lead";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            var leadConverted = reader.Read().ToString();
            sqlConnection.Close();
            return leadConverted;
            
        }


        static public string InsertLead(string companyname, string firstname, string lastname, string position, string emailadd, long mobilenum,
            long phonenum, string websitelink, string leadsource, string leadstatus, string industry, int employees, decimal annualrevenue,
            int rating, string skypeid)
        {
            var selectStatement = "INSERT INTO dbo.Lead (CompanyName, FirstName, LastName, Position, EmailAdd, MobileNum," +
                   "PhoneNum, WebsiteLink, LeadSource, LeadStatus, Industry, Employees, AnnualRevenue, Rating, SkypeID) VALUES (@CompanyName, " +
                "@FirstName, @LastName, @Position, @EmailAdd, @MobileNum, @PhoneNum , @WebsiteLink, @LeadSource, @LeadStatus, @Industry, @Employees, @AnnualRevenue," +
                "@Rating, @SkypeID)";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@CompanyName", companyname);
            selectCommand.Parameters.AddWithValue("@FirstName", firstname);
            selectCommand.Parameters.AddWithValue("@LastName", lastname);
            selectCommand.Parameters.AddWithValue("@Position", position);
            selectCommand.Parameters.AddWithValue("@EmailAdd", emailadd);
            selectCommand.Parameters.AddWithValue("@Mobilenum", mobilenum);
            selectCommand.Parameters.AddWithValue("@PhoneNum", phonenum);
            selectCommand.Parameters.AddWithValue("@WebsiteLink", websitelink);
            selectCommand.Parameters.AddWithValue("@LeadSource", leadsource);
            selectCommand.Parameters.AddWithValue("@LeadStatus", leadstatus);
            selectCommand.Parameters.AddWithValue("@Industry", industry);
            selectCommand.Parameters.AddWithValue("@Employees", employees);
            selectCommand.Parameters.AddWithValue("@AnnualRevenue", annualrevenue);
            selectCommand.Parameters.AddWithValue("@Rating", rating);
            selectCommand.Parameters.AddWithValue("@SkypeID", skypeid);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            var newLead = reader.Read().ToString();
            sqlConnection.Close();
            return newLead;

        }
        static public string ShowLead()
        {
            var selectStatement = "SELECT CompanyName, FirstName, LastName, Position, EmailAdd, MobileNum," +
                   "PhoneNum, WebsiteLink, LeadSource, LeadStatus, Industry, Employees, AnnualRevenue, Rating, SkypeID FROM dbo.Lead";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("———————————————— Lead ————————————————\n");
                Console.WriteLine($"Company Name: {reader["CompanyName"]}");
                Console.WriteLine($"First Name: {reader["FirstName"]}");
                Console.WriteLine($"Last Name: {reader["LastName"]}");
                Console.WriteLine($"Position: {reader["Position"]}");
                Console.WriteLine($"E-mail Address: {reader["EmailAdd"]}");
                Console.WriteLine($"Mobile Number: {reader["MobileNum"]}");
                Console.WriteLine($"Telehone Number: {reader["PhoneNum"]}");
                Console.WriteLine($"Website Link: {reader["WebsiteLink"]}");
                Console.WriteLine($"Lead Source: {reader["LeadSource"]}");
                Console.WriteLine($"Lead Status: {reader["LeadStatus"]}");
                Console.WriteLine($"Industry: {reader["Industry"]}");
                Console.WriteLine($"Employees: {reader["Employees"]}");
                Console.WriteLine($"AnnualRevenue: {reader["AnnualRevenue"]}");
                Console.WriteLine($"Rating: {reader["Rating"]}");
                Console.WriteLine($"Skype Id: {reader["SkypeID"]}\n");
                
            }
            var showLead = reader.Read().ToString();
            sqlConnection.Close();
            return showLead;
        }

        static public string InsertContact(string leadsource, string firstname, string lastname, string position, string emailadd, string department, long mobilenum,
            long phonenum, string birthdate, string assistant, long assistantphone, string skypeid)
           
        {
            var selectStatement = "INSERT INTO dbo.Contacts (LeadSource, FirstName, LastName, Position, EmailAdd, Department, MobileNum," +
                   "PhoneNum, BirthDate, Assistant, AssistantPhone, SkypeID) VALUES (@LeadSource, @FirstName, @LastName, @Position, @Department," +
                   "@EmailAdd, @MobileNum, @PhoneNum , @BirthDate, @Assistant, @AssistantPhone, @SkypeID)";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@LeadSource", leadsource);
            selectCommand.Parameters.AddWithValue("@FirstName", firstname);
            selectCommand.Parameters.AddWithValue("@LastName", lastname);
            selectCommand.Parameters.AddWithValue("@Position", position);
            selectCommand.Parameters.AddWithValue("@EmailAdd", emailadd);
            selectCommand.Parameters.AddWithValue("@Department", department);
            selectCommand.Parameters.AddWithValue("@Mobilenum", mobilenum);
            selectCommand.Parameters.AddWithValue("@PhoneNum", phonenum);
            selectCommand.Parameters.AddWithValue("@BirthDate", birthdate);
            selectCommand.Parameters.AddWithValue("@Assistant", assistant);
            selectCommand.Parameters.AddWithValue("@AssistantPhone", assistantphone);
            selectCommand.Parameters.AddWithValue("@SkypeID", skypeid);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            var newContact = reader.Read().ToString();
            sqlConnection.Close();
            return newContact;

        }

        static public string ShowContact()
        {
            var selectStatement = "SELECT LeadSource, FirstName, LastName, Position, EmailAdd, Department, MobileNum," +
                   "PhoneNum, BirthDate, Assistant, AssistantPhone, SkypeID FROM dbo.Contacts";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("———————————————— Contact ————————————————\n");
                Console.WriteLine($"Lead Source: {reader["LeadSource"]}");
                Console.WriteLine($"First Name: {reader["FirstName"]}");
                Console.WriteLine($"Last Name: {reader["LastName"]}");
                Console.WriteLine($"Position: {reader["Position"]}");
                Console.WriteLine($"E-mail Address: {reader["EmailAdd"]}");
                Console.WriteLine($"Department: {reader["Department"]}");
                Console.WriteLine($"Mobile Number: {reader["MobileNum"]}");
                Console.WriteLine($"Telehone Number: {reader["PhoneNum"]}");
                Console.WriteLine($"BirthDate: {reader["BirthDate"]}");
                Console.WriteLine($"Assistant: {reader["Assistant"]}");
                Console.WriteLine($"Assistant: {reader["AssistantPhone"]}");
                Console.WriteLine($"Skype Id: {reader["SkypeID"]}\n");

            }
            var showContact = reader.Read().ToString();
            sqlConnection.Close();
            return showContact;
        }
    }
}
