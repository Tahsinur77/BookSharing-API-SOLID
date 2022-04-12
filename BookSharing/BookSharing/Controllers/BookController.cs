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
    public class BookController : ApiController
    {
        [Route("api/Book/Add")]
        [HttpPost]
        public HttpResponseMessage Add(BookModel book)
        {
            if (ModelState.IsValid)
            {
                var flag = BookService.Add(book);

                if (flag) return Request.CreateResponse(HttpStatusCode.OK, "Added");
                else return Request.CreateResponse(HttpStatusCode.OK, "Not Added");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [Route("api/Book/list")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var list = BookService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        [Route("api/Book/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var list = BookService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        [Route("api/Book/Edit")]
        [HttpPost]
        public HttpResponseMessage Edit(BookModel book)
        {
            if (ModelState.IsValid)
            {
                var flag = BookService.Edit(book);
                if (flag) return Request.CreateResponse(HttpStatusCode.OK, "Edited");
                else return Request.CreateResponse(HttpStatusCode.OK, "Not Edited");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [Route("api/Book/Delete/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var flag = BookService.Delete(id);
            if (flag) return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
            else return Request.CreateResponse(HttpStatusCode.OK, "Not Delete");
        }

    }
}
