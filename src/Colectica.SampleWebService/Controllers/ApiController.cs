using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Colectica.SampleWebService.Data;
using Microsoft.AspNetCore.Mvc;

namespace Colectica.SampleWebService.Controllers
{
    [Route("")]
    public class ApiController : ControllerBase
    {
        [HttpPost("item-js-handler")]
        public ActionResult<ApiResponse> ItemHandler([FromBody]ItemRequest request)
        {
            var id = request.ItemIdentifier;

            var response = new ApiResponse();
            response.Message = $"I received the following identification information: {id}";
            return response;
        }

        [HttpPost("item-js-handler-redirect")]
        public ActionResult<ApiResponse> BasketHandlerWithRedirect([FromBody]ItemRequest request)
        {
            var response = new ApiResponse();
            response.RedirectUrl = "http://example.org";
            return response;
        }


        [HttpPost("basket-js-handler")]
        public ActionResult<ApiResponse> BasketHandlerWithMessage([FromBody]BasketRequest request)
        {
            var response = new ApiResponse();
            response.Message = $"I received information about a basket named {request.Citation.Title.EnglishUS}. It has {request.ItemIdentifers.Length} items in it.";
            return response;
        }

        [HttpPost("basket-js-handler-redirect")]
        public ActionResult<ApiResponse> BasketHandlerWithRedirect([FromBody] BasketRequest request)
        {
            var response = new ApiResponse();
            response.RedirectUrl = "http://example.org";
            return response;
        }

    }

}
