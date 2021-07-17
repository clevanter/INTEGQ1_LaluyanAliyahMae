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

        static public string ViewAllLeadCompanyNames()
        {
            var selectStatement = "SELECT CompanyName, FirstName FROM dbo.Lead";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("———————————————— Lead ————————————————\n");
                Console.ResetColor();
                Console.WriteLine($"Company Name: {reader["CompanyName"]}");
                Console.WriteLine($"First Name: {reader["FirstName"]}");
            }
            var showLead = reader.Read().ToString();
            sqlConnection.Close();
            return showLead;
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

        static public string ShowLead(string companyname)
        {
            var selectStatement = "SELECT CompanyName, FirstName, LastName, Position, EmailAdd, MobileNum," +
                   "PhoneNum, WebsiteLink, LeadSource, LeadStatus, Industry, Employees, AnnualRevenue, Rating, SkypeID FROM dbo.Lead " +
                   "WHERE CompanyName = @CompanyName";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@CompanyName", companyname);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n———————————————— Lead ————————————————\n");
                Console.ResetColor();
                Console.WriteLine($"Company Name: {reader["CompanyName"]}");
                Console.WriteLine($"First Name: {reader["FirstName"]}");
                Console.WriteLine($"Last Name: {reader["LastName"]}");
                Console.WriteLine($"Position: {reader["Position"]}");
                Console.WriteLine($"E-mail Address: {reader["EmailAdd"]}");
                Console.WriteLine($"Mobile Number: {reader["MobileNum"]}");
                Console.WriteLine($"Telephone Number: {reader["PhoneNum"]}");
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

        static public string InsertLead(string companyname, string firstname, string lastname, string position, string emailadd, long mobilenum,
            long phonenum, string websitelink, string leadsource, string leadstatus, string industry, int employees, decimal annualrevenue,
            int rating, string skypeid)
        {
            var insertStatement = "INSERT INTO dbo.Lead (CompanyName, FirstName, LastName, Position, EmailAdd, MobileNum," +
                   "PhoneNum, WebsiteLink, LeadSource, LeadStatus, Industry, Employees, AnnualRevenue, Rating, SkypeID) VALUES (@CompanyName, " +
                "@FirstName, @LastName, @Position, @EmailAdd, @MobileNum, @PhoneNum , @WebsiteLink, @LeadSource, @LeadStatus, @Industry, @Employees, @AnnualRevenue," +
                "@Rating, @SkypeID)";

            SqlCommand selectCommand = new SqlCommand(insertStatement, sqlConnection);
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

        static public string ConvertLead(string companyname)
        {
            var insertStatement = "INSERT INTO dbo.Contact (AccountName, LeadSource, FirstName, LastName, Position, EmailAdd, MobileNumber, PhoneNumber," +
                "SkypeID) SELECT CompanyName, LeadSource, FirstName, LastName, Position, EmailAdd, MobileNum, PhoneNum," +
                "SkypeID FROM dbo.Lead WHERE CompanyName = @CompanyName";
            SqlCommand selectCommand = new SqlCommand(insertStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@CompanyName", companyname);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            var leadConverted = reader.Read().ToString();
            sqlConnection.Close();
            return leadConverted;

        }

        static public string InsertRemainingContactInfo(string accountname, string department, string birthdate, string assistant, long assistantphone)
        {
            var updateStatement = "UPDATE dbo.Contact SET Department = @Department, BirthDate = @BirthDate, AssistantName = @AssistantName, " +
                 "AssistantPhone = @AssistantPhone WHERE AccountName = @AccountName";

            SqlCommand selectCommand = new SqlCommand(updateStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@AccountName", accountname);
            selectCommand.Parameters.AddWithValue("@Department", department);
            selectCommand.Parameters.AddWithValue("@BirthDate", birthdate);
            selectCommand.Parameters.AddWithValue("@AssistantName", assistant);
            selectCommand.Parameters.AddWithValue("@AssistantPhone", assistantphone);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            var contactInfo = reader.Read().ToString();
            sqlConnection.Close();
            return contactInfo;

        }

        static public string InsertContact(string accountname, string leadsource, string firstname, string lastname, string position, string emailadd, string department, long mobilenum,
            long phonenum, string birthdate, string assistant, long assistantphone, string skypeid)
        {
            var insertStatement = "INSERT INTO dbo.Contact (AccountName, LeadSource, FirstName, LastName, Position, EmailAdd, Department, MobileNumber," +
                   "PhoneNumber, BirthDate, AssistantName, AssistantPhone, SkypeID) VALUES (@AccountName, @LeadSource, @FirstName, @LastName, @Position, @Department," +
                   "@EmailAdd, @MobileNumber, @PhoneNumber , @BirthDate, @Assistantname, @AssistantPhone, @SkypeID)";

            SqlCommand selectCommand = new SqlCommand(insertStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@AccountName", accountname);
            selectCommand.Parameters.AddWithValue("@LeadSource", leadsource);
            selectCommand.Parameters.AddWithValue("@FirstName", firstname);
            selectCommand.Parameters.AddWithValue("@LastName", lastname);
            selectCommand.Parameters.AddWithValue("@Position", position);
            selectCommand.Parameters.AddWithValue("@EmailAdd", emailadd);
            selectCommand.Parameters.AddWithValue("@Department", department);
            selectCommand.Parameters.AddWithValue("@MobileNumber", mobilenum);
            selectCommand.Parameters.AddWithValue("@PhoneNumber", phonenum);
            selectCommand.Parameters.AddWithValue("@BirthDate", birthdate);
            selectCommand.Parameters.AddWithValue("@AssistantName", assistant);
            selectCommand.Parameters.AddWithValue("@AssistantPhone", assistantphone);
            selectCommand.Parameters.AddWithValue("@SkypeID", skypeid);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            var newContact = reader.Read().ToString();
            sqlConnection.Close();
            return newContact;

        }

        static public string UpdateLead(string companyname, string firstname, string lastname, string position, string emailadd, long mobilenum,
            long phonenum, string websitelink, string leadsource, string leadstatus, string industry, int employees, decimal annualrevenue,
            int rating, string skypeid)
        {
            var updateStatement = "UPDATE dbo.Lead SET CompanyName = @CompanyName, FirstName = @FirstName, LastName = @LastName, Position = @Position, " +
                    "EmailAdd = @EmailAdd, MobileNum = @MobileNum, PhoneNum = @PhoneNum, WebsiteLink = @WebsiteLink, " +
                    "LeadSource = @LeadSource, LeadStatus = @LeadStatus, Industry = @Industry, Employees = @Employees," +
                    "AnnualRevenue = @AnnualRevenue, Rating = @Rating, SkypeID = @SkypeID WHERE CompanyName = @CompanyName";
            SqlCommand selectCommand = new SqlCommand(updateStatement, sqlConnection);
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
            var updateLead = reader.Read().ToString();
            sqlConnection.Close();
            return updateLead;
        }

        static public string RemoveInLead(string firstname)
        {
            var deleteStatement = "DELETE FROM dbo.Lead WHERE FirstName = @FirstName";
            SqlCommand selectCommand = new SqlCommand(deleteStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@FirstName", firstname);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            var deleteLead = reader.Read().ToString();
            sqlConnection.Close();

            return deleteLead;
        }

        static public string ShowContact(string accountname)
        {
            var selectStatement = "SELECT AccountName, LeadSource, FirstName, LastName, Position, EmailAdd, Department, MobileNumber," +
                   "PhoneNumber, BirthDate, AssistantName, AssistantPhone, SkypeID FROM dbo.Contact WHERE AccountName = @AccountName";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@AccountName", accountname);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n———————————————— Contact ————————————————\n");
                Console.ResetColor();
                Console.WriteLine($"Account Name: {reader["AccountName"]}");
                Console.WriteLine($"Lead Source: {reader["LeadSource"]}");
                Console.WriteLine($"First Name: {reader["FirstName"]}");
                Console.WriteLine($"Last Name: {reader["LastName"]}");
                Console.WriteLine($"Position: {reader["Position"]}");
                Console.WriteLine($"E-mail Address: {reader["EmailAdd"]}");
                Console.WriteLine($"Department: {reader["Department"]}");
                Console.WriteLine($"Mobile Number: {reader["MobileNumber"]}");
                Console.WriteLine($"Telephone Number: {reader["PhoneNumber"]}");
                Console.WriteLine($"BirthDate: {reader["BirthDate"]}");
                Console.WriteLine($"Assistant: {reader["AssistantName"]}");
                Console.WriteLine($"Assistant: {reader["AssistantPhone"]}");
                Console.WriteLine($"Skype Id: {reader["SkypeID"]}\n");

            }
            var showContact = reader.Read().ToString();
            sqlConnection.Close();
            return showContact;
        }

        static public string ViewContactContactPerson()
        {
            var selectStatement = "SELECT AccountName, FirstName, LastName FROM dbo.Contact";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("———————————————— Company Contact Person ————————————————\n");
                Console.ResetColor();
                Console.WriteLine($"Account Name: {reader["AccountName"]}");
                Console.WriteLine($"Full Name: {reader["FirstName"]} {reader["LastName"]}");

            }
            var showContact = reader.Read().ToString();
            sqlConnection.Close();
            return showContact;
        }

        static public string ContactFirstNameValidation(string accountname)
        {
            var selectStatement = "SELECT AccountName FROM dbo.Contact WHERE AccountName = @AccountName";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@AccountName", accountname);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            var acctNameValidated = reader.Read().ToString();
            sqlConnection.Close();
            return acctNameValidated;
        }

        static public string UpdateContact(string accountname, string leadsource, string firstname, string lastname, string position, string emailadd, string department, long mobilenum,
            long phonenum, string birthdate, string assistant, long assistantphone, string skypeid)

        {
            var updateStatement = "UPDATE dbo.Contact SET AccountName = @AccountName, LeadSource = @LeadSource, FirstName = @FirstName, LastName = @LastName, Position = @Position, " +
                "Department = @Department, EmailAdd = @EmailAdd, MobileNumber = @MobileNumber, PhoneNumber = @PhoneNumber, BirthDate = @Birthdate, AssistantName = @AssistantName, " +
                "AssistantPhone = @AssistantPhone, SkypeID = @SkypeID WHERE AccountName = @AccountName";

            SqlCommand selectCommand = new SqlCommand(updateStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@AccountName", accountname);
            selectCommand.Parameters.AddWithValue("@LeadSource", leadsource);
            selectCommand.Parameters.AddWithValue("@FirstName", firstname);
            selectCommand.Parameters.AddWithValue("@LastName", lastname);
            selectCommand.Parameters.AddWithValue("@Position", position);
            selectCommand.Parameters.AddWithValue("@EmailAdd", emailadd);
            selectCommand.Parameters.AddWithValue("@Department", department);
            selectCommand.Parameters.AddWithValue("@MobileNumber", mobilenum);
            selectCommand.Parameters.AddWithValue("@PhoneNumber", phonenum);
            selectCommand.Parameters.AddWithValue("@BirthDate", birthdate);
            selectCommand.Parameters.AddWithValue("@AssistantName", assistant);
            selectCommand.Parameters.AddWithValue("@AssistantPhone", assistantphone);
            selectCommand.Parameters.AddWithValue("@SkypeID", skypeid);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            var updateContact = reader.Read().ToString();
            sqlConnection.Close();
            return updateContact;
        }

        static public string InsertDeal(string dealname, DateTime closingdate, string accountname, int probability, decimal expectedrevenue, string leadsource, string contactname,
            string dealdescription, string status)

        {
            var insertStatement = "INSERT INTO dbo.Deals (DealName, ClosingDate, AccountName, Probability, ExpectedRevenue, LeadSource, ContactName," +
                   "DealDescription, Status) VALUES (@DealName, @ClosingDate, @AccountName, @Probability, @ExpectedRevenue, @LeadSource, @ContactName," +
                   "@DealDescription, @Status)";

            SqlCommand selectCommand = new SqlCommand(insertStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@DealName", dealname);
            selectCommand.Parameters.AddWithValue("@ClosingDate", closingdate);
            selectCommand.Parameters.AddWithValue("@AccountName", accountname);
            selectCommand.Parameters.AddWithValue("@Probability", probability);
            selectCommand.Parameters.AddWithValue("@ExpectedRevenue", expectedrevenue);
            selectCommand.Parameters.AddWithValue("@LeadSource", leadsource);
            selectCommand.Parameters.AddWithValue("@Contactname", contactname);
            selectCommand.Parameters.AddWithValue("@DealDescription", dealdescription);
            selectCommand.Parameters.AddWithValue("@Status", status);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            var insertDeal = reader.Read().ToString();
            sqlConnection.Close();
            return insertDeal;
        }

        static public string ViewDealName()
        {
            var selectStatement = "SELECT DealName FROM dbo.Deals";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n———————————————— Deal Name ————————————————\n");
                Console.ResetColor();
                Console.WriteLine($"Deal Name: {reader["DealName"]}");
            }
            var showDeal = reader.Read().ToString();
            sqlConnection.Close();
            return showDeal;
        }

        static public string DealNameValidation(string dealname)
        {
            var selectStatement = "SELECT DealName FROM dbo.Deals WHERE DealName = @DealName";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@DealName", dealname);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            var dealNameValidated = reader.Read().ToString();
            sqlConnection.Close();
            return dealNameValidated;
        }

        static public string ShowDeal(string dealname)
        {
            var selectStatement = "SELECT DealName, ClosingDate, AccountName, Probability, ExpectedRevenue, LeadSource, ContactName," +
                   "DealDescription, Status FROM dbo.Deals WHERE DealName = @DealName";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@DealName", dealname);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n———————————————— Deal ————————————————\n");
                Console.ResetColor();
                Console.WriteLine($"Deal Name: {reader["DealName"]}");
                Console.WriteLine($"Closing Date: {reader["ClosingDate"]}");
                Console.WriteLine($"Account Name: {reader["AccountName"]}");
                Console.WriteLine($"Probability: {reader["Probability"]}%");
                Console.WriteLine($"Expected Revenue: P{reader["ExpectedRevenue"]}".ToString());
                Console.WriteLine($"Lead Source: {reader["LeadSource"]}");
                Console.WriteLine($"Contact Name: {reader["ContactName"]}");
                Console.WriteLine($"Deal Description: {reader["DealDescription"]}");
                Console.WriteLine($"Status: {reader["Status"]}\n");
            }
            var showDeal = reader.Read().ToString();
            sqlConnection.Close();
            return showDeal;

        }

        static public string UpdateDeal(string dealname, DateTime closingdate, string accountname, int probability, decimal expectedrevenue, string leadsource, string contactname,
            string dealdescription, string status)

        {
            var updateStatement = "UPDATE dbo.Deals SET DealName = @DealName, ClosingDate = @ClosingDate, AccountName = @AccountName, Probability = @Probability, ExpectedRevenue = @ExpectedRevenue, LeadSource = @LeadSource, ContactName = @ContactName," +
                   "DealDescription = @DealDescription, Status = @Status WHERE DealName = @DealName";

            SqlCommand selectCommand = new SqlCommand(updateStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@DealName", dealname);
            selectCommand.Parameters.AddWithValue("@ClosingDate", closingdate);
            selectCommand.Parameters.AddWithValue("@AccountName", accountname);
            selectCommand.Parameters.AddWithValue("@Probability", probability);
            selectCommand.Parameters.AddWithValue("@ExpectedRevenue", expectedrevenue);
            selectCommand.Parameters.AddWithValue("@LeadSource", leadsource);
            selectCommand.Parameters.AddWithValue("@Contactname", contactname);
            selectCommand.Parameters.AddWithValue("@DealDescription", dealdescription);
            selectCommand.Parameters.AddWithValue("@Status", status);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            var updateDeal = reader.Read().ToString();
            sqlConnection.Close();
            return updateDeal;
        }

        static public string SureRevenue(string status)
        {
            var selectStatement = "SELECT SUM (ExpectedRevenue) as RevenueSum FROM dbo.Deals WHERE Status = @Status";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@Status", status);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            
            while (reader.Read())
            {
                Console.Write($"\nExpected Revenue: ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"{reader["RevenueSum"]}");
                Console.ResetColor();
            }
            var showSum = reader.Read().ToString();
            sqlConnection.Close();
            return showSum;
        }

        static public string ViewAccountNames()
        {
            var selectStatement = "SELECT AccountName FROM dbo.Accounts";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n———————————————— Account Names ————————————————\n");
                Console.ResetColor();
                Console.WriteLine($"Account Name: {reader["AccountName"]}");
            }
            var showAccount = reader.Read().ToString();
            sqlConnection.Close();
            return showAccount;
        }

        static public string AccountNameValidation(string accountname)
        {
            var selectStatement = "SELECT AccountName FROM dbo.Accounts WHERE AccountName = @AccountName";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@AccountName", accountname);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            var acctNameValidated = reader.Read().ToString();
            sqlConnection.Close();
            return acctNameValidated;
        }

        static public string ShowAccount(string accountname)
        {
            var selectStatement = "SELECT AccountName, AccountNum, Industry, Rating, PhoneNumber, WebsiteLink, Employees, AnnualRevenue FROM dbo.Accounts " +
                "WHERE AccountName = @AccountName";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@AccountName", accountname);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n———————————————— Account ————————————————\n");
                Console.ResetColor();
                Console.WriteLine($"Account Name: {reader["AccountName"]}");
                Console.WriteLine($"Account Number: {reader["AccountNum"]}");
                Console.WriteLine($"Industry: {reader["Industry"]}");
                Console.WriteLine($"Rating: {reader["Rating"]}");
                Console.WriteLine($"Phone Number: {reader["PhoneNumber"]}");
                Console.WriteLine($"Website Link: {reader["WebsiteLink"]}");
                Console.WriteLine($"Employees: {reader["Employees"]}"); 
                Console.WriteLine($"Annual Revenue: {reader["AnnualRevenue"]}\n");
            }
            var showAccount = reader.Read().ToString();
            sqlConnection.Close();
            return showAccount;
        }

        static public string InsertAccount(string accountname, long accountnum, string industry, int rating, long phonenum, string websitelink, int employees, decimal annualrevenue)
        {
            var insertStatement = "INSERT INTO dbo.Accounts (AccountName, AccountNum, Industry, Rating, PhoneNumber, WebsiteLink, Employees, AnnualRevenue)" +
                "VALUES (@AccountName, @AccountNum, @Industry, @Rating, @PhoneNumber, @WebsiteLink, @Employees, @AnnualRevenue)";

            SqlCommand selectCommand = new SqlCommand(insertStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@AccountName", accountname);
            selectCommand.Parameters.AddWithValue("@AccountNum", accountnum);
            selectCommand.Parameters.AddWithValue("@Industry", industry);
            selectCommand.Parameters.AddWithValue("@Rating", rating);
            selectCommand.Parameters.AddWithValue("@PhoneNumber", phonenum);
            selectCommand.Parameters.AddWithValue("@WebsiteLink", websitelink);
            selectCommand.Parameters.AddWithValue("@Employees", employees);
            selectCommand.Parameters.AddWithValue("@AnnualRevenue", annualrevenue);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            var insertAccount = reader.Read().ToString();
            sqlConnection.Close();
            return insertAccount;
        }

        static public string ImportAccount(string accountname)
        {
            var insertStatement = "INSERT INTO dbo.Accounts (AccountName, Industry, Rating, PhoneNumber, WebsiteLink, Employees, AnnualRevenue) " +
                "SELECT CompanyName, Industry, Rating, PhoneNum, WebsiteLink, Employees, AnnualRevenue FROM dbo.Lead WHERE CompanyName = @AccountName";
            SqlCommand selectCommand = new SqlCommand(insertStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@AccountName", accountname);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            var leadImported = reader.Read().ToString();
            sqlConnection.Close();
            return leadImported;

        }

        static public string InsertRemainingAccountInfo(string accountname, long accountnum)
        {
            var updateStatement = "UPDATE dbo.Accounts SET AccountNum = @AccountNum WHERE AccountName = @AccountName";
            SqlCommand selectCommand = new SqlCommand(updateStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@AccountName", accountname);
            selectCommand.Parameters.AddWithValue("@AccountNum", accountnum);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            var accountNum = reader.Read().ToString();
            sqlConnection.Close();
            return accountNum;

        }

        static public string UpdateAccount(string accountname, long accountnum, string industry, int rating, long phonenum, string websitelink, 
            int employees, decimal annualrevenue)
        {
            var updateStatement = "UPDATE dbo.Accounts SET AccountName = @AccountName, AccountNum = @AccountNum, Industry = @Industry, Rating = @Rating, " +
                "PhoneNumber = @PhoneNumber, WebsiteLink = @WebsiteLink, Employees = @Employees, AnnualRevenue = @AnnualRevenue WHERE AccountName = @AccountName";
            SqlCommand selectCommand = new SqlCommand(updateStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@AccountName", accountname);
            selectCommand.Parameters.AddWithValue("@AccountNum", accountnum);
            selectCommand.Parameters.AddWithValue("@Industry", industry);
            selectCommand.Parameters.AddWithValue("@Rating", rating);
            selectCommand.Parameters.AddWithValue("@PhoneNumber", phonenum);
            selectCommand.Parameters.AddWithValue("@WebsiteLink", websitelink);
            selectCommand.Parameters.AddWithValue("@Employees", employees);
            selectCommand.Parameters.AddWithValue("@AnnualRevenue", annualrevenue);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            var updateAccount = reader.Read().ToString();
            sqlConnection.Close();
            return updateAccount;

        }

        static public string ShowAllInteraction()
        {
            var selectStatement = "SELECT InteractionNum, Contactname, Type, UsedNumber, UsedEmail, DateAndDuration FROM dbo.Interactions";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n———————————————— Interactions ————————————————\n");
                Console.ResetColor();
                Console.WriteLine($"Interaction Number: {reader["InteractionNum"]}");
                Console.WriteLine($"Name of Contact: {reader["Contactname"]}");
                Console.WriteLine($"Type of Interaction: {reader["Type"]}");
                Console.WriteLine($"Used Number: {reader["UsedNumber"]}");
                Console.WriteLine($"Used Email: {reader["UsedEmail"]}");
                Console.WriteLine($"Date and Duration: {reader["DateAndDuration"]}\n");
            }
            var showInteraction = reader.Read().ToString();
            sqlConnection.Close();
            return showInteraction;
        }

        static public string InsertInteraction(string contactname, string type, long usednumber, string usedemail,DateTime durationanddate)
        {
            var insertStatement = "INSERT into dbo.Interactions (Contactname, Type, UsedNumber, UsedEmail, DateAndDuration) VALUES (@Contactname, " +
                "@Type, @UsedNumber, @UsedEmail, @DateAndDuration)";

            SqlCommand selectCommand = new SqlCommand(insertStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@Contactname", contactname);
            selectCommand.Parameters.AddWithValue("@Type", type);
            selectCommand.Parameters.AddWithValue("@UsedNumber", usednumber);
            selectCommand.Parameters.AddWithValue("@UsedEmail", usedemail);
            selectCommand.Parameters.AddWithValue("@DateAndDuration", durationanddate);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            var insertInteractions = reader.Read().ToString();
            sqlConnection.Close();
            return insertInteractions;

        }

        static public string UpdateID(int number, string contactname)
        {
            var inserStatement = "UPDATE dbo.Interactions SET InteractionNum = @InteractionNum WHERE Contactname = @Contactname";
            SqlCommand selectCommand = new SqlCommand(inserStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@InteractionNum", number);
            selectCommand.Parameters.AddWithValue("@Contactname", contactname);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            var updateNumber = reader.Read().ToString();
            sqlConnection.Close();
            return updateNumber;
        }

        static public string ViewInteraction()
        {
            var selectStatement = "SELECT InteractionNum, Contactname, DateAndDuration FROM dbo.Interactions";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                
                Console.Write($"\n———————————————————");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($" Interaction");               
                Console.Write($" #{reader["InteractionNum"]}");
                Console.ResetColor();
                Console.WriteLine($" ———————————————————");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write($"Contact Name: ");
                Console.ResetColor();
                Console.WriteLine($"{reader["Contactname"]}");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write($"Latest Interaction: ");
                Console.ResetColor();
                Console.WriteLine($"{reader["DateAndDuration"]}\n");
            }
            var showInteraction = reader.Read().ToString();
            sqlConnection.Close();
            return showInteraction;
        }

        static public string InteractionIDValidation(long interactionid)
        {
            var selectStatement = "SELECT InteractionNum FROM dbo.Interactions WHERE InteractionNum = @InteractionNum";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@InteractionNum", interactionid);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            var interactionIDValidated = reader.Read().ToString();
            sqlConnection.Close();
            return interactionIDValidated;
        }

        static public string UpdateInteraction(long interactionid, string contactname, string type, long usednumber, string usedemail, DateTime durationanddate)
        {
            var updateStatement = "UPDATE dbo.Interactions SET Contactname = @Contactname, Type = @Type, UsedNumber = @UsedNumber, UsedEmail = @UsedEmail, " +
                "DateAndDuration = @DateAndDuration WHERE InteractionNum = @InteractionNum";
            SqlCommand selectCommand = new SqlCommand(updateStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@InteractionNum", interactionid);
            selectCommand.Parameters.AddWithValue("@Contactname", contactname);
            selectCommand.Parameters.AddWithValue("@Type", type);
            selectCommand.Parameters.AddWithValue("@UsedNumber", usednumber);
            selectCommand.Parameters.AddWithValue("@UsedEmail", usedemail);
            selectCommand.Parameters.AddWithValue("@DateAndDuration", durationanddate);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            var udInteraction = reader.Read().ToString();
            sqlConnection.Close();
            return udInteraction;
        }

        static public string ViewSpecificInteraction(long interactionid)
        {
            var selectStatement = "SELECT InteractionNum, Type, Contactname, UsedNumber, UsedEmail, DateAndDuration FROM dbo.Interactions WHERE InteractionNum = InteractionNum";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@InteractionNum", interactionid);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                Console.Write($"\n————————————————————————");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($" Interaction");
                Console.Write($" #{reader["InteractionNum"]}");
                Console.ResetColor();
                Console.WriteLine($" ———————————————————————");
                Console.WriteLine($"Contact Name: {reader["Contactname"]}");
                Console.WriteLine($"Type: {reader["Type"]}");
                Console.WriteLine($"Used Number: {reader["UsedNumber"]}");
                Console.WriteLine($"Used Email: {reader["UsedEmail"]}");
                Console.WriteLine($"Date and Duration of Interaction: {reader["DateAndDuration"]}\n");
            }
            var showInteraction = reader.Read().ToString();
            sqlConnection.Close();
            return showInteraction;
        }

        static public string RemoveFromInteraction(long interactionid)
        {
            var deleteStatement = "DELETE FROM dbo.Interactions WHERE InteractionNum = @InteractionNum";
            SqlCommand selectCommand = new SqlCommand(deleteStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@InteractionNum", interactionid);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            var deleteInteraction = reader.Read().ToString();
            sqlConnection.Close();
            return deleteInteraction;
        }

        static public string ShowAllTask()
        {
            var selectStatement = "SELECT TaskId, TaskType, DatePosted, DueDate, TaskTitle, TaskDescription, TaskAssigned, Progress FROM dbo.Tasks";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n———————————————— Task ————————————————\n");
                Console.ResetColor();
                Console.WriteLine($"Task ID: {reader["TaskID"]}");
                Console.WriteLine($"Task Type: {reader["TaskType"]}");
                Console.WriteLine($"Date Posted: {reader["DatePosted"]}");
                Console.WriteLine($"Task Title: {reader["TaskTitle"]}");
                Console.WriteLine($"Task Description: {reader["TaskDescription"]}");
                Console.WriteLine($"Task Assigned: {reader["TaskAssigned"]}");
                Console.WriteLine($"Due Date: {reader["DueDate"]}");
                Console.WriteLine($"Progress: {reader["Progress"]}\n");
            }
            var showTask = reader.Read().ToString();
            sqlConnection.Close();
            return showTask;
        }

        static public string InsertTask(string tasktype, DateTime dateposted, DateTime duedate, string tasktitle, string taskdescription, string taskassigned, string progress)
        {
            var insertStatement = "INSERT INTO dbo.Tasks (TaskType, DatePosted, DueDate, TaskTitle, TaskDescription, TaskAssigned, Progress) " +
                "Values (@TaskType, @DatePosted, @DueDate, @TaskTitle, @TaskDescription, @TaskAssigned, @Progress)";
            SqlCommand selectCommand = new SqlCommand(insertStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@TaskType", tasktype);
            selectCommand.Parameters.AddWithValue("@DatePosted", dateposted);
            selectCommand.Parameters.AddWithValue("@DueDate", duedate);
            selectCommand.Parameters.AddWithValue("@TaskTitle", tasktitle);
            selectCommand.Parameters.AddWithValue("@TaskDescription", taskdescription);
            selectCommand.Parameters.AddWithValue("@TaskAssigned", taskassigned);
            selectCommand.Parameters.AddWithValue("@Progress", progress);

            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            var insertTasks = reader.Read().ToString();
            sqlConnection.Close();
            return insertTasks;
        }

        static public string UpdateTaskId(int taskid, string tasktitle)
        {
            var updateStatement = "UPDATE dbo.Tasks SET TaskID = @TaskID WHERE TaskTitle = @TaskTitle";
            SqlCommand selectCommand = new SqlCommand(updateStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@TaskID", taskid);
            selectCommand.Parameters.AddWithValue("@TaskTitle", tasktitle);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            var updateNumber = reader.Read().ToString();
            sqlConnection.Close();
            return updateNumber;
        }

        static public string ViewTask()
        {
            var selectStatement = "SELECT TaskID, TaskTitle, TaskDescription, TaskAssigned, DueDate FROM dbo.Tasks";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                Console.Write($"\n—————————————————————— ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"Task #{reader["TaskID"]} ");
                Console.ResetColor();
                Console.WriteLine($"———————————————————————");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"{reader["TaskTitle"]}".ToUpper());
                Console.ResetColor();
                Console.WriteLine($"{reader["TaskDescription"]}");
                Console.Write($"Assigned for: ");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"{reader["TaskAssigned"]}");
                Console.ResetColor();
                Console.Write($"Due Date: ");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"{reader["DueDate"]}");
                Console.ResetColor();
            }
            var showTask = reader.Read().ToString();
            sqlConnection.Close();
            return showTask;
        }

        static public string TaskIDValidation(long taskid)
        {
            var selectStatement = "SELECT TaskID FROM dbo.Tasks WHERE TaskID = @TaskID";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@TaskID", taskid);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            var taskIDValidated = reader.Read().ToString();
            sqlConnection.Close();
            return taskIDValidated;
        }

        static public string UpdateTask(long taskid, string tasktype, DateTime dateposted, DateTime duedate, string tasktitle, string taskdescription, string taskassigned, string progress)
        {
            var updateStatement = "UPDATE dbo.Tasks SET TaskType = @TaskType, DatePosted = @DatePosted, DueDate = @DueDate, TaskTitle = @TaskTitle, " +
                "TaskDescription = @TaskDescription, TaskAssigned = @TaskAssigned, Progress = @Progress WHERE TaskID = @TaskID ";
            SqlCommand selectCommand = new SqlCommand(updateStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@TaskID", taskid);
            selectCommand.Parameters.AddWithValue("@TaskType", tasktype);
            selectCommand.Parameters.AddWithValue("@DatePosted", dateposted);
            selectCommand.Parameters.AddWithValue("@DueDate", duedate);
            selectCommand.Parameters.AddWithValue("@TaskTitle", tasktitle);
            selectCommand.Parameters.AddWithValue("@TaskDescription", taskdescription);
            selectCommand.Parameters.AddWithValue("@TaskAssigned", taskassigned);
            selectCommand.Parameters.AddWithValue("@Progress", progress);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            var udTask = reader.Read().ToString();
            sqlConnection.Close();
            return udTask;
        }

        static public string RemoveCompletedTask(long taskid)
        {
            var deleteStatement = "DELETE FROM dbo.Tasks WHERE TaskID = @TaskID";
            SqlCommand selectCommand = new SqlCommand(deleteStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@TaskID", taskid);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            var deleteCompleted = reader.Read().ToString();
            sqlConnection.Close();
            return deleteCompleted;
        }

        static public string ViewSpecificTask(long taskid)
        {
            var selectStatement = "SELECT TaskId, TaskType, DatePosted, DueDate, TaskTitle, TaskDescription, TaskAssigned, Progress FROM dbo.Tasks";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@TaskID", taskid);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                Console.Write($"\n—————————————————————— ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"Task #{reader["TaskID"]} ");
                Console.ResetColor();
                Console.WriteLine($"———————————————————————");               
                Console.WriteLine($"Task Type: {reader["TaskType"]}");
                Console.WriteLine($"Date Posted: {reader["DatePosted"]}");
                Console.WriteLine($"Task Title: {reader["TaskTitle"]}");
                Console.WriteLine($"Task Description: {reader["TaskDescription"]}");
                Console.WriteLine($"Task Assigned: {reader["TaskAssigned"]}");
                Console.WriteLine($"Due Date: {reader["DueDate"]}");
                Console.WriteLine($"Progress: {reader["Progress"]}\n");
            }
            var showTask = reader.Read().ToString();
            sqlConnection.Close();
            return showTask;
        }

        static public string ShowAllReports()
        {
            var selectStatement = "SELECT * FROM dbo.Reports";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n———————————————— Reports ————————————————\n");
                Console.ResetColor();
                Console.WriteLine($"Report ID: {reader["ReportID"]}");
                Console.WriteLine($"Report Name: {reader["ReportName"]}");
                Console.WriteLine($"Report Description: {reader["ReportDescription"]}");
                Console.WriteLine($"Date Posted: {reader["DatePosted"]}");
                Console.WriteLine($"Report By: {reader["ReportBy"]}\n");
            }
            var showReports = reader.Read().ToString();
            sqlConnection.Close();
            return showReports;
        }

        static public string InsertReport(string reportname, string reportdescription, DateTime dateposted, string reportby)
        {
            var insertStatement = "INSERT INTO dbo.Reports (ReportName, ReportDescription, DatePosted, ReportBy) VALUES (@ReportName, @ReportDescription, " +
                "@DatePosted, @ReportBy)";
            SqlCommand selectCommand = new SqlCommand(insertStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@ReportName", reportname);
            selectCommand.Parameters.AddWithValue("@ReportDescription", reportdescription);
            selectCommand.Parameters.AddWithValue("@DatePosted", dateposted);
            selectCommand.Parameters.AddWithValue("@ReportBy", reportby);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            var insertReports = reader.Read().ToString();
            sqlConnection.Close();
            return insertReports;
        }

        static public string UpdateReportId(int reportid, string reportname)
        {
            var inserStatement = "UPDATE dbo.Reports SET ReportID = @ReportID WHERE ReportName = @ReportName";
            SqlCommand selectCommand = new SqlCommand(inserStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@ReportID", reportid);
            selectCommand.Parameters.AddWithValue("@ReportName", reportname);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            var updateNumber = reader.Read().ToString();
            sqlConnection.Close();
            return updateNumber;
        }

        static public string ViewReport()
        {
            var selectStatement = "SELECT ReportID, ReportName, ReportDescription FROM dbo.Reports";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                Console.Write($"\n————————————————————— ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"Report #{reader["ReportID"]} ");
                Console.ResetColor();
                Console.WriteLine($"——————————————————————");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"{reader["ReportName"]}".ToUpper());
                Console.ResetColor();
                Console.WriteLine($"{reader["ReportDescription"]}");
            }
            var showReport = reader.Read().ToString();
            sqlConnection.Close();
            return showReport;
        }

        static public string ReportIDValidation(long reportid)
        {
            var selectStatement = "SELECT ReportID FROM dbo.Reports WHERE ReportID = @ReportID";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@ReportID", reportid);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            var reportIDValidated = reader.Read().ToString();
            sqlConnection.Close();
            return reportIDValidated;
        }

        static public string UpdateReport (long reportid, string reportname, string reportdescription, DateTime dateposted, string reportby)
        {
            var updateStatement = "UPDATE dbo.Reports SET ReportName = @ReportName, ReportDescription = @ReportDescription, DatePosted = @DatePosted, ReportBy = @ReportBy WHERE ReportID = @ReportID";
            SqlCommand selectCommand = new SqlCommand(updateStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@ReportID", reportid);
            selectCommand.Parameters.AddWithValue("@ReportName", reportname);
            selectCommand.Parameters.AddWithValue("@ReportDescription", reportdescription);
            selectCommand.Parameters.AddWithValue("@DatePosted", dateposted);
            selectCommand.Parameters.AddWithValue("@ReportBy", reportby);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            var updateReports = reader.Read().ToString();
            sqlConnection.Close();
            return updateReports;
        }

        static public string ViewSpecificReport(long reportid)
        {
            var selectStatement = "SELECT * FROM dbo.Reports WHERE ReportID = @ReportID";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@ReportID", reportid);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                Console.Write($"\n————————————————————— ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"Report #{reader["ReportID"]} ");
                Console.ResetColor();
                Console.WriteLine($"——————————————————————");
                Console.WriteLine($"Report Name: {reader["ReportName"]}");
                Console.WriteLine($"Report Description: {reader["ReportDescription"]}");
                Console.WriteLine($"DatePosted: {reader["DatePosted"]}");
                Console.WriteLine($"ReportBy: {reader["ReportBy"]}");
            }
            var showReports = reader.Read().ToString();
            sqlConnection.Close();
            return showReports;
        }

        static public string RemoveReport(long reportid)
        {
            var deleteStatement = "DELETE FROM dbo.Reports WHERE ReportID = @ReportID";
            SqlCommand selectCommand = new SqlCommand(deleteStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@ReportID", reportid);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            var deleteReport = reader.Read().ToString();
            sqlConnection.Close();
            return deleteReport;
        }
    }
}

