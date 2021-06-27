using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BL
{
    public class Deal : DealInformation
    {
        //test data
        public void FirstDeal()
        {
            DealName = "Collab Project";
            AccountName = "Acer";
            Probability = 50;
            ExpectedRevenue = 1200230;
            LeadSource = "Summit";
            ContactName = "Celine Ramos";
            DealDescription = "Brand collaboration focused concentrated on hardware design.";

            Console.WriteLine("Deal Name:        " + DealName);
            Console.WriteLine("Account Name:     " + AccountName);
            Console.WriteLine("Probability:      " + Probability + "%");
            Console.WriteLine("Expected Revenue: " + ExpectedRevenue);
            Console.WriteLine("Lead Source:      " + LeadSource);
            Console.WriteLine("Contact Name:     " + ContactName);
            Console.WriteLine("Deal Description: " + DealDescription);
        }
        //public void ListOfDeals()
        //{
        //    var DealOptions = new List<string>();
        //    DealOptions.Add("To view Acer Deal, type '1'");

        //    foreach (var option in DealOptions)
        //    {
        //        Console.WriteLine(option);
        //    }
        //}

        //public void ViewingDealOptions()
        //{
        //    Console.WriteLine("To view existing Deals type 'V'");
        //    Console.WriteLine("To create a new Deal type 'C'");
        //    Console.Write("INPUT: ");

        //}
    }
}
