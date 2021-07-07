using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (Microsoft.Owin.Hosting.WebApp.Start<Startup>("http://localhost:8000"))
            {
                Console.WriteLine("Server is running on http://localhost:8000 ...");
                Console.ReadLine();
            }
        }
    }
}
