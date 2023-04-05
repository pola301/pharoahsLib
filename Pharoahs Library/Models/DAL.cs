using System.Data;
using System.Data.SqlClient;

namespace Pharoahs_Library.Models
{
    public class DAL
    {
        public Response register (Users users,SqlConnection connection)
        {
            Response response = new Response ();
            SqlCommand cmd = new SqlCommand ("sp_register", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", users.UserName);
            cmd.Parameters.AddWithValue("@Password", users.Password);
            cmd.Parameters.AddWithValue("@PhoneNumber", users.PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", users.Email);
            cmd.Parameters.AddWithValue("@Type", "users");
            cmd.Parameters.AddWithValue("@Status", users.Status);
            cmd.Parameters.AddWithValue("@Fund", 0);
            cmd.Parameters.AddWithValue("@Type", "Pending");
            connection.Open ();
            int i = cmd.ExecuteNonQuery ();
            connection.Close ();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.Message = "User registered successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.Message = "User registeration failed";
            }

            return response;
        }
        
        public Response Login (Users users, SqlConnection connection)
        {
            SqlDataAdapter da = new SqlDataAdapter ("sp_login",connection);
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue ("@Email", users.Email);
            da.SelectCommand.Parameters.AddWithValue("@Password", users.Password );
            DataTable dt = new DataTable ();
            da.Fill (dt);
            Response response = new Response ();
            Users users1 = new Users ();

            if (dt.Rows.Count > 0) { 
                users.UserID = Convert.ToInt32(dt.Rows[0]["ID"]);
                users.UserName = Convert.ToString(dt.Rows[0]["UserName"]);
                users.Email = Convert.ToString(dt.Rows[0]["Email"]);
                users.Type = Convert.ToString(dt.Rows[0]["Type"]);
                response.StatusCode = 200;
                response.Message = "User is valid";
                response.user = users;
            }
            else { 
                response.StatusCode=100;
                response.Message = "User is invalid";
                response.user = null;
            }
            return response;
        }

        public Response viewUser(Users users, SqlConnection connection)
        {
            SqlDataAdapter da = new SqlDataAdapter ("viewUser",connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@UserID", users.UserID);
            DataTable dt = new DataTable ();
            da.Fill (dt);
            Response response = new Response ();
            Users users1 = new Users();
            if (dt.Rows.Count > 0) {
                users.UserID = Convert.ToInt32(dt.Rows[0]["ID"]);
                users.UserName = Convert.ToString(dt.Rows[0]["UserName"]);
                users.Email = Convert.ToString(dt.Rows[0]["Email"]);
                users.Type = Convert.ToString(dt.Rows[0]["Type"]);
                users.Fund = Convert.ToDecimal(dt.Rows[0]["Fund"]);
                users.Createdon = Convert.ToDateTime(dt.Rows[0]["Createdon"]);
                users.Password = Convert.ToString(dt.Rows[0]["Password"]);
                response.StatusCode = 200;
                response.Message = "User Exists";
        }
            else { 
                response.StatusCode=100;
                response.Message = "User is not found";
                response.user = users;
            }
            return response;
        }

        public Response updateProfile(Users users,SqlConnection connection)
        {
            Response response = new Response ();

            SqlCommand cmd = new SqlCommand ("sp_updateProfile", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", users.UserName);
            cmd.Parameters.AddWithValue("@Password", users.Password);
            
            connection.Open ();
            int i = cmd.ExecuteNonQuery ();
            connection.Close ();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.Message = "Updated Successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.Message = "Some error occured";
            }

            return response;
        }

        public Response addToCart(Cart cart,SqlConnection connection)
        {
            Response response= new Response ();
            SqlCommand cmd = new SqlCommand("sp_addToCart", connection);
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", cart.UserID);
            cmd.Parameters.AddWithValue("@BookPrice", cart.BookPrice);
            cmd.Parameters.AddWithValue("@Discount", cart.Discount);
            cmd.Parameters.AddWithValue("@BookID", cart.BookID);
            cmd.Parameters.AddWithValue("@TotalPrice", cart.TotalPrice);
            connection.Open ();
            int i = cmd.ExecuteNonQuery ();
            connection.Close ();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.Message = "Book Added successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.Message = "Book could not be added";
            }
            return response;
        }

        public Response placeOrder(Users user,SqlConnection connection)
        {
            Response response= new Response ();
            SqlCommand cmd = new SqlCommand("sp_placeOrder", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID",user.UserID);
            connection.Open ();
            int i = cmd.ExecuteNonQuery ();
            connection.Close ();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.Message = "order placed Successfully";
            }
            else
            {
                response.StatusCode=100;
                response.Message = "order has not been placed due to an error";
            }

            return response;
        }

        public Response userOrderList (Users user,SqlConnection connection)
        {
            Response response= new Response ();
            List<Order> listOrders = new List<Order> ();
            SqlDataAdapter da = new SqlDataAdapter("sp_userOrderList", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Type", user.Type);
            da.SelectCommand.Parameters.AddWithValue("@UserID", user.UserID);
            DataTable dt = new DataTable ();
            da.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Order o = new Order();
                    o.OrderID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    o.OrderNo = Convert.ToString(dt.Rows[i]["OrderNo"]);
                    o.OrderTotal = Convert.ToDecimal(dt.Rows[i]["OrderTotal"]);
                    o.OrderStatus = Convert.ToString(dt.Rows[i]["OrderStatus"]);
                    listOrders.Add(o);
                }
                if(listOrders.Count > 0)
                {
                    response.StatusCode = 200;
                    response.Message = "Order details fetched";
                    response.order = listOrders;
                }
                else
                {
                    response.StatusCode = 100;
                    response.Message = "Order details not available";
                    response.order = null;
                }

            }
            else
            {
                response.StatusCode = 100;
                response.Message = "Order details not available";
                response.order = null;
            }
            return response;
        }

        public Response AddUpdateBooks(Books books, SqlConnection connection)
        {
            Response response = new Response();

            SqlCommand cmd = new SqlCommand("sp_addUpdateBooks", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BookName", books.BookName);
            cmd.Parameters.AddWithValue("@BookSize", books.BookSize);
            cmd.Parameters.AddWithValue("@BookPrice", books.BookPrice);
            cmd.Parameters.AddWithValue("@Discount", books.Discount);
            cmd.Parameters.AddWithValue("@ImgURL", books.ImgURL);
            cmd.Parameters.AddWithValue("@BookStatus", books.Status);
            cmd.Parameters.AddWithValue("@Description", books.Description);
            cmd.Parameters.AddWithValue("@Type", books.Type);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.Message = "Book added Successfully";
            }
            else
            {
                response.StatusCode=100;
                response.Message = "error inserting book";
            }

            return response;
        }

        public Response userList(SqlConnection connection)
        {
            Response response = new Response();
            List<Users> listUsers = new List<Users>();
            SqlDataAdapter da = new SqlDataAdapter("sp_userList", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Users u = new Users();
                    u.UserID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    u.UserName = Convert.ToString(dt.Rows[i]["UserName"]);
                    u.PhoneNumber = Convert.ToString(dt.Rows[i]["phoneNumber"]);
                    u.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    u.Status = Convert.ToInt32(dt.Rows[i]["Status"]);
                    u.Fund = Convert.ToDecimal(dt.Rows[i]["Fund"]);
                    u.Createdon = Convert.ToDateTime(dt.Rows[i]["Createdon"]);
                    listUsers.Add(u);
                }
                if (listUsers.Count > 0)
                {
                    response.StatusCode = 200;
                    response.Message = "Users details fetched";
                    response.listUsers = listUsers;
                }
                else
                {
                    response.StatusCode = 100;
                    response.Message = "Users details not available";
                    response.listUsers = null;
                }

            }
            else
            {
                response.StatusCode = 100;
                response.Message = "Order details not available";
                response.order = null;
            }
            return response;
        }
    }
}
