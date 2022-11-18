
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CMA_Leadership.Data;
using CMA_Leadership.Models;


namespace CMA_Leadership.Controllers
{
    public class Positions_Counselor : Controller
    {
        private readonly dbContext _context;

        public Positions_Counselor(dbContext context)
        {
            _context = context;
        }
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Students.ToListAsync());
        //}

        [HttpPost]
        public JsonResult AjaxLoad()
        {
            var StuList = _context.StudentMasterdata.Where(s => s.Unit == "BD").ToList();
            return Json(StuList);
            
        }
        public Task<IActionResult> Index()
        {
            return Task.FromResult((IActionResult)View());
        }
        public Task<IActionResult> Positions()
        {
            return Task.FromResult((IActionResult)View());
        }
        
        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.StudentId == id);
        }

        private bool StudentMasterExists(int id)
        {
            return _context.StudentMasterdata.Any(e => e.StudentId == id);
        }



        public ActionResult UpdatePos(int Id, string pos)
        {
            if (StudentExists(Id))
            {
                var stud = _context.Students.Where(p => p.StudentId == Id).FirstOrDefault();               
                stud.Updated_Position = pos;
                _context.Update(stud);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else if (StudentMasterExists(Id))
            {
                var stud = _context.StudentMasterdata.FirstOrDefault(p => p.StudentId == Id);
                var newStud = new Student {
                    StudentId = stud.StudentId,
                    Updated_Position = pos
                };
                _context.Students.Add(newStud);
                _context.SaveChanges();                    
                return RedirectToAction(nameof(Index));   
            }
            else { 
                return View(); 
            }
        }
        public ActionResult UpdateRank(int Id, string rank)
        {
            if (StudentExists(Id))
            {
                var stud = _context.Students.Where(p => p.StudentId == Id).FirstOrDefault();
                stud.Updated_Rank = rank;
                _context.Update(stud);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else if (StudentMasterExists(Id))
            {
                var stud = _context.StudentMasterdata.FirstOrDefault(p => p.StudentId == Id);
                var newStud = new Student
                {
                    StudentId = stud.StudentId,
                    Updated_Rank = rank
                };
                _context.Students.Add(newStud);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
        public ActionResult NoteTaker(int Id, string note)
        {
            if (StudentExists(Id))
            {
                var stud = _context.Students.Where(p => p.StudentId == Id).FirstOrDefault();
                stud.Notes = note;
                _context.Update(stud);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else if (StudentMasterExists(Id))
            {
                var stud = _context.StudentMasterdata.FirstOrDefault(p => p.StudentId == Id);
                var newStud = new Student
                {
                    StudentId = stud.StudentId,
                    Notes = note
                };
                _context.Students.Add(newStud);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
    }
}
