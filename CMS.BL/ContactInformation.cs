using System;


namespace CMS.BL
{
    public class ContactInformation
    {
        //private string _firstName;

        public Owner LeadOwner { get; set; }
        public Owner ContactOwner { get; set; }
        public string ViewLead { get; set; }
        public string CompanyName { get; set; }
        public string AccountName { get; set; }
        public PersonHonorifics Honorifics { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string EmailAdd { get; set; }
        public long MobileNum { get; set; }
        public long PhoneNum { get; set; }
        public string WebsiteLink { get; set; }
        public string LeadSource { get; set; }
        public string LeadStatus { get; set; }
        public string Industry { get; set; }
        public int Employees { get; set; }
        public decimal AnnualRevenue { get; set; }
        public string SkypeID { get; set; }
        public int Rating { get; set; }
        public string Department { get; set; }
        public string BirthDate { get; set; }
        public string Assistant { get; set; }
        public long AssistantPhone { get; set; }
        public string FullName { get; set; }

        public ContactInformation(string FirstName, string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }

        public ContactInformation()
        {

        }

        //input validation to be implemented
        //public string FirstName
        //{
        //get
        //{
        //return _firstName; //string.IsNullOrEmpty(_firstName) ? "Name can't be empty! Please input your name" : _firstName;
        //return string.IsNullOrEmpty(_firstName) ? _firstName : "Name can't be empty! Please input your name";
        //}
        //set
        //{

        //while (_firstName != value)
        //{
        //    Console.WriteLine("Name can't be empty! Please input your name");
        //    _firstName = Console.ReadLine();

        //}

        //Console.WriteLine("First Name: " + _firstName);
        //if (string.IsNullOrEmpty(_firstName))
        //{
        //    Console.WriteLine("Name can't be empty! Please input your name");
        //    _firstName = Console.ReadLine();


        //    if (_firstName != value)
        //    {
        //        Console.WriteLine("First Name: " + _firstName);
        //    }

        //}
        //else
        //{

        //    Console.WriteLine(_firstName);
        //}




    }
}
