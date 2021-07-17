using System;
using CMS.DL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BL
{
    public class AutoGenerate
    {
        public void InteractionID(string contactname)
        {
            Random random = new Random();
            int number = random.Next(1000);
            Console.WriteLine(number);
            SqlData.UpdateID(number, contactname);

        }

        public void TaskID(string tasktitle)
        {
            Random random = new Random();
            int number = random.Next(1000);
            Console.WriteLine(number);
            SqlData.UpdateTaskId(number, tasktitle);
        }

        public void ReportID(string reportname)
        {
            Random random = new Random();
            int number = random.Next(1000);
            Console.WriteLine(number);
            SqlData.UpdateReportId(number, reportname);

        }
    }
}
