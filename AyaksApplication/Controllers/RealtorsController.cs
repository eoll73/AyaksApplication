using AyaksApplication.Models;
using AyaksApplication.Repositoryes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AyaksApplication.Controllers
{
    public class RealtorsController : Controller
    {
        private readonly RealtorsRepository realtorsRepository;
        public RealtorsController(RealtorsRepository realtorsRepository)
        {
            this.realtorsRepository = realtorsRepository;
        }
        // GET: RealtorsController
        public ActionResult Index(int page = 1)
        {
            var model = realtorsRepository.GetAllRealtors(page, 2);

             return View(model);
        }

        // GET: RealtorsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RealtorsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RealtorsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Realtors message)
        {
            try
            {
                realtorsRepository.Add(message);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RealtorsController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = realtorsRepository.Get(id);

            return View(model);
        }

        // POST: RealtorsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Realtors realtors)
        {
            try
            {
                realtorsRepository.Update(realtors);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RealtorsController/Delete/5
        public ActionResult Delete(int id)
        {
            realtorsRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        // POST: RealtorsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
