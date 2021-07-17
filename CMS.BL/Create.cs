using CMS.DL;
using System;

namespace CMS.BL
{
    public class Create : ContactInformation
    {

        public void CreateNewLead(string companyname, string firstname, string lastname, string position, string emailadd, long mobilenum,
            long phonenum, string websitelink, string leadsource, string leadstatus, string industry, int employees, decimal annualrevenue,
            int rating, string skypeid)
        {
            SqlData.InsertLead(companyname, firstname, lastname, position, emailadd, mobilenum, phonenum, websitelink, leadsource, leadstatus, industry, 
                employees, annualrevenue, rating, skypeid);
            SqlData.ShowLead(companyname);
        }

        public void CreateNewContact(string accountname, string leadsource, string firstname, string lastname, string position, string emailadd, string department, long mobilenum,
            long phonenum, string birthdate, string assistant, long assistantphone, string skypeid)
        {
            SqlData.InsertContact(accountname, leadsource, firstname, lastname, position, emailadd, department, mobilenum,
             phonenum, birthdate, assistant, assistantphone, skypeid);
            SqlData.ShowContact(accountname);
        }

        public void CreateNewDeal(string dealname, DateTime closingdate, string accountname, int probability, decimal expectedrevenue, string leadsource, string contactname,
            string dealdescription, string status)
        {
            SqlData.InsertDeal(dealname, closingdate, accountname, probability, expectedrevenue, leadsource, contactname,
             dealdescription, status);
            SqlData.ShowDeal(dealname);
        }

        public void CreateNewAccount(string accountname, long accountnum, string industry, int rating, long phonenum, string websitelink, 
            int employees, decimal annualrevenue)
        {
            SqlData.InsertAccount(accountname, accountnum, industry, rating, phonenum, websitelink, employees, annualrevenue);
            SqlData.ShowAccount(accountname);
        }

        public void CreateNewInteraction(string contactname, string type, long usednumber, string usedemail, DateTime durationanddate)
        {
            SqlData.InsertInteraction(contactname, type, usednumber, usedemail, durationanddate);
        }

        public void CreateNewTask(string tasktype, DateTime dateposted, DateTime duedate, string tasktitle, string taskdescription, string taskassigned, 
            string progress)
        {
            SqlData.InsertTask(tasktype, dateposted, duedate, tasktitle, taskdescription, taskassigned, progress);
        }

        public void CreateNewReport(string reportname, string reportdescription, DateTime dateposted, string reportby)
        {
            SqlData.InsertReport(reportname, reportdescription, dateposted, reportby);
        }
    }
}
