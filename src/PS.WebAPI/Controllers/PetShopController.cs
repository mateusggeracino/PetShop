using System;
using Microsoft.AspNetCore.Mvc;
using PS.Services.Interfaces;
using System.Collections.Generic;
using System.Net;
using Microsoft.EntityFrameworkCore.Internal;
using PS.Services.ViewModels;

namespace PS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetShopController : BaseController
    {
        private readonly IPetShopServices _petShopServices;

        public PetShopController(IPetShopServices petShopServices)
        {
            _petShopServices = petShopServices;
        }

        
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                var petShops = _petShopServices.GetAll();
                return Ok(petShops);
            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            try
            {
                var petShop = _petShopServices.Read(id);
                return Ok(petShop);
            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }
        }

        // POST api/values
        [HttpPost]
        public ActionResult<string> Post([FromBody] PetViewModel pet)
        {
            try
            {
                var result = _petShopServices.Insert(pet);
                if (result.ValidationResult.Errors.Any()) return AddValidationErrors(result.ValidationResult.Errors);

                return Ok("success");
            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<string> Put(int id, [FromBody] PetViewModel pet)
        {
            try
            {
                _petShopServices.Update(pet);
                return Ok("success");
            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                _petShopServices.Remove(id);
                return Ok("success");
            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }
        }
    }
}