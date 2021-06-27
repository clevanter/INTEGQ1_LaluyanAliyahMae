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
      
            Console.WriteLine("Verimk: Your #1 Client Management Software\n");
            ValidatePersonnel();

            //sales
            //accounts
            //home
            //input validation
            //update - lists
            //convert leads to contact
        }

        static void ValidatePersonnel()
        {
            Console.Write("Enter your username: ");
            var userName = Console.ReadLine();
            Console.Write("Enter your password: ");
            var password = Console.ReadLine();
            
            var LogIn = SqlData.ValidateUser(userName, password);

            if (LogIn.Equals("True"))
            {
                DisplayAction();
                AllOptions();
            }
            else
            {
                Console.WriteLine("Wrong Credentials");
                ValidatePersonnel();
            }
        }

        private static List<string> _managements = new List<string>()
                    { "\nTo view Home --------------- type H",
                      "To view Leads -------------- type L",
                      "To view Contacts ----------- type C",
                      "To view Accounts ----------- type A",
                      "To view Deals -------------- type D",
                      "To view Sales -------------- type S",
                      "To Exit Application -------- type E\n"};

        public static void DisplayAction()
        {
            foreach (var manage in _managements)
            {
                Console.WriteLine(manage);
            }
            Console.Write("INPUT: ");
        }

        public static void AllOptions()
        {
            string UserChoice = Console.ReadLine().ToUpper();

            switch (UserChoice)
            {
                case "H":
                    Console.WriteLine("Home");
                    break;

                case "L":
                    Console.WriteLine("———————————————— Lead ————————————————\n");
                    ViewingLeadOptions();
                    UserChoice = Console.ReadLine().ToUpper();

                    if (UserChoice.Equals("V"))
                    {
                        SqlData.ShowLead();
                        //ListOfLeadNames(); to be implemented
                    }
                    else if (UserChoice.Equals("C"))
                    {
                        AddLead();
                    }
                    else if (UserChoice.Equals("CV"))
                    {
                        ValidateCompanyName();
                    }
                    else
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            ViewingLeadOptions();
                            Console.WriteLine("Input: ");
                            UserChoice = Console.ReadLine().ToUpper();
                            Console.WriteLine("Program is existing");
                        }
                    }
                    break;

                case "C":
                    Console.WriteLine("———————————————— Contacts ————————————————\n");
                    ViewingContactsOption();
                    UserChoice = Console.ReadLine().ToUpper();

                    if (UserChoice.Equals("V"))
                    {
                        SqlData.ShowContact();
                        //ListOfContactNames(); to be implemented
                        //ForViewingContact(); to be implemented
                    }
                    else if (UserChoice.Equals("C"))
                    {
                        AddContact();
                    }
                    else
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            ViewingLeadOptions();
                            Console.WriteLine("Input: ");
                            UserChoice = Console.ReadLine().ToUpper();
                            Console.WriteLine("Program is existing");
                        }
                    }


                    break;
                case "A":
                    Console.WriteLine("———————————————— Accounts ————————————————\n");
                    break;
                case "D":
                    Console.WriteLine("———————————————— Deals ————————————————\n");
                    ViewingDealOptions();
                    UserChoice = Console.ReadLine().ToUpper();

                    if (UserChoice == "V")
                    {
                        ListOfDeals(); //to be implemented
                        ForViewingDeal(); // to be implemented

                    }
                    else if (UserChoice == "C")
                    {
                        ForCreatingDeal(); // to be implemented 
                    }
                    break;
                case "S":
                    Console.WriteLine("———————————————— Sales ————————————————\n");
                    break;
                case "E":
                    Console.WriteLine("Good Bye");
                    break;
                default:
                    DisplayAction();
                    AllOptions();
                    break;
            }
        }

        public static void ForViewingContact()
        {
            //to be implemented
            Console.Write("INPUT: ");
            string UserChoice = Console.ReadLine().ToUpper();


            switch (UserChoice)
            {
                case "1":
                    //Contact DisplayFirstContact = new Contact();
                    //DisplayFirstContact.FirstContact();
                    break;

                case "2":
                    //Contact DisplaySecondContact = new Contact();
                    //DisplaySecondContact.SecondContact();
                    break;

                default:
                    //Contact ContactOptions = new Contact();
                    ListOfContactNames();
                    ForViewingContact();
                    Console.WriteLine("Input: ");
                    UserChoice = Console.ReadLine().ToUpper();
                    break;
            }
        }

        public static void ForCreatingContact()
        {
            //to be implmented
            //Contact ContactOptions = new Contact();
            Create CreateContact = new Create();
            AddContact();
            ViewingContactsOption();
            string UserChoice = Console.ReadLine().ToUpper();

            switch (UserChoice)
            {
                case "V":
                    ListOfContactNames();
                    UserChoice = Console.ReadLine().ToUpper();


                    if (UserChoice == "1")
                    {
                        //Contact DisplayFirstContact = new Contact();
                        //DisplayFirstContact.FirstContact();
                    }
                    else if (UserChoice == "2")
                    {
                        //Contact DisplaySecondContact = new Contact();
                        //DisplaySecondContact.SecondContact();
                    }
                    else if (UserChoice == "3")
                    {
                        Create DisplayNewContact = new Create();
                        DisplayNewContact.AddAContact();
                    }
                    else
                    {
                        Console.WriteLine("Program is exiting");
                    }
                    break;
                case "C":
                    AddContact();
                    break;
                default:
                    Console.WriteLine("Program is exiting");
                    break;
            }
        }

        public static void ForViewingDeal()
        {
            //to be implemented
            Console.Write("INPUT: ");
            string UserChoice = Console.ReadLine().ToUpper();

            switch (UserChoice)
            {
                case "1":
                    Deal DisplayFirstDeal = new Deal();
                    DisplayFirstDeal.FirstDeal();
                    break;
                default:
                    Deal DealOptions = new Deal();
                    ListOfDeals();
                    ForViewingDeal();
                    Console.WriteLine("Input: ");
                    UserChoice = Console.ReadLine().ToUpper();
                    break;
            }
        }

        public static void ForCreatingDeal()
        {
            // to be implmented
            Create CreateDeal = new Create();
            AddDeal();
        }

        public static void ForUpdating()
        {
            // to be implemented
            Console.WriteLine("To update an existing Lead, type 'U'");

        }

        public static void InputFromUser()
        {
            Console.WriteLine("INPUT: ");
            string UserInput = Console.ReadLine().ToUpper();
        }

        public static void AddLead()
        {
            Create CreateLead = new Create();

            Console.WriteLine("Please answer the following questions!");

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


            var AddLead = SqlData.InsertLead(CreateLead.CompanyName, CreateLead.FirstName, CreateLead.LastName, CreateLead.Position,
                CreateLead.EmailAdd, CreateLead.MobileNum, CreateLead.PhoneNum, CreateLead.WebsiteLink, CreateLead.LeadSource, CreateLead.LeadStatus,
                CreateLead.Industry, CreateLead.Employees, CreateLead.AnnualRevenue, CreateLead.Rating, CreateLead.SkypeID);

            //Console.WriteLine("\nCompany Name:  " + CreateLead.CompanyName);
            //Console.WriteLine("First Name:  " + CreateLead.FirstName);
            //Console.WriteLine("Last Name:  " + CreateLead.LastName);
            //Console.WriteLine("Position:  " + CreateLead.Position);
            //Console.WriteLine("E-mail Address:  " + CreateLead.EmailAdd);
            //Console.WriteLine("Mobile Number:  " + CreateLead.MobileNum);
            //Console.WriteLine("Telephone Number:  " + CreateLead.PhoneNum);
            //Console.WriteLine("Website Link:  " + CreateLead.WebsiteLink);
            //Console.WriteLine("Lead Source:  " + CreateLead.LeadSource);
            //Console.WriteLine("Lead Status:  " + CreateLead.LeadStatus);
            //Console.WriteLine("Industry:  " + CreateLead.Industry);
            //Console.WriteLine("Number Of Employees:  " + CreateLead.Employees);
            //Console.WriteLine("Annual Revenue:  P" + CreateLead.AnnualRevenue);
            //Console.WriteLine("Rating:  " + CreateLead.Rating);
            //Console.WriteLine("Skype Id:  " + CreateLead.SkypeID);

            //CreateLead.AddALead();

            //DisplayNewLead();

        }

        static void ValidateCompanyName()
        {
            SqlData.ShowLead();
            Console.WriteLine("Please enter the Lead's Company Name: ");
            var companyName = Console.ReadLine();

            var IfCompanyNameExist = SqlData.CompanyNameValidation(companyName);

            if (IfCompanyNameExist.Equals("True"))
            {
                SqlData.ConvertLead();
                SqlData.ShowContact();
            }
            else
            {
                Console.WriteLine("Company Name doesn't exist");
            }
        }

        public static void AddContact()
        {
            Create CreateContact = new Create();

            Console.WriteLine("Lead Source: ");
            CreateContact.LeadSource = Console.ReadLine();

            Console.WriteLine("First Name: ");
            CreateContact.FirstName = Console.ReadLine();

            Console.WriteLine("Last Name: ");
            CreateContact.LastName = Console.ReadLine();

            Console.WriteLine("Account Name: ");
            CreateContact.AccountName = Console.ReadLine();

            Console.WriteLine("Position: ");
            CreateContact.Position = Console.ReadLine();

            Console.WriteLine("Email Address: ");
            CreateContact.EmailAdd = Console.ReadLine();

            Console.WriteLine("Department: ");
            CreateContact.Department = Console.ReadLine();

            Console.WriteLine("Mobile Number: ");
            CreateContact.MobileNum = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine("Phone Number: ");
            CreateContact.PhoneNum = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine("Birth Date: ");
            CreateContact.BirthDate = Console.ReadLine();

            Console.WriteLine("Assistant Name: ");
            CreateContact.Assistant = Console.ReadLine();

            Console.WriteLine("Asssitant Phone Number: ");
            CreateContact.AssistantPhone = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine("Skype ID: ");
            CreateContact.SkypeID = Console.ReadLine();

            var AddContact = SqlData.InsertContact(CreateContact.LeadSource, CreateContact.FirstName, CreateContact.LastName, CreateContact.Position,
               CreateContact.EmailAdd, CreateContact.Department, CreateContact.MobileNum, CreateContact.PhoneNum, CreateContact.BirthDate,  CreateContact.Assistant,
               CreateContact.AssistantPhone, CreateContact.SkypeID);


            //Console.WriteLine("\nCompany Name:  " + CreateContact.CompanyName);
            //Console.WriteLine("First Name:  " + CreateContact.FirstName);
            //Console.WriteLine("Last Name:  " + CreateContact.LastName);
            //Console.WriteLine("Position:  " + CreateContact.Position);
            //Console.WriteLine("E-mail Address:  " + CreateContact.EmailAdd);
            //Console.WriteLine("Mobile Number:  " + CreateContact.MobileNum);
            //Console.WriteLine("Phone Number:  " + CreateContact.PhoneNum);
            //Console.WriteLine("Website Link:  " + CreateContact.WebsiteLink);
            //Console.WriteLine("Lead Source:  " + CreateContact.LeadSource);
            //Console.WriteLine("Lead Status:  " + CreateContact.LeadStatus);
            //Console.WriteLine("Industry:  " + CreateContact.Industry);
            //Console.WriteLine("Number Of Employees:  " + CreateContact.Employees);
            //Console.WriteLine("Annual Revenue:  P" + CreateContact.AnnualRevenue);
            //Console.WriteLine("Rating:  " + CreateContact.Rating);
            //Console.WriteLine("Skype Id:  " + CreateContact.SkypeID);

            //CreateContact.AddAContact();
        }

        public static void AddDeal()
        {
            //to be implemented
            DealInformation NewDeal = new DealInformation();
            Create CreateDeal = new Create();

            Console.WriteLine("Deal Name: ");
            NewDeal.DealName = Console.ReadLine();

            Console.WriteLine("Closing Date in YYYY-MM-DD format: ");
            NewDeal.ClosingDate = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Account Name: ");
            NewDeal.AccountName = Console.ReadLine();

            Console.WriteLine("Probability: ");
            NewDeal.Probability = int.Parse(Console.ReadLine());

            Console.WriteLine("Expected Revenue: ");
            NewDeal.ExpectedRevenue = int.Parse(Console.ReadLine());

            Console.WriteLine("Lead Source: ");
            NewDeal.LeadSource = Console.ReadLine();

            Console.WriteLine("Contact Name: ");
            NewDeal.ContactName = Console.ReadLine();

            Console.WriteLine("Deal Description: ");
            NewDeal.DealDescription = Console.ReadLine();

            Console.WriteLine("Deal Name:        " + NewDeal.DealName);
            Console.WriteLine("Closing Date:     " + NewDeal.ClosingDate);
            Console.WriteLine("Account Name:     " + NewDeal.AccountName);
            Console.WriteLine("Probability:      " + NewDeal.Probability);
            Console.WriteLine("Expected Revenue: " + NewDeal.ExpectedRevenue);
            Console.WriteLine("Lead Source:      " + NewDeal.LeadSource);
            Console.WriteLine("Contact Name:     " + NewDeal.ContactName);
            Console.WriteLine("Deal Description: " + NewDeal.DealDescription);

            InMemory memory = new InMemory();

            memory._createDeal.Add(new DealInformation(NewDeal.DealName));

            Console.WriteLine("\nLIST OF DEALS:");

            foreach (DealInformation item in memory._createDeal)
            {
                Console.WriteLine(item.DealName);
            }
        }

        public static void ListOfDeals()
        {
            //in memory insert of deal
            var DealOptions = new List<string>();
            DealOptions.Add("To view Acer Deal, type '1'");

            foreach (var option in DealOptions)
            {
                Console.WriteLine(option);
            }
        }

        public static void ViewingDealOptions()
        {
            Console.WriteLine("To view existing Deals type 'V'");
            Console.WriteLine("To create a new Deal type 'C'");
            Console.Write("INPUT: ");

        }

        public static void ViewingLeadOptions()
        {
            Console.WriteLine("To view existing Leads type 'V'");
            Console.WriteLine("To create a new Lead type 'C'");
            Console.WriteLine("To convert a Lead type 'CV'\n");
            Console.Write("INPUT: ");

        }

        public static void ListOfLeadNames()
        {
            //to be implemented
            var ContactOptions = new List<string>();
            ContactOptions.Add("To view Ms. Yoon Contact, type '1'");
            ContactOptions.Add("To view Ms. Vogue Contact, type '2'");

            foreach (var option in ContactOptions)
            {
                Console.WriteLine(option);

            }
        }

        public static void LeadNames()
        {
            //to be implemented
            var ContactOptions = new List<string>();
            ContactOptions.Add("\nTo convert Ms. Dana Yoon Contact, type 'Dana Yoon'");
            ContactOptions.Add("To convert Ms. Vela Vogue Contact, type 'Vela Vogue'");

            foreach (var option in ContactOptions)
            {
                Console.WriteLine(option);
            }
        }

        public static void ListOfContactNames()
        {
            //to be implemented
            var ContactOptions = new List<string>();
            ContactOptions.Add("To view Ms. Wang Contact, type '1'");
            ContactOptions.Add("To view Mr. Osteen Contact, type '2'");

            foreach (var option in ContactOptions)
            {
                Console.WriteLine(option);

            }
        }

        public static void ViewingContactsOption()
        {
            Console.WriteLine("To view existing Contacts type 'V'");
            Console.WriteLine("To create a new Contact type 'C'\n");
            Console.Write("INPUT: \n");

        }
    }
}
    






