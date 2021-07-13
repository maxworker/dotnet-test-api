using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Web.Http.Controllers;

namespace Test.Api
{
    public class Program
    {
        private const string PluginsCatalog = "Plugins";

        public static CompositionContainer Container { get; private set; }

        public static void Main(string[] args)
        {
            var program = new Program();

            var catalog = new DirectoryCatalog(PluginsCatalog);
            using (var container = new CompositionContainer(catalog))
            {
                container.ComposeParts(program);
            }
            
            using (Microsoft.Owin.Hosting.WebApp.Start<Startup>("http://localhost:8000"))
            {
                Console.WriteLine("Server is running on http://localhost:8000 ...");
                Console.ReadLine();
            }
        }

        [ImportMany(typeof(IHttpController))]
        private IEnumerable<IHttpController> Controllers { get; set; }
    }
}
