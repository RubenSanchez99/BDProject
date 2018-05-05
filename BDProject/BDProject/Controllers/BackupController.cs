using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BDProject.Controllers
{
    public class BackupController : Controller
    {
        // GET: Backup
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Backup()
        {
            try
            {
                string backupDIR = "C:\\BackupDB";
                if (!System.IO.Directory.Exists(backupDIR))
                {
                    System.IO.Directory.CreateDirectory(backupDIR);
                }
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Server=localhost\SQLEXPRESS;database=Proyecto;Integrated Security=true;";
                SqlCommand sqlcmd = new SqlCommand("ProyectoBackup",con);
                con.Open();
                sqlcmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception ex)
            {

            }
            return View();
        }
    }
}