using CMA_Leadership.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMA_Leadership.Controllers
{
    public class Test : Controller
    {
        private readonly dbContext _context;

        public Test(dbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Students.ToListAsync());
        }

        [HttpPost]
        public ActionResult AjaxMethod()
        {

            var StuList = _context.Students.ToList();
            return Json(StuList);
        }

    }
    }
