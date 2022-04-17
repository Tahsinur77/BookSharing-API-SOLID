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
    public class OrderController : ApiController
    {
        [Route("api/Order/Add")]
        [HttpPost]
        public HttpResponseMessage Add(OrderModel order)
        {
            if (ModelState.IsValid)
            {
                var flag = OrderService.Add(order);

                if (flag) return Request.CreateResponse(HttpStatusCode.OK, "Order Added");
                else return Request.CreateResponse(HttpStatusCode.OK, "Sorry! Something Went Wrong.");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [Route("api/Order/list")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var list = OrderService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        [Route("api/Order/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var list = OrderService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        [Route("api/Order/Edit")]
        [HttpPost]
        public HttpResponseMessage Edit(OrderModel order)
        {
            if (ModelState.IsValid)
            {
                var flag = OrderService.Edit(order);
                if (flag) return Request.CreateResponse(HttpStatusCode.OK, "Edited Successfully");
                else return Request.CreateResponse(HttpStatusCode.OK, "Sorry! Something Went Wrong.");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [Route("api/Order/Delete/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var flag = OrderService.Delete(id);
            if (flag) return Request.CreateResponse(HttpStatusCode.OK, "Order Deleted");
            else return Request.CreateResponse(HttpStatusCode.OK, "Sorry! Order Can't be Deleted.");
        }
    }
}
