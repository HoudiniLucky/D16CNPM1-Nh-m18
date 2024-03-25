using PlasticStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlasticStore.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        private PlasticStoreEntities db = new PlasticStoreEntities();
        public ActionResult Index()
        {
            if (Session["SESSION_GROUP_ADMIN"] != null)
            {
                int countUser = db.User.Count();
                int countBill = db.Bill.Count();
                int countProduct = db.Product.Count();
                ViewBag.countUser = countUser.ToString(); ;
                ViewBag.countBill = countBill.ToString(); ;
                ViewBag.product = countProduct.ToString(); ;
                return View();
            }
            return Redirect("~/login");
        }
    }
}