using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BDProject.Controllers
{
    public class RestoreController : Controller
    {
        // GET: Restore
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Restore()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Server=localhost\SQLEXPRESS;database=master;Integrated Security=true;";
                SqlCommand sqlcmd = new SqlCommand("restoreProyecto", con);
                con.Open();
                sqlcmd.ExecuteNonQuery();
                con.Close();
            }catch(Exception ex)
            {

            }
            return View();
        }
    }
}