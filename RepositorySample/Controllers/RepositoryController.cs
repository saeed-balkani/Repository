using RepositorySample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepositorySample.Controllers
{
    public class RepositoryController : Controller
    {
        StudentRepository repo = new StudentRepository();
        // GET: Repository
        public ActionResult Index()
        {
            return View(repo.GetStudent().ToList());
        }

        public ActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                repo.AddStudent(student.Name, student.Age, student.Average);
            }
            ViewBag.message = "New Item Added Successfully !";
            return View();
        }

        [HttpPost]
        public ActionResult RemoveStudent(string delete)
        {
            if (repo.RemoveStudent(delete) == 1)
            {
                return Redirect("Index");
            }
            return Redirect("Index");
        }

    }
}