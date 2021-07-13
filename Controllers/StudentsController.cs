using StudentAdmissionManagement.Models;
using System;
using System.Web.Mvc;

namespace StudentAdmissionManagement.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        BLStudents student = new BLStudents();
        public ActionResult Index(string searchText = null)
        {
            if (searchText == null || searchText.Length == 0)
                return View(student.GetStudentsList());
            else
                return View(student.GetStudentsList(searchText));
        }

        // GET: Students/Details/5
        public ActionResult Details(int id)
        {
            return View(student.GetStudentDetails(id));
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        public ActionResult Create(Student obj)
        {
            try
            {
                // TODO: Add insert logic here
                student.AddOrUpdateStudent(obj);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int id)
        {
            return View(student.GetStudentDetails(id));
        }

        // POST: Students/Edit/5
        [HttpPost]
        public ActionResult Edit(Student obj)
        {
            try
            {
                // TODO: Add update logic here
                student.AddOrUpdateStudent(obj);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Students/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                student.RemoveStudent(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}
