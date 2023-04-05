using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Pharoahs_Library.Models;
using System.Data.SqlClient;

namespace Pharoahs_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        [Route("Registration")]
        public Response register(Users users)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection (_configuration.GetConnectionString("PharoahsLib").ToString());
            DAL dal = new DAL();
            response = dal.register(users, connection);
            return response;
        }
        [HttpPost]
        [Route("Login")]
        public Response Login(Users users)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("PharoahsLib").ToString());
            Response response = new Response();
            response = dal.Login(users, connection);
            return response;
        }
        [HttpPost]
        [Route("viewUser")]
        public Response viewUser(Users users)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("PharoahsLib").ToString());
            Response response = dal.viewUser(users, connection);
            return response;
        }
        [HttpPost]
        [Route("updateUser")]
        public Response updateProfile(Users users)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("PharoahsLib").ToString());
            Response response = dal.updateProfile(users, connection);
            return response;

        }


    }
}
