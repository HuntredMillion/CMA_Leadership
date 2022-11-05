
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CMA_Leadership.Data;
using CMA_Leadership.Models;


namespace CMA_Leadership.Controllers
{
    public class Test : Controller
    {
        private readonly dbContext _context;

        public Test(dbContext context)
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
            var StuList = _context.Students.ToList();
            return Json(StuList);
            
        }
        public Task<IActionResult> Index()
        {
            return Task.FromResult((IActionResult)View());
        }

        public async Task<IActionResult> UpdatePos(int id, string upPos){
            var stud = _context.Students.FirstOrDefault(p => p.StudentId == id);
            stud.Updated_Position = upPos;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stud);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(stud.StudentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public async Task<IActionResult> UpdateRank(int id, string upRank)
        {
            var stud = _context.Students.FirstOrDefault(p => p.StudentId == id);
            stud.Updated_Rank = upRank;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stud);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(stud.StudentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.StudentId == id);
        }
    }
}
