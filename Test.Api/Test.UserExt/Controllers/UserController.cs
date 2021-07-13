using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using Test.Core.Interfaces;
using Test.Core.Models;
using Test.UserExt.Repositories;

namespace Test.UserExt.Controllers
{
    [Export(typeof(IHttpController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private IUserRepository _userRepository;

        public UserController()
        {
            _userRepository = new UserRepository(new UserContext());
        }

        [HttpGet]
        public async Task<User> Get(int id)
        {
            return await _userRepository.GetAsync(id);
        }

        [HttpPost]
        public void Post([FromBody] User user)
        {
            _userRepository.Create(user);
        }

        [HttpPut]
        public void Put([FromBody] User user)
        {
            _userRepository.Update(user);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }

        [HttpGet]
        [Route("search/{pattern}")]
        public IEnumerable<User> GetSearch(string pattern)
        {
            return _userRepository.Search(pattern);
        }
    }
}
