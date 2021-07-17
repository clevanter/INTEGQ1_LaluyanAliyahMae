using System;
using System.Collections.Generic;
using CMS.BL;
using CMS.DL;

namespace CMS.UI
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("VERIMK: YOUR #1 CLIENT MANAGEMENT SOFTWARE\n");
            Console.ResetColor();
            ValidatePersonnel();
        }

        static void ValidatePersonnel()
        {
            Console.Write("Enter your username: ");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            var userName = Console.ReadLine();
            Console.ResetColor();
            Console.Write("Enter your password: ");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            var password = Console.ReadLine();
            Console.ResetColor();

            var LogIn = SqlData.ValidateUser(userName, password);

            if (LogIn.Equals("True"))
            {
                DisplayAction();
                AllOptions();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nWRONG CREDENTIALS!!!\n");
                Console.ResetColor();
                ValidatePersonnel();
            }
        }

        private static List<string> _managements = new List<string>()
                    { "\nTo view Home --------------- type H",
                      "To view Leads -------------- type L",
                      "To view Contacts ----------- type C",
                      "To view Accounts ----------- type A",
                      "To view Deals -------------- type D",
                      "To view More --------------- type M",
                      "To Exit Application -------- type E\n"};

        public static void DisplayAction()
        {
            foreach (var manage in _managements)
            {
                Console.WriteLine(manage);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("INPUT: ");
            Console.ResetColor();
        }

        public static void AllOptions()
        {
            string userChoice = Console.ReadLine().ToUpper();

            switch (userChoice)
            {
                case "H":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n|      HOME       |");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\n                         SALES                    ");
                    Console.ResetColor();
                    Sales();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\n                      INTERACTIONS                      ");
                    Console.ResetColor();
                    SqlData.ViewInteraction();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\n                         TASKS                      ");
                    Console.ResetColor();
                    SqlData.ViewTask();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\n                        REPORTS                      ");
                    Console.ResetColor();
                    SqlData.ViewReport();
                    DisplayAction();
                    AllOptions();
                    break;

                case "L":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n|      LEADS       |");
                    Console.ResetColor();
                    Lead();
                    break;

                case "C":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n|      CONTACTS       |");
                    Console.ResetColor();
                    Contact();
                    break;
                case "A":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n|      ACCOUNTS       |");
                    Console.ResetColor();
                    Account();
                    break;
                case "D":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n|      DEALS       |");
                    Console.ResetColor();
                    Deal();
                    break;
                case "M":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n|      MORE       |");
                    Console.ResetColor();
                    More();
                    break;
                case "E":
                    Console.WriteLine("See you again!");
                    break;
                default:
                    DisplayAction();
                    AllOptions();
                    break;
            }
        }

        public static void Options(string management)
        {
            Console.Write("\nTo view all existing " + management + "..type ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("'V'");
            Console.ResetColor();
            Console.Write("To create a new " + management + ".......type ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("'C'");
            Console.ResetColor();
            Console.Write("To edit existing " + management + "......type ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("'E'");
            Console.ResetColor();
        }

        public static void Lead()
        {
            string management = "Lead";
            Options(management);
            Console.Write("To convert a " + management + "..........type ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("'CV'");
            Console.ResetColor();
            Console.Write("To exit....................type ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("'X'\n");
            Console.ResetColor();
            LeadOptions();
            
        }

        public static void LeadOptions()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("INPUT: ");
            Console.ResetColor();
            string userChoice = Console.ReadLine().ToUpper();

            if (userChoice.Equals("V"))
            {
                ShowSpecificLead();
                Lead();

            }
            else if (userChoice.Equals("C"))
            {
                AddLead();
                Lead();

            }
            else if (userChoice.Equals("E"))
            {
                SqlData.ViewAllLeadCompanyNames();
                UpdateLead();
                Lead();

            }
            else if (userChoice.Equals("CV"))
            {
                ValidateCompanyName();
                Lead();
            }
            else if (userChoice.Equals("X"))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Application is exiting...");
            }
            else
            {
                Lead();
            }
        }

        public static void AddLead()
        {
            Create CreateLead = new Create();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nPlease answer the following questions: ");
            Console.ResetColor();

            Console.Write("Company Name: ");
            CreateLead.CompanyName = Console.ReadLine();

            Console.Write("First Name: ");
            CreateLead.FirstName = Console.ReadLine();

            Console.Write("Last Name: ");
            CreateLead.LastName = Console.ReadLine();

            Console.Write("Title Or Position: ");
            CreateLead.Position = Console.ReadLine();

            Console.Write("E-mail Address: ");
            CreateLead.EmailAdd = Console.ReadLine();

            Console.Write("Mobile Number: ");
            CreateLead.MobileNum = Convert.ToInt64(Console.ReadLine());

            Console.Write("Phone Number: ");
            CreateLead.PhoneNum = Convert.ToInt64(Console.ReadLine());

            Console.Write("Website Link: ");
            CreateLead.WebsiteLink = Console.ReadLine();

            Console.Write("Lead Source: ");
            CreateLead.LeadSource = Console.ReadLine();

            Console.Write("Lead Status: ");
            CreateLead.LeadStatus = Console.ReadLine();

            Console.Write("Industry: ");
            CreateLead.Industry = Console.ReadLine();

            Console.Write("Number Of Employees: ");
            CreateLead.Employees = int.Parse(Console.ReadLine());

            Console.Write("Annual Revenue: ");
            CreateLead.AnnualRevenue = Convert.ToInt64(Console.ReadLine());

            Console.Write("Rating: ");
            CreateLead.Rating = int.Parse(Console.ReadLine());

            Console.Write("Skype Id: ");
            CreateLead.SkypeID = Console.ReadLine();

            CreateLead.CreateNewLead(CreateLead.CompanyName, CreateLead.FirstName, CreateLead.LastName, CreateLead.Position,
                CreateLead.EmailAdd, CreateLead.MobileNum, CreateLead.PhoneNum, CreateLead.WebsiteLink, CreateLead.LeadSource, CreateLead.LeadStatus,
                CreateLead.Industry, CreateLead.Employees, CreateLead.AnnualRevenue, CreateLead.Rating, CreateLead.SkypeID);
        }

        public static void ShowSpecificLead()
        {
            SqlData.ViewAllLeadCompanyNames();
            Console.Write("\nPlease enter the Lead's Company Name: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            var companyName = Console.ReadLine();
            Console.ResetColor();

            var ifCompanyNameExist = SqlData.CompanyNameValidation(companyName);

            if (ifCompanyNameExist.Equals("True"))
            {
                SqlData.ShowLead(companyName);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nCompany Name doesn't exist!!!");
                Console.ResetColor();
                ShowSpecificLead();
            }
        }

        static void ValidateCompanyName()
        {
            SqlData.ViewAllLeadCompanyNames();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\nPlease enter the Lead's Company Name: ");
            Console.ResetColor();

            var companyName = Console.ReadLine();
            var ifCompanyNameExist = SqlData.CompanyNameValidation(companyName);
            var toConvertLead = SqlData.ConvertLead(companyName);

            if (ifCompanyNameExist.Equals("True"))
            {
                SqlData.ConvertLead(toConvertLead);
                InputRemainingContactInfo();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nCompany Name doesn't exist!!!");
                Console.ResetColor();
                ValidateCompanyName();
            }
        }

        static void UpdateLead()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nPlease enter the Lead's Company Name: ");
            Console.ResetColor();
            var companyName = Console.ReadLine();

            var ifCompanyNameExist = SqlData.CompanyNameValidation(companyName);

            if (ifCompanyNameExist.Equals("True"))
            {
                Create LeadUpdate = new Create();
                Update UpdateLead = new Update();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nPlease answer the following questions!");
                Console.ResetColor();

                Console.Write("Company Name: ");
                string leadCompany = Console.ReadLine();

                Console.Write("First Name: ");
                LeadUpdate.FirstName = Console.ReadLine();

                Console.Write("Last Name: ");
                LeadUpdate.LastName = Console.ReadLine();

                Console.Write("Title Or Position: ");
                LeadUpdate.Position = Console.ReadLine();

                Console.Write("E-mail Address: ");
                LeadUpdate.EmailAdd = Console.ReadLine();

                Console.Write("Mobile Number: ");
                LeadUpdate.MobileNum = Convert.ToInt64(Console.ReadLine());

                Console.Write("Phone Number: ");
                LeadUpdate.PhoneNum = Convert.ToInt64(Console.ReadLine());

                Console.Write("Website Link: ");
                LeadUpdate.WebsiteLink = Console.ReadLine();

                Console.Write("Lead Source: ");
                LeadUpdate.LeadSource = Console.ReadLine();

                Console.Write("Lead Status: ");
                LeadUpdate.LeadStatus = Console.ReadLine();

                Console.Write("Industry: ");
                LeadUpdate.Industry = Console.ReadLine();

                Console.Write("Number Of Employees: ");
                LeadUpdate.Employees = int.Parse(Console.ReadLine());

                Console.Write("Annual Revenue: ");
                LeadUpdate.AnnualRevenue = Convert.ToInt64(Console.ReadLine());

                Console.Write("Rating: ");
                LeadUpdate.Rating = int.Parse(Console.ReadLine());

                Console.Write("Skype Id: ");
                LeadUpdate.SkypeID = Console.ReadLine();

                 UpdateLead.UpdateExistingLead(leadCompany, LeadUpdate.FirstName, LeadUpdate.LastName, LeadUpdate.Position, LeadUpdate.EmailAdd, 
                 LeadUpdate.MobileNum, LeadUpdate.PhoneNum, LeadUpdate.WebsiteLink, LeadUpdate.LeadSource, LeadUpdate.LeadStatus,
                 LeadUpdate.Industry, LeadUpdate.Employees, LeadUpdate.AnnualRevenue, LeadUpdate.Rating, LeadUpdate.SkypeID);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Company does not exist!!!");
                Console.ResetColor();
                UpdateLead();
            }


        }

        public static void InputRemainingContactInfo()
        {
            SqlData.ViewContactContactPerson();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nPlease enter the Contact's Account Name: ");
            Console.ResetColor();
            var accountName = Console.ReadLine();

            Create CreateContact = new Create();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nPlease input remaining details: ");
            Console.ResetColor();

            Console.WriteLine("Contact's Department: ");
            CreateContact.Department = Console.ReadLine();

            Console.WriteLine("Birth Date: ");
            CreateContact.BirthDate = Console.ReadLine();

            Console.WriteLine("Assistant Name: ");
            CreateContact.Assistant = Console.ReadLine();

            Console.WriteLine("Asssitant Phone Number: ");
            CreateContact.AssistantPhone = Convert.ToInt64(Console.ReadLine());

            SqlData.InsertRemainingContactInfo(accountName, CreateContact.Department,
                    CreateContact.BirthDate, CreateContact.Assistant, CreateContact.AssistantPhone);

            SqlData.ShowContact(accountName);
        }

        public static void Contact()
        {
            string management = "Contact";
            Options(management);
            Console.Write("To exit.......................type ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("'X'\n");
            Console.ResetColor();
            ContactOptions();
        }

        public static void ContactOptions()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("INPUT: ");
            Console.ResetColor();
            string userChoice = Console.ReadLine().ToUpper();

            if (userChoice.Equals("V"))
            {
                ShowSpecificContact();
                Contact();
            }
            else if (userChoice.Equals("C"))
            {
                AddContact();
                Contact();
            }
            else if (userChoice.Equals("E"))
            {
                SqlData.ViewContactContactPerson();
                UpdateContact();
                Contact();

            }
            else if (userChoice.Equals("X"))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Application is exiting...");
            }
            else
            {
                Contact();
            }
        }

        public static void AddContact()
        {
            Create CreateContact = new Create();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nPlease answer the following questions: ");
            Console.ResetColor();

            Console.Write("Account Name: ");
            CreateContact.AccountName = Console.ReadLine();

            Console.Write("Lead Source: ");
            CreateContact.LeadSource = Console.ReadLine();

            Console.Write("First Name: ");
            CreateContact.FirstName = Console.ReadLine();

            Console.Write("Last Name: ");
            CreateContact.LastName = Console.ReadLine();

            Console.Write("Position: ");
            CreateContact.Position = Console.ReadLine();

            Console.Write("Email Address: ");
            CreateContact.EmailAdd = Console.ReadLine();

            Console.Write("Department: ");
            CreateContact.Department = Console.ReadLine();

            Console.Write("Mobile Number: ");
            CreateContact.MobileNum = Convert.ToInt64(Console.ReadLine());

            Console.Write("Phone Number: ");
            CreateContact.PhoneNum = Convert.ToInt64(Console.ReadLine());

            Console.Write("Birth Date: ");
            CreateContact.BirthDate = Console.ReadLine();

            Console.Write("Assistant Name: ");
            CreateContact.Assistant = Console.ReadLine();

            Console.Write("Asssitant Phone Number: ");
            CreateContact.AssistantPhone = Convert.ToInt64(Console.ReadLine());

            Console.Write("Skype ID: ");
            CreateContact.SkypeID = Console.ReadLine();

            CreateContact.CreateNewContact(CreateContact.AccountName, CreateContact.LeadSource, CreateContact.FirstName, CreateContact.LastName, CreateContact.Position,
            CreateContact.EmailAdd, CreateContact.Department, CreateContact.MobileNum, CreateContact.PhoneNum, CreateContact.BirthDate, CreateContact.Assistant,
            CreateContact.AssistantPhone, CreateContact.SkypeID);
        }

        public static void ShowSpecificContact()
        {
            SqlData.ViewContactContactPerson();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\nPlease enter the Contact's Account Name: ");
            Console.ResetColor();
            var accountName = Console.ReadLine();

            var ifAccountNameExist = SqlData.ContactFirstNameValidation(accountName);

            if (ifAccountNameExist.Equals("True"))
            {
                SqlData.ShowContact(accountName);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Account name doesn't exist!!!");
                ShowSpecificContact();
            }
        }

        public static void UpdateContact()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nPlease enter the Contact's Account Name: ");
            Console.ResetColor();
            var accountName = Console.ReadLine();

            var ifAccountNameExist = SqlData.ContactFirstNameValidation(accountName);

            if (ifAccountNameExist.Equals("True"))
            {
                Update UpdateContact = new Update();
                Create ContactUpdate = new Create();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.ResetColor();
                Console.WriteLine("\nPlease answer the following questions!");

                Console.Write("Account Name: ");
                ContactUpdate.AccountName = Console.ReadLine();

                Console.Write("Lead Source: ");
                ContactUpdate.LeadSource = Console.ReadLine();

                Console.Write("First Name: ");
                ContactUpdate.FirstName = Console.ReadLine();

                Console.Write("Last Name: ");
                ContactUpdate.LastName = Console.ReadLine();

                Console.Write("Title Or Position: ");
                ContactUpdate.Position = Console.ReadLine();

                Console.Write("E-mail Address: ");
                ContactUpdate.EmailAdd = Console.ReadLine();

                Console.Write("Department: ");
                ContactUpdate.Department = Console.ReadLine();

                Console.Write("Mobile Number: ");
                ContactUpdate.MobileNum = Convert.ToInt64(Console.ReadLine());

                Console.Write("Phone Number: ");
                ContactUpdate.PhoneNum = Convert.ToInt64(Console.ReadLine());

                Console.Write("Birth Date: ");
                ContactUpdate.BirthDate = Console.ReadLine();

                Console.Write("Assistant Name: ");
                ContactUpdate.Assistant = Console.ReadLine();

                Console.Write("Asssitant Phone Number: ");
                ContactUpdate.AssistantPhone = Convert.ToInt64(Console.ReadLine());

                Console.Write("Skype Id: ");
                ContactUpdate.SkypeID = Console.ReadLine();


                UpdateContact.UpdateExistingContact(ContactUpdate.AccountName, ContactUpdate.LeadSource, ContactUpdate.FirstName, ContactUpdate.LastName, ContactUpdate.Position,
                ContactUpdate.EmailAdd, ContactUpdate.Department, ContactUpdate.MobileNum, ContactUpdate.PhoneNum, ContactUpdate.BirthDate, ContactUpdate.Assistant,
                ContactUpdate.AssistantPhone, ContactUpdate.SkypeID);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Company does not exist!!!");
                UpdateContact();
            }
        }

        public static void Deal()
        {
            string management = "Deal";
            Options(management);
            Console.Write("To exit....................type ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("'X'\n");
            Console.ResetColor();
            DealOptions();
        }

        public static void DealOptions()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("INPUT: ");
            Console.ResetColor();
            string userChoice = Console.ReadLine().ToUpper();

            if (userChoice.Equals("V"))
            {
                ShowSpecificDeal();
                Deal();
            }
            else if (userChoice.Equals("C"))
            {
                AddDeal();
                Deal();
            }
            else if (userChoice.Equals("E"))
            {
                SqlData.ViewDealName();
                UpdateDeal();
                Deal();
            }
            else if (userChoice.Equals("X"))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Application is exiting...");
            }
            else
            {
                Contact();
            }
        }

        public static void AddDeal()
        {
            Create CreateDeal = new Create();
            DealInformation NewDeal = new DealInformation();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nPlease answer the following questions: \n");
            Console.ResetColor();

            Console.Write("Deal Name: ");
            NewDeal.DealName = Console.ReadLine();

            Console.Write("Closing Date in YYYY-MM-DD format: ");
            NewDeal.ClosingDate = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Account Name: ");
            NewDeal.AccountName = Console.ReadLine();

            Console.Write("Probability: ");
            NewDeal.Probability = int.Parse(Console.ReadLine());

            Console.Write("Expected Revenue: ");
            NewDeal.ExpectedRevenue = int.Parse(Console.ReadLine());

            Console.Write("Lead Source: ");
            NewDeal.LeadSource = Console.ReadLine();

            Console.Write("Contact Name: ");
            NewDeal.ContactName = Console.ReadLine();

            Console.Write("Deal Description: ");
            NewDeal.DealDescription = Console.ReadLine();

            NewDeal.Status = "U";

            CreateDeal.CreateNewDeal(NewDeal.DealName, NewDeal.ClosingDate, NewDeal.AccountName, NewDeal.Probability, NewDeal.ExpectedRevenue,
                NewDeal.LeadSource, NewDeal.ContactName, NewDeal.DealDescription, NewDeal.Status);
        }

        public static void ShowSpecificDeal()
        {
            SqlData.ViewDealName();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\nPlease enter the Deal name: ");
            Console.ResetColor();
            var dealName = Console.ReadLine();

            var ifDealNameexist = SqlData.DealNameValidation(dealName);
            if (ifDealNameexist.Equals("True"))
            {
                SqlData.ShowDeal(dealName);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nDeal name doesn't exist!!!");
                Console.ResetColor();
                ShowSpecificDeal();
            }
        }

        public static void UpdateDeal()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\nPlease enter the Deal Name: ");
            Console.ResetColor();

            var dealNameValidation = Console.ReadLine();
            var ifDealNameExist = SqlData.DealNameValidation(dealNameValidation);

            if (ifDealNameExist.Equals("True"))
            {
                Update ForUpdateDeal = new Update();
                DealInformation DealUpdate = new DealInformation();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nPlease answer the following questions: ");
                Console.ResetColor();

                Console.Write("Deal Name: ");
                string dealName = Console.ReadLine();

                Console.Write("Closing Date in YYYY-MM-DD format: ");
                DealUpdate.ClosingDate = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Account Name: ");
                DealUpdate.AccountName = Console.ReadLine();

                Console.Write("Probability: ");
                DealUpdate.Probability = int.Parse(Console.ReadLine());

                Console.Write("Expected Revenue: ");
                DealUpdate.ExpectedRevenue = int.Parse(Console.ReadLine());

                Console.Write("Lead Source: ");
                DealUpdate.LeadSource = Console.ReadLine();

                Console.Write("Contact Name: ");
                DealUpdate.ContactName = Console.ReadLine();

                Console.Write("Deal Description: ");
                DealUpdate.DealDescription = Console.ReadLine();

                Console.Write("Status 'W' for Win, 'L' for Lose, 'U' for Uncertain: ");
                DealUpdate.Status = Console.ReadLine().ToUpper();

                if (DealUpdate.Status.Equals ("W") || DealUpdate.Status.Equals ("L")  || DealUpdate.Status.Equals("U"))
                {
                    ForUpdateDeal.UpdateExistingDeal(dealName, DealUpdate.ClosingDate, DealUpdate.AccountName, DealUpdate.Probability, DealUpdate.ExpectedRevenue,
                    DealUpdate.LeadSource, DealUpdate.ContactName, DealUpdate.DealDescription, DealUpdate.Status);                                                          
                }
                else
                {
                    UpdateDeal();
                }
            }
            else
            {
                Console.WriteLine("Company does not exist");
                UpdateDeal();
            }
        }

        public static void Sales()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("'W'");
            Console.ResetColor();
            Console.Write(" for Win,");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("'L'");
            Console.ResetColor();
            Console.Write(" for Loss,");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("'U'");
            Console.ResetColor();
            Console.Write(" for Uncertain: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            var status = Console.ReadLine().ToUpper();
            Console.ResetColor();

            if (status.Equals("W"))
            {
                SqlData.SureRevenue(status);
            }
            else if (status.Equals("L"))
            {
                SqlData.SureRevenue(status);
            }
            else if (status.Equals("U"))
            {

                SqlData.SureRevenue(status);
            }
            else
            {
                Sales();
            }
        }

        public static void Account()
        {
            string management = "Accounts";
            Options(management);
            Console.Write("To import from Lead............type ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("'I'");
            Console.ResetColor();
            Console.Write("To exit........................type ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("'X'\n");
            Console.ResetColor();
            AccountOptions();
        }

        public static void AccountOptions()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("INPUT: ");
            Console.ResetColor();
            string userChoice = Console.ReadLine().ToUpper();

            if (userChoice.Equals("V"))
            {
                ShowSpecificAccount();
                Account();
            }
            else if (userChoice.Equals("C"))
            {
                AddAccount();
                Account();
            }
            else if (userChoice.Equals("I"))
            {
                ImportLeadToAccount();
                Account();
            }
            else if (userChoice.Equals("E"))
            {
                SqlData.ViewAccountNames();
                UpdateAccount();
                Account();
            }
            else if (userChoice.Equals("X"))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nApplication is exiting...");
            }
            else
            {
                Account();
            }
        }

        public static void ShowSpecificAccount()
        {
            SqlData.ViewAccountNames();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\nPlease enter the Account Name: ");
            Console.ResetColor();
            var accountName = Console.ReadLine();

            var ifAccountNameExist = SqlData.AccountNameValidation(accountName);

            if (ifAccountNameExist.Equals("True"))
            {
                SqlData.ShowAccount(accountName);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Account name doesn't exist");
                ShowSpecificAccount();
            }
        }

        public static void AddAccount()
        {
            Create NewAccount = new Create();
            ContactInformation CreateAccount = new ContactInformation();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nPlease answer the following questions: ");
            Console.ResetColor();

            Console.Write("Account Name: ");
            string accountName = Console.ReadLine();

            Console.Write("Account Number: ");
            long accountNum = Convert.ToInt64(Console.ReadLine());

            Console.Write("Industry: ");
            CreateAccount.Industry = Console.ReadLine();

            Console.Write("Rating: ");
            CreateAccount.Rating = int.Parse(Console.ReadLine());

            Console.Write("Phone Number: ");
            CreateAccount.PhoneNum = Convert.ToInt64(Console.ReadLine());

            Console.Write("Website Link: ");
            CreateAccount.WebsiteLink = Console.ReadLine();

            Console.Write("Number of Employees: ");
            CreateAccount.Employees = int.Parse(Console.ReadLine());

            Console.Write("Annual Revenue: ");
            CreateAccount.AnnualRevenue = Convert.ToInt64(Console.ReadLine());

            NewAccount.CreateNewAccount(accountName, accountNum, CreateAccount.Industry, CreateAccount.Rating, CreateAccount.PhoneNum,
            CreateAccount.WebsiteLink, CreateAccount.Employees, CreateAccount.AnnualRevenue);
        }

        public static void ImportLeadToAccount()
        {
            SqlData.ViewAllLeadCompanyNames();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nPlease enter the Company Name of the lead you want to import: ");
            Console.ResetColor();
            var companyName = Console.ReadLine();
            var companyNameValidated = SqlData.CompanyNameValidation(companyName);

            if (companyNameValidated.Equals("True"))
            {
                SqlData.ImportAccount(companyName);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nPlease answer the following information: ");
                Console.ResetColor();
                Console.Write("Account Number: ");
                long accountNum = Convert.ToInt64(Console.ReadLine());

                SqlData.InsertRemainingAccountInfo(companyName, accountNum);
                SqlData.ShowAccount(companyName);
                SqlData.RemoveInLead(companyName);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Company name does not exist!!!");
                ImportLeadToAccount();
            }

        }

        public static void UpdateAccount()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nPlease enter the Contact's Account Name: ");
            Console.ResetColor();

            var accountName = Console.ReadLine();
            var ifAccountNameExist = SqlData.AccountNameValidation(accountName);

            if (ifAccountNameExist.Equals("True"))
            {
                Update AccountUpdate = new Update();
                ContactInformation CreateAccount = new ContactInformation();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nPlease answer the following information: ");
                Console.ResetColor();

                Console.Write("Account Name: ");
                accountName = Console.ReadLine();

                Console.Write("Account Number: ");
                long accountNum = Convert.ToInt64(Console.ReadLine());

                Console.Write("Industry: ");
                CreateAccount.Industry = Console.ReadLine();

                Console.Write("Rating: ");
                CreateAccount.Rating = int.Parse(Console.ReadLine());

                Console.Write("Phone Number: ");
                CreateAccount.PhoneNum = Convert.ToInt64(Console.ReadLine());

                Console.Write("Website Link: ");
                CreateAccount.WebsiteLink = Console.ReadLine();

                Console.Write("Number of Employees: ");
                CreateAccount.Employees = int.Parse(Console.ReadLine());

                Console.Write("Annual Revenue: ");
                CreateAccount.AnnualRevenue = Convert.ToInt64(Console.ReadLine());

                AccountUpdate.UpdateExistingAccount(accountName, accountNum, CreateAccount.Industry, CreateAccount.Rating, CreateAccount.PhoneNum, CreateAccount.WebsiteLink,
                    CreateAccount.Employees, CreateAccount.AnnualRevenue);     
            }
            else
            {
                UpdateAccount();
            }
        }

        private static List<string> _otherManagements = new List<string>()
                    { "\nTo view Interaction -------------------- type I",
                      "To view Task --------------------------- type T",
                      "To view Reports ------------------------ type R",
                      "To go back to the Previous Page -------- type P\n"};

        public static void DisplayActionForOther()
        {
            foreach (var manage in _otherManagements)
            {
                Console.WriteLine(manage);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("INPUT: ");
            Console.ResetColor();
        }

        public static void More()
        {
            DisplayActionForOther();
            OtherManagements();
        }

        public static void OtherManagements()
        {
            string UserChoice = Console.ReadLine().ToUpper();

            switch (UserChoice)
            {
                case "I":
                    Interaction();
                    More();
                    break;
                case "T":
                    Task();
                    More();
                    break;
                case "R":
                    Reports();
                    More();
                    break;
                case "P":
                    DisplayAction();
                    AllOptions();
                    break;
                default:
                    break;
            }
        }

        public static void Interaction()
        {
            string management = "Interactions";
            Options(management);
            Console.Write("To Remove existing Interaction.....type ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("'R'");
            Console.ResetColor();
            Console.Write("To exit............................type ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("'X'\n");
            Console.ResetColor();
            InteractionOptions();
        }

        public static void InteractionOptions()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("INPUT: ");
            Console.ResetColor();
            string userChoice = Console.ReadLine().ToUpper();

            if (userChoice.Equals("V"))
            {
                SqlData.ShowAllInteraction();
                Interaction();
            }
            else if (userChoice.Equals("C"))
            {
                AddInteraction();
                SqlData.ShowAllInteraction();
                Interaction();
            }
            else if (userChoice.Equals("E"))
            {
                SqlData.ViewInteraction();
                UpdateInteraction();
                Interaction();
            }
            else if (userChoice.Equals("R"))
            {
                RemoveInteraction();
            }
            else if (userChoice.Equals("X"))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Application is exiting...");
            }
            else
            {
                Interaction();
            }
        }

        public static void AddInteraction()
        {
            AutoGenerate GenerateID = new AutoGenerate();
            Create NewInteraction = new Create();
            InteractionInformation CreateInteraction = new InteractionInformation();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nPlease answer the following questions: \n");
            Console.ResetColor();

            Console.Write("Contact Name: ");
            CreateInteraction.ContactName = Console.ReadLine();

            Console.Write("Type of Interaction: ");
            CreateInteraction.Type = Console.ReadLine();

            Console.Write("Used Number: ");
            CreateInteraction.UsedNumber = Convert.ToInt64(Console.ReadLine());

            Console.Write("Used Email: ");
            CreateInteraction.UsedEmail = Console.ReadLine();

            Console.Write("Date and Duration in YYYY-MM-DD 00:00AM : ");
            CreateInteraction.DateAndDuration = Convert.ToDateTime(Console.ReadLine());

            NewInteraction.CreateNewInteraction(CreateInteraction.ContactName, CreateInteraction.Type, CreateInteraction.UsedNumber, CreateInteraction.UsedEmail, CreateInteraction.DateAndDuration);
            GenerateID.InteractionID(CreateInteraction.ContactName);
        }

        public static void UpdateInteraction()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Please enter the Interaction ID: ");
            Console.ResetColor();
            var interactionID = Convert.ToInt64(Console.ReadLine());

            var ifInteractionIDExist = SqlData.InteractionIDValidation(interactionID);

            if (ifInteractionIDExist.Equals("True"))
            {
                Update InteractionUpdate = new Update();
                InteractionInformation CreateInteraction = new InteractionInformation();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nPlease answer the following questions: \n");
                Console.ResetColor();

                Console.Write("Contact Name: ");
                CreateInteraction.ContactName = Console.ReadLine();

                Console.Write("Type of Interaction: ");
                CreateInteraction.Type = Console.ReadLine();

                Console.Write("Used Number: ");
                CreateInteraction.UsedNumber = Convert.ToInt64(Console.ReadLine());

                Console.Write("Used Email: ");
                CreateInteraction.UsedEmail = Console.ReadLine();

                Console.Write("Date and Duration in YYYY-MM-DD 00:00AM : ");
                CreateInteraction.DateAndDuration = Convert.ToDateTime(Console.ReadLine());

                InteractionUpdate.UpdateExistingInteraction(interactionID, CreateInteraction.ContactName, CreateInteraction.Type, CreateInteraction.UsedNumber, 
                CreateInteraction.UsedEmail, CreateInteraction.DateAndDuration);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nIncorrect Interaction ID!!!\n");
                Console.ResetColor();
                UpdateInteraction();

            }

        }

        public static void RemoveInteraction()
        {
            SqlData.ShowAllInteraction();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("To delete Interaction please enter the Interaction ID: ");
            Console.ResetColor();
            var interactionID = Convert.ToInt64(Console.ReadLine());

            var ifInteractionIDExist = SqlData.InteractionIDValidation(interactionID);

            if (ifInteractionIDExist.Equals("True"))
            {
                SqlData.RemoveFromInteraction(interactionID);
                SqlData.ShowAllInteraction();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nIncorrect Interaction ID!!!\n");
                Console.ResetColor();
                RemoveInteraction();
            }
            
        }

        public static void Task()
        {
            string management = "Task";
            Options(management);
            Console.Write("To remove existing Task....type ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("'R'");
            Console.ResetColor();
            Console.Write("To exit....................type ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("'X'\n");
            Console.ResetColor();
            TaskOption();
        }

        public static void TaskOption()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("INPUT: ");
            Console.ResetColor();
            string userChoice = Console.ReadLine().ToUpper();

            if (userChoice.Equals("V"))
            {
                SqlData.ShowAllTask();
                Task();
            }
            else if (userChoice.Equals("C"))
            {
                AddTask();
                SqlData.ShowAllTask();
                Task();
            }
            else if (userChoice.Equals("E"))
            {
                SqlData.ViewTask();
                UpdateTask();
                Task();
            }
            else if (userChoice.Equals("R"))
            {
                RemoveTask();
                Task();
            }
            else if (userChoice.Equals("X"))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Application is exiting...");
            }
            else
            {
                Task();
            }
        }

        public static void AddTask()
        {
            Create NewTask = new Create();
            AutoGenerate GenerateIDforTask = new AutoGenerate();
            TaskInformation CreateTask = new TaskInformation();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nPlease answer the following questions: \n");
            Console.ResetColor();        

            Console.Write("Task Type: ");
            CreateTask.TaskType = Console.ReadLine();

            Console.Write("Date Posted: ");
            CreateTask.DatePosted = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Due Date: ");
            CreateTask.DueDate = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Task Title: ");
            CreateTask.TaskTitle = Console.ReadLine();

            Console.Write("Task Description: ");
            CreateTask.TaskDescription = Console.ReadLine();

            Console.Write("Task Assigned: ");
            CreateTask.TaskAssigned = Console.ReadLine();

            Console.Write("Progress 'C' for complete, 'U' for Unfinished: ");
            CreateTask.Progress = Console.ReadLine().ToUpper();

            if (CreateTask.Progress.Equals("C") || CreateTask.Progress.Equals("U"))
            {
                NewTask.CreateNewTask(CreateTask.TaskType, CreateTask.DatePosted, CreateTask.DueDate, CreateTask.TaskTitle, CreateTask.TaskDescription,
                    CreateTask.TaskAssigned, CreateTask.Progress);
                GenerateIDforTask.TaskID(CreateTask.TaskTitle);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nWrong Input!!!");
                Console.ResetColor();
                AddTask();
            }
        }

        public static void UpdateTask()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\nPlease enter the Task ID: ");
            Console.ResetColor();
            var taskID = Convert.ToInt64(Console.ReadLine());

            var ifTaskIDExist = SqlData.TaskIDValidation(taskID);

            if (ifTaskIDExist.Equals("True"))
            {
                Update TaskUpdate = new Update();
                TaskInformation CreateTask = new TaskInformation();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nPlease answer the following: \n");
                Console.ResetColor();

                Console.Write("Task Type: ");
                CreateTask.TaskType = Console.ReadLine();

                Console.Write("Date Posted: ");
                CreateTask.DatePosted = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Due Date: ");
                CreateTask.DueDate = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Task Title: ");
                CreateTask.TaskTitle = Console.ReadLine();

                Console.Write("Task Description: ");
                CreateTask.TaskDescription = Console.ReadLine();

                Console.Write("Task Assigned: ");
                CreateTask.TaskAssigned = Console.ReadLine();

                Console.Write("Progress 'C' for complete, 'U' for Unfinished: ");
                CreateTask.Progress = Console.ReadLine().ToUpper();

                TaskUpdate.UpdateExistingTask(taskID, CreateTask.TaskType, CreateTask.DatePosted, CreateTask.DueDate, CreateTask.TaskTitle, CreateTask.TaskDescription,
                    CreateTask.TaskAssigned, CreateTask.Progress);

                if (CreateTask.Progress.Equals("C"))
                {
                    SqlData.RemoveCompletedTask(taskID);
                    SqlData.ViewSpecificTask(taskID);
                }
                else 
                {
                    SqlData.ViewSpecificTask(taskID);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nWrong Input!!!");
                Console.ResetColor();
                UpdateTask();
            }

            
        }

        public static void RemoveTask()
        {
            SqlData.ShowAllTask();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("To delete Task please enter the Task ID: ");
            Console.ResetColor();
            var taskID = Convert.ToInt64(Console.ReadLine());
            var ifTaskIDExist = SqlData.TaskIDValidation(taskID);

            if (ifTaskIDExist.Equals("True"))
            {
                SqlData.RemoveCompletedTask(taskID);
                SqlData.ShowAllTask();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nWrong Input!!!");
                Console.ResetColor();
                RemoveTask();
            }
        }

        public static void Reports()
        {
            string management = "Report";
            Options(management);
            Console.Write("To remove existing Report....type ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("'R'");
            Console.ResetColor();
            Console.Write("To exit......................type ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("'X'\n");
            Console.ResetColor();
            ReportOptions();
        }

        public static void ReportOptions()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("INPUT: ");
            Console.ResetColor();
            string UserChoice = Console.ReadLine().ToUpper();

            if (UserChoice.Equals("V"))
            {
                SqlData.ShowAllReports();
                Reports();
            }
            else if (UserChoice.Equals("C"))
            {
                AddReport();
                SqlData.ShowAllReports();
                Reports();
            }
            else if (UserChoice.Equals("E"))
            {
                SqlData.ViewReport();
                UpdateReport();
            }
            else if (UserChoice.Equals("R"))
            {
                RemoveReport();
            }
            else if (UserChoice.Equals("X"))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Application is exiting...");
            }
            else
            {
                Reports();
            }
        }

        public static void AddReport()
        {
            Create NewReport = new Create();
            AutoGenerate GenerateIDforReport = new AutoGenerate();
            ReportInformation CreateReport = new ReportInformation();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nPlease answer the following information: \n");
            Console.ResetColor();

            Console.Write("Report Name: ");
            CreateReport.ReportName = Console.ReadLine();

            Console.Write("Report Description: ");
            CreateReport.ReportDescription = Console.ReadLine();

            Console.Write("Date Posted: ");
            CreateReport.DatePosted = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Author: ");
            CreateReport.ReportBy = Console.ReadLine();

            NewReport.CreateNewReport(CreateReport.ReportName, CreateReport.ReportDescription, CreateReport.DatePosted, CreateReport.ReportBy);
            GenerateIDforReport.ReportID(CreateReport.ReportName);
        }

        public static void UpdateReport()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\nPlease enter the Task ID: ");
            Console.ResetColor();
            var reportID = Convert.ToInt64(Console.ReadLine());

            var ifReportIDExist = SqlData.ReportIDValidation(reportID);

            if (ifReportIDExist.Equals("True"))
            {

                ReportInformation CreateReport = new ReportInformation();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nPlease answer the following information: ");
                Console.ResetColor();

                Console.Write("Report Name: ");
                CreateReport.ReportName = Console.ReadLine();

                Console.Write("Report Description: ");
                CreateReport.ReportDescription = Console.ReadLine();

                Console.Write("Date Posted: ");
                CreateReport.DatePosted = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Author: ");
                CreateReport.ReportBy = Console.ReadLine();

                SqlData.UpdateReport(reportID, CreateReport.ReportName, CreateReport.ReportDescription, CreateReport.DatePosted, CreateReport.ReportBy);               
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nWrong Input!!!");
                Console.ResetColor();
                UpdateReport();
            }
        }

        public static void RemoveReport()
        {
            SqlData.ShowAllReports();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("To delete a Report please enter the Report ID: ");
            Console.ResetColor();
            var reportID = Convert.ToInt64(Console.ReadLine());
            var ifReportIDExist = SqlData.ReportIDValidation(reportID);

            if (ifReportIDExist.Equals("True"))
            {
                SqlData.RemoveReport(reportID);
                SqlData.ShowAllReports();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nWrong Input!!!");
                Console.ResetColor();
            }
        }

    }
}

    






