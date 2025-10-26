using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.WebApi.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public VillaNumberController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // GET: Index
        public IActionResult Index()
        {
            var villaNumbers = _appDbContext.VillaNumbers.ToList();
            return View(villaNumbers);
        }

        // GET: Create
        public IActionResult Create()
        {
            ViewBag.Villas = new SelectList(_appDbContext.Villas, "Id", "Name");
            return View();
        }

        // POST: Create
        [HttpPost]
        public IActionResult Create(VillaNumber obj)
        {
            // Validate foreign key
            if (!_appDbContext.Villas.Any(v => v.Id == obj.VillaId))
            {
                ModelState.AddModelError("VillaId", "Selected Villa does not exist.");
            }

            // Optional: Check duplicate VillaNumber
            if (_appDbContext.VillaNumbers.Any(vn => vn.Villa_Number == obj.Villa_Number))
            {
                ModelState.AddModelError("Villa_Number", "Villa Number already exists. Please use a different number.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _appDbContext.VillaNumbers.Add(obj);
                    _appDbContext.SaveChanges();
                    TempData["success"] = "Villa Number created successfully!";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    // Show inner exception for debugging
                    ModelState.AddModelError("", $"Database error: {ex.InnerException?.Message}");
                }
            }

            // Populate dropdown in case of error
            ViewData["VillaId"] = new SelectList(_appDbContext.Villas, "Id", "Name", obj.VillaId);

            return View(obj);
        }

        // GET: Update
        public IActionResult Update(int id)
        {
            var villaNumber = _appDbContext.VillaNumbers.FirstOrDefault(v => v.Villa_Number == id);
            if (villaNumber == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villaNumber);
        }

        // POST: Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(VillaNumber villaNumber)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.VillaNumbers.Update(villaNumber);
                _appDbContext.SaveChanges();
                TempData["success"] = "Villa Number updated successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(villaNumber);
        }

        // GET: Delete
        public IActionResult Delete(int Villa_Number)
        {
            var villaNumber = _appDbContext.VillaNumbers.FirstOrDefault(v => v.Villa_Number == Villa_Number);
            if (villaNumber == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villaNumber);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(VillaNumber model)
        {
            var villaNumber = _appDbContext.VillaNumbers.Find(model.Villa_Number);
            if (villaNumber == null)
                return RedirectToAction("Error", "Home");

            _appDbContext.VillaNumbers.Remove(villaNumber);
            _appDbContext.SaveChanges();
            TempData["success"] = "Villa Number deleted successfully!";
            return RedirectToAction(nameof(Index));
        }



    }
}
