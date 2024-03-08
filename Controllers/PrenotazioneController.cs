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
    public class PrenotazioneController : Controller
    {
        // GET: Prenotazione
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
        public ActionResult InserisciPrenotazione(Prenotazione prenotazione)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO Prenotazione (IdCliente, IdCamera, DataPrenotazione, Anno, Dal, Al, Caparra, Tariffa, PensioneCompleta, MezzaPensione, Pernottamento) 
                                     VALUES (@IdCliente, @IdCamera, @DataPrenotazione, @Anno, @Dal, @Al, @Caparra, @Tariffa, @PensioneCompleta, @MezzaPensione, @Pernottamento)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdCliente", prenotazione.IdCliente);
                        cmd.Parameters.AddWithValue("@IdCamera", prenotazione.IdCamera);
                        cmd.Parameters.AddWithValue("@DataPrenotazione", prenotazione.DataPrenotazione);
                        cmd.Parameters.AddWithValue("@Anno", prenotazione.Anno);
                        cmd.Parameters.AddWithValue("@Dal", prenotazione.Dal);
                        cmd.Parameters.AddWithValue("@Al", prenotazione.Al);
                        cmd.Parameters.AddWithValue("@Caparra", prenotazione.Caparra);
                        cmd.Parameters.AddWithValue("@Tariffa", prenotazione.Tariffa);
                        cmd.Parameters.AddWithValue("@PensioneCompleta", prenotazione.PensioneCompleta);
                        cmd.Parameters.AddWithValue("@MezzaPensione", prenotazione.MezzaPensione);
                        cmd.Parameters.AddWithValue("@Pernottamento", prenotazione.Pernottamento);

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