using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using R61M6C2_w01.Models;

namespace R61M6C2_w01.Controllers
{
    public class DepartmentsController : Controller
    {
        TaskContext db = new TaskContext();
        // GET: Employees
        public ActionResult Index()
        {
            var model = db.Department.OrderBy(n => n.Name).ToList();
            return View(model);
        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Department department )
        {
            db.Department.Add(department);
            if(db.SaveChanges()>0)
            {
                return RedirectToAction("Index");
            }

            return View(department);
        }
        public ActionResult Edit()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Edit(Department department)
        {
            db.Entry(department).State=  System.Data.Entity.EntityState.Modified;
            if (db.SaveChanges() > 0)
            {
                return RedirectToAction("Index");
            }

            return View(department);
        }
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            var emp = db.Employee.Find(id);
            db.Employee.Remove(emp);
            if (db.SaveChanges() > 0)
            {
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }

    }
}