using BLL.Services;
using ELL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookSharing.Controllers
{
    public class ShopChangeRequestController : ApiController
    {
        [Route("api/Shop/Add")]
        [HttpPost]
        public HttpResponseMessage Add(ShopChangeRequestModel shopChangeRequstModel)
        {
            if (ModelState.IsValid)
            {
                var flag = ShopChangeRequestService.Add(shopChangeRequstModel);

                if (flag) return Request.CreateResponse(HttpStatusCode.OK, "Added");
                else return Request.CreateResponse(HttpStatusCode.OK, "Not Added");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [Route("api/Shop/list")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var list = ShopChangeRequestService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        [Route("api/ShopDetails/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var list = ShopChangeRequestService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        [Route("api/ShopDetails/Edit")]
        [HttpPost]
        public HttpResponseMessage Edit(ShopChangeRequestModel shopDetails)
        {
            if (ModelState.IsValid)
            {
                var flag = ShopChangeRequestService.Edit(shopDetails);
                if (flag) return Request.CreateResponse(HttpStatusCode.OK, "Edited");
                else return Request.CreateResponse(HttpStatusCode.OK, "Not Edited");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [Route("api/ShopDetails/Delete/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var flag = ShopChangeRequestService.Delete(id);
            if (flag) return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
            else return Request.CreateResponse(HttpStatusCode.OK, "Not Delete");
        }

    }
}
