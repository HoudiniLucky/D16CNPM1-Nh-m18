using PlasticStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlasticStore.Controllers
{
    public class RegisterController : Controller
    {
        private PlasticStoreEntities db = new PlasticStoreEntities();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        //POST:Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "idUser,idPermission,fullName,username,password,gender,identityCard,address,email,URLAvatar,phone")] User user)
        {

            if (ModelState.IsValid)
            {
                int count = db.User.Count() + 1;
                user.idPermission = "R02";
                var id = 'U' + count.ToString();
                user.idUser = id;

                db.User.Add(user);
                db.SaveChanges();
                return Redirect("~/Home");
            }
            else
            {
                ViewBag.idPermission = new SelectList(db.Permission, "idPermission", "namePermission", user.idPermission);
                return View(user);
            }

        }
    }
}