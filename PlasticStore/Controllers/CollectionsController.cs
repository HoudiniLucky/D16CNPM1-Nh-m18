using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PlasticStore.Models;
using static PlasticStore.Models.Product;
namespace PlasticStore.Controllers
{
    public class CollectionsController : Controller
    {
        // GET: Collections
        private PlasticStoreEntities db = new PlasticStoreEntities();

        // GET: Collections
        public ActionResult Index()
        {
            var query = db.Product.Include(p => p.ImageProduct);
            ViewBag.list = query.ToList();
            return View(query.ToList());

        }

        // GET: Collections/Details/5

        public ActionResult Details(string id)
        {
            ProductDTODetail productDTO = new ProductDTODetail();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = from el in db.Product
                          where el.idProduct == id
                          select el;

            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {

                var data = from p in product
                           select p;

                data.Include("ImageProducts").Include("Type");
                var datarelateto = (from p in db.Product
                                    join t in data on p.idType equals t.idType
                                    select p);
                datarelateto.Include("ImageProducts").Include("Type");
                var subData = (datarelateto.ToList()).Skip(3).Take(4);
                ViewBag.datarelateto = subData.ToList();
                ViewBag.List = data;
                return View(data.ToList());
            };
        }

        public ActionResult nhuagiadung(string id)
        {
            id = "T01";
            var productList = (from s in db.Product
                               where s.idType == id
                               select s);

            var query = productList.Include(p => p.ImageProduct);
            ViewBag.list = query.ToList();
            return View(query.ToList());


        }

        public ActionResult nhuatreem(string id)
        {
            id = "T02";
            var productList = (from s in db.Product
                               where s.idType == id
                               select s);

            var query = productList.Include(p => p.ImageProduct);
            ViewBag.list = query.ToList();
            return View(query.ToList());
        }

        public ActionResult nhuacongnghiep(string id)
        {
            id = "T03";
            var productList = (from s in db.Product
                               where s.idType == id
                               select s);

            var query = productList.Include(p => p.ImageProduct);
            ViewBag.list = query.ToList();
            return View(query.ToList());

        }

        public ActionResult nhuapet(string id)
        {
            id = "T04";
            var productList = (from s in db.Product
                               where s.idType == id
                               select s);

            var query = productList.Include(p => p.ImageProduct);
            ViewBag.list = query.ToList();
            return View(query.ToList());
        }
    }
}