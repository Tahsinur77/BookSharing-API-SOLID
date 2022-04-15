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
    public class SellerDetailsController : ApiController
    {
        [Route("api/SellerDetails/Add")]
        [HttpPost]
        public HttpResponseMessage Add(SellerDetailsModel sellerDetails)
        {
            if (ModelState.IsValid)
            {
                var flag = SellerDetailsService.Add(sellerDetails);

                if (flag) return Request.CreateResponse(HttpStatusCode.OK, "Added");
                else return Request.CreateResponse(HttpStatusCode.OK, "Not Added");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [Route("api/SellerDetails/list")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var list = SellerDetailsService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        [Route("api/SellerDetails/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var list = SellerDetailsService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        [Route("api/SellerDetails/Edit")]
        [HttpPost]
        public HttpResponseMessage Edit(SellerDetailsModel sellerDetails)
        {
            if (ModelState.IsValid)
            {
                var flag = SellerDetailsService.Edit(sellerDetails);
                if (flag) return Request.CreateResponse(HttpStatusCode.OK, "Edited");
                else return Request.CreateResponse(HttpStatusCode.OK, "Not Edited");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [Route("api/SellerDetails/Delete/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var flag = SellerDetailsService.Delete(id);
            if (flag) return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
            else return Request.CreateResponse(HttpStatusCode.OK, "Not Delete");
        }
 
    }
}
