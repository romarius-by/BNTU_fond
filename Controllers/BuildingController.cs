using BNTU_fond.Models;
using BNTU_fond.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BNTU_fond.Controllers
{
    public class BuildingController : Controller
    {
        private readonly IRepository<Building> buildingRepo;

        public BuildingController(IRepository<Building> buildingRepo)
        {
            this.buildingRepo = buildingRepo;
        }

        public IActionResult Index()
        {
            var building = buildingRepo.GetAll();

            return View(building);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Building building)
        {
            if (ModelState.IsValid)
            {
                buildingRepo.Create(building);

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var building = buildingRepo.GetById(id);

            if (building == null)
            {
                return new StatusCodeResult(404);
            }

            return View(building);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Building building)
        {
            buildingRepo.Update(building);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var building = buildingRepo.GetById(id);

            if (building == null)
            {
                return new StatusCodeResult(404);
            }

            return View(building);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            var building = buildingRepo.GetById(id);

            buildingRepo.Delete(building);

            return RedirectToAction("Index");
        }
    }
}
