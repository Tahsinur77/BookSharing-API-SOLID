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
    public class ShopController : ApiController
    {
        [Route("api/Shop/Add")]
        [HttpPost]
        public HttpResponseMessage Add(ShopModel shop)
        {
            if (ModelState.IsValid)
            {
                var flag = ShopService.Add(shop);

                if (flag) return Request.CreateResponse(HttpStatusCode.OK, "Added");
                else return Request.CreateResponse(HttpStatusCode.OK, "Not Added");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [Route("api/Shop/list")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var list = ShopService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        [Route("api/Shop/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var list = ShopService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        [Route("api/Shop/Edit")]
        [HttpPost]
        public HttpResponseMessage Edit(ShopModel shop)
        {
            if (ModelState.IsValid)
            {
                var flag = ShopService.Edit(shop);
                if (flag) return Request.CreateResponse(HttpStatusCode.OK, "Edited");
                else return Request.CreateResponse(HttpStatusCode.OK, "Not Edited");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [Route("api/Shop/Delete/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var flag = ShopService.Delete(id);
            if (flag) return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
            else return Request.CreateResponse(HttpStatusCode.OK, "Not Delete");
        }

    }
}
