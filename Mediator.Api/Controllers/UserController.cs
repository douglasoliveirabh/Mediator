using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mediator.Domain.Entities;
using Mediator.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Mediator.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IUserService _service;

        
        public UserController(IUserService service)
        {
            _service = service;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<User> Get()
        {
           return _service.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public User Get(Guid id)
        {
            return _service.GetById(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]User user)
        {
            _service.Add(user);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put([FromBody]User user)
        {
            _service.Update(user);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _service.Remove(id);
        }
    }
}
