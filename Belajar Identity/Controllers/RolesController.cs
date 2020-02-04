using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Belajar_Identity.Models;
using System.Configuration;
using Dapper;
using System.Threading.Tasks;

namespace Belajar_Identity.Controllers
{
    public class RolesController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        // GET: Roles
        public ActionResult Index()
        {
            return View(GetDataRoles());
        }

        public async Task<ActionResult> GetDataRoles()
        {
            var result = await con.QueryAsync<RoleVM>("EXEC SP_Retrieve_Role");
            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Create(RoleVM roleVM)
        {
            var result = await con.QueryAsync<RoleVM>("EXEC SP_Insert_Role @Name", new { Name = roleVM.Name });
            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> Edit(RoleVM roleVM)
        {
            var result = await con.QueryAsync<RoleVM>("EXEC SP_Update_Role @Id,@Name", new { Id = roleVM.Id, Name = roleVM.Name });
            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> Delete(int id)
        {
            var result = await con.QueryAsync<RoleVM>("EXEC SP_Delete_Role @Id", new { Id = id });
            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Details(int id)
        {
            var result = await con.QueryAsync<RoleVM>("EXEC SP_Retrieve_Role_By_Id @Id", new { Id = id});
            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }
    }
    
}