using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.Models;
using Student.Service;

namespace Student.Controllers
{
    public class StudentController : Controller
    {

        private StudentService _studentService;

        public StudentController()
        {
            _studentService = new StudentService();
        }



        // GET: StudentController
        public ActionResult Index()
        {
            var model = _studentService.GetById(1);
            return View(model);
        }

        // GET: StudentController/Details/5
        public ActionResult Details()
        {
            
            return View();
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _studentService.GetAll();
            return View(model);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StudentModel model)
        {
            try
            {
                _studentService.Update(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
