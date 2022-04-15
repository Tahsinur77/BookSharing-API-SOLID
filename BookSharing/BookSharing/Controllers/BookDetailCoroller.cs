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
    public class BookDetailCoroller : ApiController
    {
        [Route("api/bookDetail/Add")]
        [HttpPost]
        public HttpResponseMessage Add(BookDetailModel user)
        {
            if (ModelState.IsValid)
            {
                var flag = BookDetailService.Add(user);

                if (flag) return Request.CreateResponse(HttpStatusCode.OK, "Added");
                else return Request.CreateResponse(HttpStatusCode.OK, "Not Added");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [Route("api/bookDetail/list")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var list = BookDetailService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        [Route("api/bookDetails/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var list = BookDetailService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        [Route("api/bookDetails/edit")]
        [HttpPost]
        public HttpResponseMessage Edit(BookDetailModel author)
        {
            if (ModelState.IsValid)
            {
                var flag = BookDetailService.Edit(author);
                if (flag) return Request.CreateResponse(HttpStatusCode.OK, "Edited");
                else return Request.CreateResponse(HttpStatusCode.OK, "Not Edited");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [Route("api/bookDetails/delete/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var flag = BookDetailService.Delete(id);
            if (flag) return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
            else return Request.CreateResponse(HttpStatusCode.OK, "Not Delete");
        }
    }
}