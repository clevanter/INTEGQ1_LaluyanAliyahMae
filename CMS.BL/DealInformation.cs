using System;


namespace CMS.BL
{
    public class DealInformation
    {
        public Owner DealOwner { get; set; }
        public int Amount { get; set; }
        public string DealName { get; set; }
        public DateTime ClosingDate { get; set; }
        public string AccountName { get; set; }
        public string Stage { get; set; }
        public int Probability { get; set; }
        public decimal ExpectedRevenue { get; set; }
        public string LeadSource { get; set; }
        public string ContactName { get; set; }
        public string DealDescription { get; set; }

    
        public DealInformation(string DealName)
        {
            this.DealName = DealName;
        }

        public DealInformation()
        {

        }
    }
}
