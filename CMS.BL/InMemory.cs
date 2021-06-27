using System.Collections.Generic;

namespace CMS.BL
{
    public class InMemory 
    {

        public List<ContactInformation> _createLead = new List<ContactInformation>()
            {
                new ContactInformation("Dana", "Yoon"),
                new ContactInformation("Vela", "Vogue")
            };

        public List<ContactInformation> _createContact = new List<ContactInformation>()
            {
                new ContactInformation("Chelsea", "Wang"),
                new ContactInformation("Nathan", "Osteen")
            };

        public List<DealInformation> _createDeal = new List<DealInformation>()
        {
            new DealInformation("Collab Project")
        };

    }
    }

