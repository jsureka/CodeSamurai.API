using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using CodeSamurai.API.Models;

namespace CodeSamurai.API.Core.Framework
{
    [ApiController]
    public abstract class BaseApiController : Controller
    {
        protected IActionResult Ok<T>(T baseModel, string message = null, bool showDefaultMessageIfEmpty = false) where T : class
        {
            var model = new ResponseModel<T>();
            model.Data = baseModel;
            if (showDefaultMessageIfEmpty && string.IsNullOrWhiteSpace(message))
                message = "Ok";
            model.Message = message;

            return base.Ok(model);
        }


        protected IActionResult Ok<T>(IEnumerable<T> baseModel, string message = null, bool showDefaultMessageIfEmpty = false) where T : class
        {
            var model = new ResponseModel<IEnumerable<T>>();
            model.Data = baseModel;
            if (showDefaultMessageIfEmpty && string.IsNullOrWhiteSpace(message))
                message = "Ok";
            model.Message = message;

            return base.Ok(model);
        }

        protected IActionResult Ok(string message = null, bool showDefaultMessageIfEmpty = false)
        {
            var model = new ResponseModel<string>();
            if (showDefaultMessageIfEmpty && string.IsNullOrWhiteSpace(message))
                message = "Ok";

            model.Message = message;

            return base.Ok(model);
        }

        protected IActionResult Created(string id, string message = null, bool showDefaultMessageIfEmpty = true)
        {
            var model = new ResponseModel<string>();
            model.Data = id;
            if (showDefaultMessageIfEmpty && string.IsNullOrWhiteSpace(message))
                message = "Created";
            model.Message = message;
            return base.StatusCode(StatusCodes.Status201Created, model);
        }

        protected IActionResult BadRequest<T>(T baseModel, bool showDefaultMessageIfEmpty = true) where T : class
        {
            var model = new ResponseModel<T>();
            model.Data = baseModel;

            return base.BadRequest(model);
        }

        protected IActionResult BadRequest()
        {
            return base.BadRequest();
        }

        protected IActionResult BadRequest(IList<string> errors, bool showDefaultMessageIfEmpty = true)
        {
            return base.BadRequest();
        }

       
        protected IActionResult NotFound<T>(T baseModel, string error = null, bool showDefaultMessageIfEmpty = true) where T : class
        {
            var model = new ResponseModel<T>();
            model.Data = baseModel;

            return base.NotFound(model);
        }

        protected IActionResult NotFound()
        {

            return base.NotFound();
        }

        protected IActionResult InternalServerError<T>(T baseModel, string error = null, bool showDefaultMessageIfEmpty = true) where T : class
        {
            return base.StatusCode(StatusCodes.Status500InternalServerError, baseModel);
        }

        protected IActionResult InternalServerError(string error = null, bool showDefaultMessageIfEmpty = true)
        {
            return base.StatusCode(StatusCodes.Status500InternalServerError, null);
        }

        protected IActionResult MethodNotAllowed()
        {
            return base.StatusCode(StatusCodes.Status405MethodNotAllowed);
        }

        protected IActionResult LengthRequired()
        {
            return base.StatusCode(StatusCodes.Status411LengthRequired);
        }
    }
}
