using BLL.Services;
using ELL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BookSharing.Controllers
{
    public class BookDetailController : ApiController
    {
        /*[Route("api/BookDetail/add")]
        [HttpPost]
        public HttpResponseMessage Add(BookDetailModel bookDetail)
        {
            if (ModelState.IsValid)
            {
                var flag = BookDetailService.Add(bookDetail);

                if (flag) return Request.CreateResponse(HttpStatusCode.OK, "Added");
                else return Request.CreateResponse(HttpStatusCode.OK, "Not Added");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }*/

        [Route("api/BookDetail/list")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var list = BookDetailService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        [Route("api/BookDetail/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var list = BookDetailService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        [Route("api/BookDetail/edit")]
        [HttpPost]
        /*public HttpResponseMessage Edit(BookDetailModel bookDetail)
        {
            if (ModelState.IsValid)
            {
                var flag = BookDetailService.Edit(bookDetail);
                if (flag) return Request.CreateResponse(HttpStatusCode.OK, "Edited");
                else return Request.CreateResponse(HttpStatusCode.OK, "Not Edited");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }
        */
        [Route("api/BookDetail/delete/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var flag = BookDetailService.Delete(id);
            if (flag) return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
            else return Request.CreateResponse(HttpStatusCode.OK, "Not Delete");
        }
    }
}