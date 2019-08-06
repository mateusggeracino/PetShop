using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PS.Services.Interfaces;
using PS.Services.ViewModels;

namespace PS.WebUI.Controllers
{
    public class PetShopController : Controller
    {
        private readonly IPetShopServices _petShopServices;

        public PetShopController(IPetShopServices petShopServices)
        {
            _petShopServices = petShopServices;
        }

        // GET: Pet
        public ActionResult Index()
        {
            var pets = _petShopServices.GetAll();
            return View(pets);
        }

        // GET: Pet/Details/5
        public ActionResult Details(int id)
        {
            var petShop = _petShopServices.Read(id);
            return View(petShop);
        }

        // GET: Pet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pet/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id, Name, Registration, Alive")]PetViewModel pet)
        {
            try
            {
                _petShopServices.Insert(pet);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Pet/Edit/5
        public ActionResult Edit(int id)
        {
            var petShop = _petShopServices.Read(id);
            return View(petShop);
        }

        // POST: Pet/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pet/Delete/5
        public ActionResult Delete(int id)
        {
            var petShop = _petShopServices.Read(id);
            return View(petShop);
        }

        // POST: Pet/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}