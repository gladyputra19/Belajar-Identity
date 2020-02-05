using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using API.Models;

namespace API.Controllers
{
    public class RolesController : ApiController
    {
        ApplicationDbContext myContext = new ApplicationDbContext();
        public IQueryable<Roles> GetRoles()
        {
            return myContext.Roles;
        }
        [ResponseType(typeof(Roles))]
        public IHttpActionResult GetRoles(int Id)
        {
            Roles role = myContext.Roles.Find(Id);
            return Ok(role);
        }
        [ResponseType(typeof(Roles))]
        public IHttpActionResult Post(Roles role)
        {
            myContext.Roles.Add(role);
            myContext.SaveChanges();
            return CreatedAtRoute("DefaultApi",new { Id = role.Id},role);
        }
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(Roles role, int Id)
        {
             var put = myContext.Roles.Find(Id);
             put.Name = role.Name;
             myContext.Entry(put).State = EntityState.Modified;
             myContext.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }
        [ResponseType(typeof(Roles))]
        public IHttpActionResult Delete(Roles role, int Id)
        {
            var del = myContext.Roles.Find(Id);
            myContext.Roles.Remove(del);
            myContext.SaveChanges();

            return Ok(del);
        }
    }

}
