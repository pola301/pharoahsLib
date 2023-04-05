using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharoahs_Library.Models;
using System.Data.SqlClient;
using static System.Reflection.Metadata.BlobBuilder;

namespace Pharoahs_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AdminController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("addUpdateBook")]

        public Response AddUpdateBook(Books books)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("PharoahsLib").ToString());
            Response response = dal.AddUpdateBooks(books, connection);
            return response;
        }

        [HttpGet]
        [Route("userList")]

        public Response userList()
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("PharoahsLib").ToString());
            Response response = dal.userList(connection);
            return response;
        }
    }
}
