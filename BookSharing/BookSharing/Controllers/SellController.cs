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
    public class SellController : ApiController
    {
        [Route("api/sell/Add")]
        [HttpPost]
        public HttpResponseMessage Add(SellModel sell)
        {
            if (ModelState.IsValid)
            {
                var flag = SellService.Add(sell);

                if (flag) return Request.CreateResponse(HttpStatusCode.OK, "Order Added");
                else return Request.CreateResponse(HttpStatusCode.OK, "Sorry! Something Went Wrong.");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [Route("api/sell/list")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var list = SellService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        [Route("api/sell/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var list = SellService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        [Route("api/sell/Edit")]
        [HttpPost]
        public HttpResponseMessage Edit(SellModel sell)
        {
            if (ModelState.IsValid)
            {
                var flag = SellService.Edit(sell);
                if (flag) return Request.CreateResponse(HttpStatusCode.OK, "Edited Successfully");
                else return Request.CreateResponse(HttpStatusCode.OK, "Sorry! Something Went Wrong.");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [Route("api/sell/delete/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var flag = SellService.Delete(id);
            if (flag) return Request.CreateResponse(HttpStatusCode.OK, "Order Deleted");
            else return Request.CreateResponse(HttpStatusCode.OK, "Sorry! Order Can't be Deleted.");
        }
        [Route("api/sell/search")]
        [HttpPost]
        public HttpResponseMessage Search(SearchModel search)
        {
            var list = SellService.SellSearch(search);
            if (list != null) return Request.CreateResponse(HttpStatusCode.OK, list);
            else return Request.CreateResponse(HttpStatusCode.OK, "nothing");
        }
    }
}
