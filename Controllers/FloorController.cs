using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BNTU_fond.Models;
using BNTU_fond.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BNTU_fond.Controllers
{
    public class FloorController : Controller
    {
        private readonly IRepository<Floor> floorRepo;

        public FloorController(IRepository<Floor> floorRepo)
        {
            this.floorRepo = floorRepo;
        }

        public IActionResult Index(int id)
        {
            ViewBag.BuildingId = id;
            var floors = floorRepo.GetAll().Where(floor => floor.BuildingId == id);

            return View(floors);
        }

        public IActionResult Create(int id)
        {
            ViewBag.BuildingId = id;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int id, Floor floor)
        {
            if (ModelState.IsValid)
            {
                floor.BuildingId = id;
                floorRepo.Create(floor);

                return RedirectToAction("Index", new { id });
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var floor = floorRepo.GetById(id);

            if (floor == null)
            {
                return new StatusCodeResult(404);
            }

            return View(floor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Floor floor)
        {
            floorRepo.Update(floor);

            return RedirectToAction("Index", new { id = floor.BuildingId });
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var floor = floorRepo.GetById(id);

            if (floor == null)
            {
                return new StatusCodeResult(404);
            }

            return View(floor);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            var floor = floorRepo.GetById(id);

            floorRepo.Delete(floor);

            return RedirectToAction("Index", new { id = floor.BuildingId });
        }
    }
}
