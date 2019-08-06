using System.Collections.Generic;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace PS.WebAPI.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected ActionResult<string> AddValidationErrors(IList<ValidationFailure> validationErrors)
        {
            var listErrors = new List<string>();
            foreach (var error in validationErrors)
            {
                listErrors.Add(error.ErrorMessage);
            }
            return BadRequest(listErrors);
        }
    }
}