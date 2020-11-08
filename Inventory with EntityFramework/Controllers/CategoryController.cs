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
        [HttpGet]
        public ActionResult Edit(int id)
        {
            //var categoryToUpdate = from item in context.Categories
            //                       where item.CategoryId == id
            //                       select item;
            //return View(categoryToUpdate.FirstOrDefault());

            //var categoryToUpdate = context.Categories.Where(x => x.CategoryId == id);
            //return View(categoryToUpdate.FirstOrDefault());

            //return View(context.Categories.Where(x => x.CategoryId == id).FirstOrDefault());

            return View(context.Categories.Find(id)); //Must have same primary key properly
        }
        [HttpPost]
        public ActionResult Edit(Category cat)
        {
            //var result = from item in context.Categories
            //                       where item.CategoryId == cat.CategoryId
            //                       select item;

            //var result = context.Categories.Where(x => x.CategoryId == cat.CategoryId);
            //Category categoryToUpdate = result.FirstOrDefault();
            //categoryToUpdate.CategoryName = cat.CategoryName;
            //context.SaveChanges();
            //return RedirectToAction("/Index");

            Category categoryToUpdate = context.Categories.Where(x => x.CategoryId == cat.CategoryId).FirstOrDefault();
            categoryToUpdate.CategoryName = cat.CategoryName;
            context.SaveChanges();

            return RedirectToAction("/Index");

        }
    }
}