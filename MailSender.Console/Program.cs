using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.Reports;

namespace MailSender.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var report = new Report();

            report.DataField1 = "Value 1";
            report.DataField2 = "Value 2";

            report.CreatePackage("Report.docx");

            Console.ReadLine();
        }
    }
}
