using Microsoft.AspNetCore.Mvc;
using WhiteLagoon.Infrastructure.Data;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.WebApi.Controllers
{

    public class VillaController : Controller
    {
        private readonly AppDbContext appDbContext;

        public VillaController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var villa = appDbContext.Villas.ToList();
            return View(villa);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(WhiteLagoon.Domain.Entities.Villa villa)
        {
            if (ModelState.IsValid)
            {
                appDbContext.Villas.Add(villa);
                appDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(villa);
        }


        // Update Villa start here
        public IActionResult Update (int Id)
        {
            var villa = appDbContext.Villas.FirstOrDefault(v => v.Id == Id);
            if (villa == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villa);
        }


        [HttpPost]
        public IActionResult Update(Villa villa)
        {
            if (ModelState.IsValid)
            {
                villa.UpdatedDate = DateTime.Now;
                appDbContext.Villas.Update(villa);
                appDbContext.SaveChanges();
                TempData["success"] = "Villa updated successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(villa);
        }



        // GET: Delete Villa
        public IActionResult Delete(int Id)
        {
            var villa = appDbContext.Villas.FirstOrDefault(v => v.Id == Id);
            if (villa == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villa);
        }

        // POST: Delete Villa
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int Id)
        {
            var villa = appDbContext.Villas.FirstOrDefault(v => v.Id == Id);
            if (villa == null)
            {
                return RedirectToAction("Error", "Home");
            }

            appDbContext.Villas.Remove(villa);
            appDbContext.SaveChanges();
            TempData["success"] = "Villa deleted successfully!";
            return RedirectToAction(nameof(Index));
        }

    }
}
