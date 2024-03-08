using _8MarzoTest.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace _8MarzoTest.Controllers
{
    public class BackendController : Controller
    {
        // GET: Backend
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

        public ActionResult RicercaPrenotazioneForm()
        {
            return View("RicercaPrenotazioneView");
        }

        [HttpGet]
        public JsonResult RicercaPrenotazione()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
            List<Prenotazione> lista = new List<Prenotazione>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT IdPrenotazione, Prenotazione.IdCliente, IdCamera, DataPrenotazione, Anno, Dal, Al, Caparra, Tariffa, PensioneCompleta, MezzaPensione, Pernottamento 
                                     FROM Prenotazione
                                     INNER JOIN Cliente ON Cliente.IdCliente = Prenotazione.IdCliente
                                     WHERE Cliente.CF = 'CHKBYJ00L25Z222B'";
                    //non sono riuscito a passare il parametro CF

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        
                       
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Prenotazione prenotazione = new Prenotazione();
                            prenotazione.IdPrenotazione = reader.GetInt32(0);
                            prenotazione.IdCliente = reader.GetInt32(1);
                            prenotazione.IdCamera = reader.GetInt32(2);
                            prenotazione.DataPrenotazione = reader.GetDateTime(3);
                            prenotazione.Anno = reader.GetInt32(4);
                            prenotazione.Dal = reader.GetDateTime(5);
                            prenotazione.Al = reader.GetDateTime(6);
                            prenotazione.Caparra = (double)reader.GetDecimal(7);
                            prenotazione.Tariffa = (double)reader.GetDecimal(8);
                            prenotazione.PensioneCompleta = reader.GetBoolean(9);
                            prenotazione.MezzaPensione = reader.GetBoolean(10);
                            prenotazione.Pernottamento = reader.GetBoolean(11);
                            lista.Add(prenotazione);
                            
                        }
                    }
                    return Json(lista, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult RicercaPrenotazioneView()
        {
            return View();
        }

        [HttpGet]
        public JsonResult PrenotazioniPensione()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
            
            try
            {
                int totale = 0;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT COUNT(*) As TotalePrenotazioni FROM Prenotazione WHERE PensioneCompleta = 'True'";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            totale = reader.GetInt32(0);
                            System.Diagnostics.Debug.WriteLine(totale);
                            
                        }
                    }
 
                }
                return Json(totale, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult PrenotazioniPensioneView()
        {
            var data = PrenotazioniPensione();

            return View(data.Data);
        }
    }
}