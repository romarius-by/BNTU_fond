using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BNTU_fond.Models;
using BNTU_fond.Models.ViewModel;
using BNTU_fond.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BNTU_fond.Controllers
{
    public class AuditoryController : Controller
    {
        private readonly IRepository<Auditory> auditoryRepo;
        private readonly IRepository<Floor> floorRepo;

        public AuditoryController(IRepository<Auditory> auditoryRepo, IRepository<Floor> floorRepo)
        {
            this.auditoryRepo = auditoryRepo;
            this.floorRepo = floorRepo;
        }

        public IActionResult Index(int id)
        {
            var auditoryViewModel = new AuditoryViewModel();
            var auditories = auditoryRepo.GetAll().Where(auditory => auditory.FloorId == id);

            auditoryViewModel.Auditories = auditories;
            auditoryViewModel.FloorId = id;
            auditoryViewModel.FloorNum = floorRepo.GetById(id).FloorNum;
            auditoryViewModel.BuildingId = floorRepo.GetById(id).BuildingId;

            return View(auditoryViewModel);
        }

        public IActionResult Create(int id)
        {
            ViewBag.FloorId = id;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int id, Auditory auditory)
        {
            if (ModelState.IsValid)
            {
                auditory.FloorId = id;
                auditoryRepo.Create(auditory);

                return RedirectToAction("Index", new { id });
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var auditory = auditoryRepo.GetById(id);

            if (auditory == null)
            {
                return new StatusCodeResult(404);
            }

            return View(auditory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Auditory auditory)
        {
            auditoryRepo.Update(auditory);

            return RedirectToAction("Index", new { id = auditory.FloorId });
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var auditory = auditoryRepo.GetById(id);

            if (auditory == null)
            {
                return new StatusCodeResult(404);
            }

            return View(auditory);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            var auditory = auditoryRepo.GetById(id);

            auditoryRepo.Delete(auditory);

            return RedirectToAction("Index", new { id = auditory.FloorId });
        }
    }
}
