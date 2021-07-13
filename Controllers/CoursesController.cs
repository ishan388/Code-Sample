using StudentAdmissionManagement.Models;
using System.Web.Mvc;

namespace StudentAdmissionManagement.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Courses
        BLCourses course = new BLCourses();
        public ActionResult Index()
        {
            return View(course.GetCoursesList());
        }

        // GET: Courses/Details/5
        public ActionResult Details(int id)
        {
            return View(course.GetCourseDetails(id));
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        [HttpPost]
        public ActionResult Create(Course obj)
        {
            try
            {
                // TODO: Add insert logic here
                course.AddOrUpdateCourse(obj);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Courses/Edit/5
        [HttpPost]
        public ActionResult Edit(Course obj)
        {
            try
            {
                // TODO: Add update logic here
                course.AddOrUpdateCourse(obj);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Courses/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                course.RemoveCourse(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
