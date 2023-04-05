using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharoahs_Library.Models;
using System.Data.SqlClient;

namespace Pharoahs_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public BooksController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        [Route("addToCart")]

        public Response addToCart(Cart cart)
        {
            DAL dAL = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("PharoahsLib").ToString());
            Response response = dAL.addToCart(cart, connection);
            return response;
        }
        [HttpPost]
        [Route("placeOrder")]

        public Response placeOrder(Users users)
        {
            DAL dAL = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("PharoahsLib").ToString());
            Response response = dAL.placeOrder(users, connection);
            return response;
        }

        [HttpPost]
        [Route("userOrderList")]

        public Response userOrderList(Users users)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("PharoahsLib").ToString());
            Response response = dal.userOrderList(users, connection);
            return response;
        }
    }
}
