using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace TranslateService_WCF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(TranslateService_WCF.TranslateService));
            host.Open();

            Console.WriteLine("Press Any key to stop the service");
            Console.ReadKey();
            host.Close();
        }
    }
}
