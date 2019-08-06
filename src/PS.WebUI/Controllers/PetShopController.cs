using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PS.Services.Interfaces;
using PS.Services.ViewModels;
using System;

namespace PS.WebUI.Controllers
{
    public sealed class PetShopController : Controller
    {
        private readonly IPetShopServices _petShopServices;
        private readonly ILogger<PetShopController> _logger;

        public PetShopController(IPetShopServices petShopServices, ILogger<PetShopController> logger)
        {
            _petShopServices = petShopServices;
            _logger = logger;
        }

        // GET: Pet
        public ActionResult Index()
        {
            try
            {
                _logger.LogInformation("Action Index on Pet controller");
                var pets = _petShopServices.GetAll();
                return View(pets);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new StatusCodeResult(500);
            }
        }

        // GET: Pet/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                _logger.LogInformation("Action HttpGet Details on Pet controller");
                var petShop = _petShopServices.Read(id);
                return View(petShop);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new StatusCodeResult(500);
            }
        }

        // GET: Pet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pet/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Name,Alive")]PetViewModel pet)
        {
            try
            {
                _logger.LogInformation("Action HttpPost Create on Pet controller");
                _petShopServices.Insert(pet);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        // GET: Pet/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                _logger.LogInformation("Action HttpGet Edit on Pet controller");
                var petShop = _petShopServices.Read(id);
                return View(petShop);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        // POST: Pet/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                _logger.LogInformation("Action HttpPost Edit on Pet controller");
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
            try
            {
                _logger.LogInformation("Action HttpGet Delete on Pet controller");
                var petShop = _petShopServices.Read(id);
                return View(petShop);
            }
            catch
            {
                return new StatusCodeResult(500);
            }
        }

        // POST: Pet/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _logger.LogInformation("Action HttpPost Delete on Pet controller");
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return new StatusCodeResult(500);
            }
        }
    }
}