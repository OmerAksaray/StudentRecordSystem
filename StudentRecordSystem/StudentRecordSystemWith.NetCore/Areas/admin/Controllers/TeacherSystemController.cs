using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SRS.DataAccess.Repository.IRepository;
using SRS.Models;
using SRS.Models.Models;
using SRS.Utility;

namespace StudentRecordSystemWith.NetCore.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles =SD.Role_Admin)]
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
                TempData["success"] = "You created successfully.";
                return RedirectToAction("List");
            }
            return View(teacher);
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
                var existingTeacher = _db.Teacher.Get(u => u.TeacherId == teacher.TeacherId);
                if (existingTeacher != null)
                {
                    existingTeacher.Name = teacher.Name;
                    existingTeacher.Surname = teacher.Surname;
                    existingTeacher.Profession = teacher.Profession;

                    _db.Teacher.Update(existingTeacher);
                    _db.Save();
                    TempData["success"] = "You edited successfully.";
                    return RedirectToAction("List");
                }
                else
                {
                    TempData["error"] = "Teacher not found.";
                    return RedirectToAction("List");
                }
            }
            return View(teacher);
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
        #region API CALLS
        [HttpGet]
        public IActionResult GetAllTeacher()
        {
            List<TeacherModel> obj = _db.Teacher.GetAll().ToList();
            return Json(new { data = obj });

        }
        #endregion 

    }
}
