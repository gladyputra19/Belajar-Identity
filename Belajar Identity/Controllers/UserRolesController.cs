using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Dapper;
using Belajar_Identity.Models;

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
            var result = await con.QueryAsync<UserRoleVM>("EXEC SP_Retrieve_UserRoles");
            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }
    }
}