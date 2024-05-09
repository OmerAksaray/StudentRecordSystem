using Microsoft.AspNetCore.Mvc;
using SRS.DataAccess.Repository.IRepository;
using SRS.Models;
using SRS.Models.Models;

namespace StudentRecordSystemWith.NetCore.Areas.admin.Controllers
{
    [Area("admin")]
    public class TeacherSystemController : Controller
    {

        private IUnitOfWork _db;
        public TeacherSystemController(IUnitOfWork db)
        {
            _db = db;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TeacherModel teacher)
        {
            if (ModelState.IsValid)
            {
                _db.Teacher.Add(teacher);
                _db.Save();
                TempData["success"] = "You created succesffuly.";
                return RedirectToAction("List");
            }
            return View();
        }
        public IActionResult List()
        {
            return View(_db.Teacher.GetAll());
        }
        public IActionResult Update(int? id)
        {

            return View(_db.Teacher.Get(u => u.TeacherId == id));
        }

        [HttpPost]
        public IActionResult Update(TeacherModel teacher)
        {
             if (ModelState.IsValid)
            {
                _db.Teacher.Update(teacher);
                _db.Save();
                TempData["success"] = "You edited succesffuly.";
                return RedirectToAction("List");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var teacher = _db.Teacher.Get(u => u.TeacherId == id);
            _db.Teacher.Remove(teacher);
            _db.Save();
            TempData["success"] = "You deleted succesffuly.";
            return RedirectToAction("List");

        }
    }
}
