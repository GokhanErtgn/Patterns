using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Report report = new EmployeePerformanceReport(new DesktopFormat());
            report.Display();

            Console.WriteLine();

            Report report2 = new SalesReport(new WebFormat());
            report2.Display();

            Console.ReadLine();
        }
    }

    public interface IReportFormat
    {
        void Generate();
    }

    public class WebFormat : IReportFormat
    {
        public void Generate()
        {
            Console.WriteLine("Rapor Web Formatında oluşturuldu.");
        }
    }

    public class DesktopFormat : IReportFormat
    {
        public void Generate()
        {
            Console.WriteLine("Rapor Desktop Formatında oluşturuldu.");
        }
    }

    public class Report
    {
        public IReportFormat ReportFormat { get; private set; }

        public Report(IReportFormat reportFormat)
        {
            ReportFormat = reportFormat;
        }

        public virtual void Display()
        {
            ReportFormat.Generate();
        }
    }

    public class SalesReport : Report
    {
        public SalesReport(IReportFormat reportFormat) : base(reportFormat)
        {
        }

        public override void Display()
        {
            Console.WriteLine("---Satış Raporu---");
            base.Display();
        }
    }

    public class EmployeePerformanceReport : Report
    {
        public EmployeePerformanceReport(IReportFormat reportFormat) : base(reportFormat)
        {
        }

        public override void Display()
        {
            Console.WriteLine("---Çalışan Performans Raporu---");
            base.Display();
        }
    }
}
