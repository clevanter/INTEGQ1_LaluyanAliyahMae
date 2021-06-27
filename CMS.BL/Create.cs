using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BL
{
    public class Create : ContactInformation
    {
        InMemory memory = new InMemory();
        DealInformation NewDeal = new DealInformation(); 

        //in memory process of inserting new lead, contact, deal
        public void AddALead()
        {
            
            Console.WriteLine("\nLIST OF LEADS:");

            memory._createLead.Add(new ContactInformation(FirstName, LastName));

            //return "List of Leads";
            //Console.WriteLine("\nLIST OF LEADS:");

            foreach (ContactInformation item in memory._createLead)
            {
                Console.WriteLine(item.FirstName, item.LastName);
            }
        }

        public void AddAContact()
        {

            memory._createContact.Add(new ContactInformation(FirstName, LastName));

            Console.WriteLine("\nLIST OF CONTACTS:");

            foreach (ContactInformation item in memory._createContact)
            {
                Console.WriteLine(item.FirstName, item.LastName);
            }
        }

        public void AddADeal()
        {

            memory._createDeal.Add(new DealInformation(NewDeal.DealName));

            Console.WriteLine("\nLIST OF DEALS:");

            foreach (DealInformation item in memory._createDeal)
            {
                Console.WriteLine(item.DealName);
            }
        }
    }
}
