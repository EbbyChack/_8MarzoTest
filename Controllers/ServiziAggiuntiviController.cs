using _8MarzoTest.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _8MarzoTest.Controllers
{
    public class ServiziAggiuntiviController : Controller
    {
        // GET: ServiziAggiuntivi
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
        public ActionResult InserisciServiziAggiuntivi(ServiziAggiuntivi servizi)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO ServiziAggiuntivi2 
                                    (IdPrenotazione, 
                                     ColazioneInCamera, ColazioneInCameraPrezzo, ColazioneInCameraData, ColazioneInCameraQuantita,
                                     Minibar, MinibarPrezzo, MinibarData, MinibarQuantita,
                                     Internet, InternetPrezzo, InternetData, InternetQuantita,
                                     LettoExtra, LettoExtraPrezzo, LettoExtraData, LettoExtraQuantita,
                                     Culla, CullaPrezzo, CullaData, CullaQuantita)
                                    VALUES
                                    (@IdPrenotazione, 
                                     @ColazioneInCamera, @ColazioneInCameraPrezzo, @ColazioneInCameraData, @ColazioneInCameraQuantita,
                                     @Minibar, @MinibarPrezzo, @MinibarData, @MinibarQuantita,
                                     @Internet, @InternetPrezzo, @InternetData, @InternetQuantita,
                                     @LettoExtra, @LettoExtraPrezzo, @LettoExtraData, @LettoExtraQuantita,
                                     @Culla, @CullaPrezzo, @CullaData, @CullaQuantita)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdPrenotazione", servizi.IdPrenotazione);
                        cmd.Parameters.AddWithValue("@ColazioneInCamera", servizi.ColazioneInCamera);
                        cmd.Parameters.AddWithValue("@ColazioneInCameraPrezzo", servizi.ColazioneInCameraPrezzo);
                        cmd.Parameters.AddWithValue("@ColazioneInCameraData", servizi.ColazioneInCameraData.Date == DateTime.MinValue ? (object)DBNull.Value : servizi.ColazioneInCameraData.Date);
                        cmd.Parameters.AddWithValue("@ColazioneInCameraQuantita", servizi.ColazioneInCameraQuantita);
                        cmd.Parameters.AddWithValue("@Minibar", servizi.MiniBar);
                        cmd.Parameters.AddWithValue("@MinibarPrezzo", servizi.MiniBarPrezzo);
                        cmd.Parameters.AddWithValue("@MinibarData", servizi.MiniBarData.Date == DateTime.MinValue ? (object)DBNull.Value : servizi.ColazioneInCameraData.Date);
                        cmd.Parameters.AddWithValue("@MinibarQuantita", servizi.MiniBarQuantita);
                        cmd.Parameters.AddWithValue("@Internet", servizi.Internet);
                        cmd.Parameters.AddWithValue("@InternetPrezzo", servizi.InternetPrezzo);
                        cmd.Parameters.AddWithValue("@InternetData", servizi.InternetData.Date == DateTime.MinValue ? (object)DBNull.Value : servizi.ColazioneInCameraData.Date);
                        cmd.Parameters.AddWithValue("@InternetQuantita", servizi.InternetQuantita);
                        cmd.Parameters.AddWithValue("@LettoExtra", servizi.LettoExtra);
                        cmd.Parameters.AddWithValue("@LettoExtraPrezzo", servizi.LettoExtraPrezzo);
                        cmd.Parameters.AddWithValue("@LettoExtraData", servizi.LettoExtraData.Date == DateTime.MinValue ? (object)DBNull.Value : servizi.ColazioneInCameraData.Date);
                        cmd.Parameters.AddWithValue("@LettoExtraQuantita", servizi.LettoExtraQuantita);
                        cmd.Parameters.AddWithValue("@Culla", servizi.Culla);
                        cmd.Parameters.AddWithValue("@CullaPrezzo", servizi.CullaPrezzo);
                        cmd.Parameters.AddWithValue("@CullaData", servizi.CullaData.Date == DateTime.MinValue ? (object)DBNull.Value : servizi.ColazioneInCameraData.Date);
                        cmd.Parameters.AddWithValue("@CullaQuantita", servizi.CullaQuantita);

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