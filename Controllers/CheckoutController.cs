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
    public class CheckoutController : Controller
    {
        // GET: Checkout
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet] 
        public ActionResult Checkout(int IdPrenotazione)
        {

         

            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
            //creo una lista di oggetti per inserire dentro altre liste
            CheckoutView lists = new CheckoutView();
            lists.Checkout1s = new List<Checkout1>();
            lists.Checkout2s = new List<ServiziAggiuntivi>();
            lists.Totale = new List<double>();

            //creo una lista di oggetti per inserire i dati 

            try
            {
                //per il primo punto
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT Cliente.CF, Camere.NumeroCamera, Prenotazione.Dal, Prenotazione.Al, Prenotazione.Tariffa
                                 FROM Prenotazione
                                 INNER JOIN Camere ON Camere.IdCamera = Prenotazione.IdCamera
                                 INNER JOIN Cliente ON Cliente.IdCliente = Prenotazione.IdCliente
                                 WHERE Prenotazione.IdPrenotazione = @IdPrenotazione;";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdPrenotazione", IdPrenotazione);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<Checkout1> checkout1s = new List<Checkout1>();
                            while (reader.Read())
                            {
                                Checkout1 checkout1 = new Checkout1();
                                checkout1.CF = reader.IsDBNull(0) ? null : reader.GetString(0);
                                checkout1.NumeroCamera = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                                checkout1.Dal = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                                checkout1.Al = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                                checkout1.Tariffa = reader.IsDBNull(4) ? 0 : (double)reader.GetDecimal(4);
                                checkout1s.Add(checkout1);
                            }
                            lists.Checkout1s.AddRange(checkout1s);
                        }


                    }
                }

                //per il secondo punto
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT * FROM ServiziAggiuntivi2 
                                     WHERE ServiziAggiuntivi2.IdPrenotazione = @IdPrenotazione;";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdPrenotazione", IdPrenotazione);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<ServiziAggiuntivi> checkout2s = new List<ServiziAggiuntivi>();
                            while (reader.Read())
                            {
                                ServiziAggiuntivi checkout2 = new ServiziAggiuntivi();
                                checkout2.IdServizio = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                                checkout2.IdPrenotazione = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                                checkout2.ColazioneInCamera = reader.IsDBNull(2) ? false : reader.GetBoolean(2);
                                checkout2.ColazioneInCameraPrezzo = reader.IsDBNull(3) ? 0 : (decimal)reader.GetDecimal(3);
                                checkout2.ColazioneInCameraData = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4);
                                checkout2.ColazioneInCameraQuantita = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);
                                checkout2.MiniBar = reader.IsDBNull(6) ? false : reader.GetBoolean(6);
                                checkout2.MiniBarPrezzo = reader.IsDBNull(7) ? 0 : (decimal)reader.GetDecimal(7);
                                checkout2.MiniBarData = reader.IsDBNull(8) ? DateTime.MinValue : reader.GetDateTime(8);
                                checkout2.MiniBarQuantita = reader.IsDBNull(9) ? 0 : reader.GetInt32(9);
                                checkout2.Internet = reader.IsDBNull(10) ? false : reader.GetBoolean(10);
                                checkout2.InternetPrezzo = reader.IsDBNull(11) ? 0 : (decimal)reader.GetDecimal(11);
                                checkout2.InternetData = reader.IsDBNull(12) ? DateTime.MinValue : reader.GetDateTime(12);
                                checkout2.InternetQuantita = reader.IsDBNull(13) ? 0 : reader.GetInt32(13);
                                checkout2.LettoExtra = reader.IsDBNull(14) ? false : reader.GetBoolean(14);
                                checkout2.LettoExtraPrezzo = reader.IsDBNull(15) ? 0 : (decimal)reader.GetDecimal(15);
                                checkout2.LettoExtraData = reader.IsDBNull(16) ? DateTime.MinValue : reader.GetDateTime(16);
                                checkout2.LettoExtraQuantita = reader.IsDBNull(17) ? 0 : reader.GetInt32(17);
                                checkout2.Culla = reader.IsDBNull(18) ? false : reader.GetBoolean(18);
                                checkout2.CullaPrezzo = reader.IsDBNull(19) ? 0 : (decimal)reader.GetDecimal(19);
                                checkout2.CullaData = reader.IsDBNull(20) ? DateTime.MinValue : reader.GetDateTime(20);
                                checkout2.CullaQuantita = reader.IsDBNull(21) ? 0 : reader.GetInt32(21);

                                checkout2s.Add(checkout2);
                            }

                            lists.Checkout2s.AddRange(checkout2s);
                        }
                    }
                }

                //per il terzo punto
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT Prenotazione.Tariffa, Prenotazione.Caparra, 
                                    ServiziAggiuntivi2.ColazioneInCameraPrezzo,ServiziAggiuntivi2.ColazioneInCameraQuantita, 
                                    ServiziAggiuntivi2.MinibarPrezzo, ServiziAggiuntivi2.MinibarQuantita,
                                    ServiziAggiuntivi2.InternetPrezzo, ServiziAggiuntivi2.InternetQuantita,
                                    ServiziAggiuntivi2.LettoExtraPrezzo, ServiziAggiuntivi2.LettoExtraQuantita,
                                    ServiziAggiuntivi2.CullaPrezzo, ServiziAggiuntivi2.CullaQuantita
                                    FROM Prenotazione
                                    INNER JOIN ServiziAggiuntivi2 ON ServiziAggiuntivi2.IdPrenotazione = Prenotazione.IdPrenotazione
                                    WHERE Prenotazione.IdPrenotazione = @IdPrenotazione;";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdPrenotazione", IdPrenotazione);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<double> Totale = new List<double>();
                            while (reader.Read())
                            {
                                Checkout3 checkout3 = new Checkout3();
                                checkout3.Tariffa = (double)reader.GetDecimal(0);
                                checkout3.Caparra = (double)reader.GetDecimal(1);
                                checkout3.ColazioneInCameraPrezzo = (double)reader.GetDecimal(2);
                                checkout3.ColazioneInCameraQuantita = reader.GetInt32(3);
                                checkout3.MinibarPrezzo = (double)reader.GetDecimal(4);
                                checkout3.MinibarQuantita = reader.GetInt32(5);
                                checkout3.InternetPrezzo = (double)reader.GetDecimal(6);
                                checkout3.InternetQuantita = reader.GetInt32(7);
                                checkout3.LettoExtraPrezzo = (double)reader.GetDecimal(8);
                                checkout3.LettoExtraQuantita = reader.GetInt32(9);
                                checkout3.CullaPrezzo = (double)reader.GetDecimal(10);
                                checkout3.CullaQuantita = reader.GetInt32(11);


                                double totale = checkout3.Tariffa - checkout3.Caparra + (checkout3.ColazioneInCameraPrezzo * checkout3.ColazioneInCameraQuantita) + (checkout3.MinibarPrezzo * checkout3.MinibarQuantita) + (checkout3.InternetPrezzo * checkout3.InternetQuantita) + (checkout3.LettoExtraPrezzo * checkout3.LettoExtraQuantita) + (checkout3.CullaPrezzo * checkout3.CullaQuantita);
                                Totale.Add(totale);
                            }
                            lists.Totale.AddRange(Totale);
                        }

                    }

                }
                


                return View(lists);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                throw ex;
            }
            
            
        }


            
        
    }
}