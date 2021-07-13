using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Test.ExtController.Controllers
{
    [Export(typeof(IHttpController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Web.Http.RoutePrefix("api/values3")]
    public class ValuesExtController : ApiController
    {

        // GET api/values2
        public IEnumerable<string> Get()
        {
            return new string[] { "valueExt1", "valueExt2" };
        }

        // GET api/values2/5
        public string Get(int id)
        {
            return "valueExt";
        }

        // POST api/values2
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values2/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values2/5
        public void Delete(int id)
        {
        }
    }
}
