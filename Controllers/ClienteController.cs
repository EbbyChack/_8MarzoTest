using _8MarzoTest.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _8MarzoTest.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
           
        }

        [HttpPost]
        public ActionResult InserisciCliente(Cliente clienti)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
            try 
            {
               using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO Cliente (CF, Nome, Cognome, Citta, Provincia, Email, Telefono, Cellulare) VALUES (@CF, @Nome, @Cognome, @Citta, @Provincia, @Email, @Telefono, @Cellulare)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CF", clienti.CF);
                        cmd.Parameters.AddWithValue("@Nome", clienti.Nome);
                        cmd.Parameters.AddWithValue("@Cognome", clienti.Cognome);
                        cmd.Parameters.AddWithValue("@Citta", clienti.Citta);
                        cmd.Parameters.AddWithValue("@Provincia", clienti.Provincia);
                        cmd.Parameters.AddWithValue("@Email", clienti.Email);
                        cmd.Parameters.AddWithValue("@Telefono", clienti.Telefono);
                        cmd.Parameters.AddWithValue("@Cellulare", clienti.Cellulare);

                        cmd.ExecuteNonQuery();
                    }
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //cancella info dal form
                ModelState.Clear();
            }
            

        }
    }
}
