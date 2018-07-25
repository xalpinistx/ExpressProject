using ExpressProject.Service;
using ExpressProject.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ExpressProject.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("user")]
    public class UserController : ApiController
    {
        IUserService _userService { get; }

        public UserController()
        {

        }

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [Route("getAll")]
        [HttpGet]
        public IHttpActionResult GetAllUsers()
        {

            var users = _userService.GetUsers();

            if (users != null)
            {
                return Ok(users);
            }

            return NotFound();
        }

        [Route("get")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("Get:test!")
            };
        }

        public HttpResponseMessage Post()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("Post:test!")
            };
        }


        public HttpResponseMessage Put()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("Update:test!")
            };
        }


    }
}
