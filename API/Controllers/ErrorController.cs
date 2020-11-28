using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ErrorsController : BaseAPIController
    {
        private readonly StoreContext context;

        public ErrorsController(StoreContext context)
        {
            this.context = context;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var item = context.PhotoOffers.Find(42);
            if (item == null)
            {
                return NotFound(new ApiResponse(404));
            }

            return Ok();
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var item = context.PhotoOffers.Find(42);
            string text = item.ToString();

            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }
    }
}
