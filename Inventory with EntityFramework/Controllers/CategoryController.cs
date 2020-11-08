using Inventory_with_EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace Inventory_with_EntityFramework.Controllers
{
    public class CategoryController : Controller
    {
        InventoryDB context = new InventoryDB();
        // GET: Category
        public ActionResult Index()
        {
            ////LINQ => Lnaguage Integrated Query
            //var categoryList = from item in context.Categories
            //                   select item;
            //return View(categoryList.ToList());

            //Lamda Expression
            return View(context.Categories.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category cat)
        {
            context.Categories.Add(cat);
            context.SaveChanges();
            return RedirectToAction("/Index");
        }
    }
}