using System;
using System.Configuration;
using System.Web.Mvc;
using System.Data.SqlClient;
using BCrypt.Net;
using System.Web.Razor.Text;

namespace UserAuthApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly string conStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        public ActionResult Signup() => View();

        [HttpPost]
        public ActionResult Signup(string username, string email, string password, string confirmPassword)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                ViewBag.Error = "All field are required";
                return View();
            }
            if (password != confirmPassword)
            {
                ViewBag.Error = "Paasword does not match";
                return View();
            }
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select Count(*) from Users where Username = @Username or Email = @Email", con);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Email", email);
                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    ViewBag.Error = "Username or Email already exists";
                    return View();
                }
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
                SqlCommand cmd1 = new SqlCommand("insert into Users(Username, Email, Password) values (@Username, @Email, @Password)", con);
                cmd1.Parameters.AddWithValue("@Username", username);
                cmd1.Parameters.AddWithValue("@Email", email);
                cmd1.Parameters.AddWithValue("@Password", hashedPassword);
                cmd1.ExecuteNonQuery();
            }
            return RedirectToAction("Login");
        }
        public ActionResult Login() => View();

        [HttpPost]
        public ActionResult Login(string identifier, string password)
        {
            if (string.IsNullOrEmpty(identifier) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "All fields are required";
                return View();
            }
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from users where username = @Identifier or email = @Identifier", con);
                cmd.Parameters.AddWithValue("@Identifier", identifier);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string hashedPassword = dr["password"].ToString();
                    if (BCrypt.Net.BCrypt.Verify(password, hashedPassword))
                    {
                        Session["username"] = dr["username"].ToString();
                        return RedirectToAction("Dashboard");
                    }
                }
            }
            ViewBag.Error = "Invalid username/email or password";
            return View();
        }
        public ActionResult Dashboard()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            ViewBag.User = Session["username"];
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}