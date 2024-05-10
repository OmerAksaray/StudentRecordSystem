using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SRS.Data;
using SRS.DataAccess.Repository.IRepository;
using SRS.Models;
using SRS.Models.ViewModels;
using System.Collections.Generic;


namespace StudentRecordSystemWith.NetCore.Areas.Admin.Controllers
{
    [Area("admin")]
    public class StudentSystemController : Controller
    {
        private IUnitOfWork _db;

        private readonly IWebHostEnvironment _webHostEnvironmet;
        public StudentSystemController(IUnitOfWork db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironmet = webHostEnvironment;
        }
        public IActionResult Upsert(int? id)
        {
            StudentVM studenVM = new StudentVM
            {
                _Student = new StudentModel(),
                TeacherList = _db.Teacher.GetAll().Select(s =>
            new SelectListItem
            {
                Text = s.Name,
                Value = s.TeacherId.ToString()
            }
            )
            };

            if (id == null|| id == 0)
            {
                
                return View(studenVM);

            }
            else
            {
               
                studenVM._Student= _db.Student.Get(i => i.StudentId == id);
                return View(studenVM);
            }
            //ViewBag.TeacherList = TeacherList;
           
            
        }

        [HttpPost]
        public IActionResult Upsert(StudentVM studentVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironmet.WebRootPath;
                if (studentVM._Student.StudentId == 0)
                {
                    // Yeni bir öğrenci ekleniyor
                    if (file != null)
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string studentPath = Path.Combine(wwwRootPath, @"images/students");

                        using (var fileStream = new FileStream(Path.Combine(studentPath, fileName), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        };

                        studentVM._Student.ImageUrl = "/images/students/" + fileName;
                    }

                    _db.Student.Add(studentVM._Student);
                    _db.Save();
                    TempData["success"] = "You created successfully.";
                }
                else
                {
                    // Mevcut öğrenci güncelleniyor
                    var existingStudent = _db.Student.Get(u=>u.StudentId== studentVM._Student.StudentId);
                    if (existingStudent == null)
                    {
                        return NotFound();
                    }

                    if (file != null)
                    {
                        // Eğer yeni bir dosya yüklendi ise eski dosyayı sil ve yeni dosyayı ekle
                        var oldImagePath = Path.Combine(wwwRootPath, existingStudent.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }

                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string studentPath = Path.Combine(wwwRootPath, @"images/students");

                        using (var fileStream = new FileStream(Path.Combine(studentPath, fileName), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        };

                        existingStudent.ImageUrl = "/images/students/" + fileName;
                    }

                    existingStudent.Name = studentVM._Student.Name;
                    // Diğer özellikleri de güncelleyebilirsiniz

                    _db.Student.Update(existingStudent);
                    _db.Save();
                    TempData["success"] = "You updated successfully.";
                }

                return RedirectToAction("List");
            }

            // Model geçerli değilse tekrar aynı sayfayı göster
            studentVM.TeacherList = _db.Teacher.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.TeacherId.ToString()
            });
            return View(studentVM);
        }
        public IActionResult List()
        {
            List<StudentModel> obj = _db.Student.GetAll(includeProperties: "Teacher").ToList();
            return View(obj);
        }

//-----------------------------------------------------------------------------------------
//public IActionResult Update(int? id)
//{

//    return View(_db.Student.Get(u => u.StudentId == id));
//}

//[HttpPost]
//public IActionResult Update(StudentModel student)
//{
//            if (null != _db.Student.Get(u => u.SchoolNumber == student.SchoolNumber))
//            {
//                ModelState.AddModelError("SchoolNumber", "You can't use same school number more than 1");
//            }
//            else if (ModelState.IsValid)
//            {
//                _db.Student.Update(student);
//                _db.Save();
//                TempData["success"] = "You edited succesffuly.";
//                return RedirectToAction("List");
//}
//return View();
//}
[HttpPost]
        public IActionResult Delete(int id)
        {
            var student = _db.Student.Get(u => u.StudentId == id);
            _db.Student.Remove(student);
            _db.Save();
            TempData["success"] = "You deleted succesffuly.";
            return RedirectToAction("List");

        }
    }
}
