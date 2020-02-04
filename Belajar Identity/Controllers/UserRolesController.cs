using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;

namespace Belajar_Identity.Views.UserRoles
{
    public class UserRolesController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        // GET: UserRoles
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetDataUserRoles()
        {
            var result = con.QueryAsync("EXEC SP_Retrieve_UserRoles");
            return Json(new { data = result}, JsonRequestBehavior)
        }
    }
}