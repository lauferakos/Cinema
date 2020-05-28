using Cinema.DAL;
using Cinema.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IViewerRepository repository;

        public AuthController(IViewerRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("{username}/{password}")]
        public LoginStatus CheckUserPassword(string username, string password)
        {
             return repository.CheckUserPassword(username,password);

        }
    }
}
