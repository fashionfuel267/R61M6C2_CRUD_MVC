using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using R61M6C2_w01.Models;

namespace R61M6C2_w01.Controllers
{
    public class EmployeesController : Controller
    {
        TaskContext db=new TaskContext();
        // GET: Employees
        public ActionResult Index()
        {
            var model= db.Employee.Include("Department").OrderBy(n=>n.Name).ToList();
            return View(model);
        }
        public ActionResult Create() {

            ViewBag.Department = new SelectList(db.Department.OrderBy(d => d.Name), "Id", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee,HttpPostedFileBase EmployeePic)
        {

            if (EmployeePic == null) {
                ModelState.AddModelError("", "Please Provide valid pic");
                
              //  return View(EmployeePic);
            }
            else
            {
                if (ModelState.IsValid) {
                string ext= Path.GetExtension(EmployeePic.FileName);
                if(ext ==".jpg"||  ext ==".png"|| ext == ".jpeg")
                {
                   string root= Server.MapPath("~/");
                    string fileTosave = Path.Combine(root,"Images",employee.Name+ext);
                    EmployeePic.SaveAs(fileTosave);
                    employee.ImagePath = "~/Images/"+ employee.Name + ext;
                    db.Employee.Add(employee);
                    if (db.SaveChanges() > 0)
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Please Provide valid pic .jpg|.png|.jpeg");
                    return View(EmployeePic);
                }
                }
                else
                {
                    return View(EmployeePic);
                }
            }
            ViewBag.Department = new SelectList(db.Department.OrderBy(d => d.Name), "Id", "Name");
            return View();
        }
        public ActionResult Edit(int? id)
        {
            ViewBag.Department = new SelectList(db.Department.OrderBy(d => d.Name), "Id", "Name");
            if (id == 0)
            {
                return HttpNotFound();
            }
            var model = db.Employee.Find(id);
            if(model==null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Employee employee, HttpPostedFileBase EmployeePic)
        {
            
                if (ModelState.IsValid)
                {
                if (EmployeePic != null)
                {
                    string ext = Path.GetExtension(EmployeePic.FileName);
                    if (ext == ".jpg" || ext == ".png" || ext == ".jpeg")
                    {
                        string root = Server.MapPath("~/");
                        string fileTosave = Path.Combine(root, "Images", employee.Name + ext);
                        EmployeePic.SaveAs(fileTosave);
                        employee.ImagePath = "~/Images/" + employee.Name + ext;
                    }
                    else
                    {
                        ModelState.AddModelError("", "Please Provide valid pic .jpg|.png|.jpeg");
                        return View(EmployeePic);
                    }
                }
                else
                {
                    employee.ImagePath = employee.ImagePath;
                }
                //db.Employee.Add(employee);
                db.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                if (db.SaveChanges() > 0)
                {
                    return RedirectToAction("Index");
                }
            }
                else
                {
                    return View(EmployeePic);
                }
            
            ViewBag.Department = new SelectList(db.Department.OrderBy(d => d.Name), "Id", "Name");
            return View();
        }
        public ActionResult Delete(int id)
        {
            if (id == 0) { 
                return HttpNotFound();
            }
            var emp= db.Employee.Find(id);
            db.Employee.Remove(emp);
           if(db.SaveChanges() > 0)
            {
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }
        

    }
}