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
    public class OrderDetailsController : ApiController
    {
        [Route("api/OrderDetails/Add")]
        [HttpPost]
        public HttpResponseMessage Add(OrderDetailsModel orderDetails)
        {
            if (ModelState.IsValid)
            {
                var flag = OrderDetailsService.Add(orderDetails);

                if (flag) return Request.CreateResponse(HttpStatusCode.OK, "Order Details Added");
                else return Request.CreateResponse(HttpStatusCode.OK, "Sorry! Something Went Wrong.");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [Route("api/OrderDetails/list")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var list = OrderDetailsService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        [Route("api/OrderDetails/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var list = OrderDetailsService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        [Route("api/OrderDetails/Edit")]
        [HttpPost]
        public HttpResponseMessage Edit(OrderDetailsModel orderDetails)
        {
            if (ModelState.IsValid)
            {
                var flag = OrderDetailsService.Edit(orderDetails);
                if (flag) return Request.CreateResponse(HttpStatusCode.OK, "Edited Successfully");
                else return Request.CreateResponse(HttpStatusCode.OK, "Sorry! Something Went Wrong.");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [Route("api/OrderDetails/Delete/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var flag = OrderDetailsService.Delete(id);
            if (flag) return Request.CreateResponse(HttpStatusCode.OK, "Order Details Removed Successfully.");
            else return Request.CreateResponse(HttpStatusCode.OK, "Sorry! Order Details Can't be Removed.");
        }

    }
}
