using _8MarzoTest.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace _8MarzoTest.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CheckUser(Utente addetti)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT * FROM Utente WHERE Username = @Username AND Password = @Password";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", addetti.Username);
                    cmd.Parameters.AddWithValue("@Password", addetti.Password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            FormsAuthentication.SetAuthCookie(addetti.Username, false);
                            return RedirectToAction("Index", "Backend");
                        }
                        else
                        {
                            Response.Write("Autenticazione non riuscita");
                            return View("Index");
                        }
                    }
                }


            }

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            //ti riporta alla pagina dove ti trovavi
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}