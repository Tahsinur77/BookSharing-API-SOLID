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
    public class AuthorController : ApiController
    {
        [Route("api/author/add")]
        [HttpPost]
        public HttpResponseMessage Add(AuthorModel author)
        {
            if (ModelState.IsValid)
            {
                var flag = AuthorService.Add(author);

                if (flag) return Request.CreateResponse(HttpStatusCode.OK, "Added");
                else return Request.CreateResponse(HttpStatusCode.OK, "Not Added");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [Route("api/author/list")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var list = AuthorService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        [Route("api/author/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var list = AuthorService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        [Route("api/author/edit")]
        [HttpPost]
        public HttpResponseMessage Edit(AuthorModel author)
        {
            if (ModelState.IsValid)
            {
                var flag = AuthorService.Edit(author);
                if (flag) return Request.CreateResponse(HttpStatusCode.OK, "Edited");
                else return Request.CreateResponse(HttpStatusCode.OK, "Not Edited");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [Route("api/author/delete/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var flag = AuthorService.Delete(id);
            if (flag) return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
            else return Request.CreateResponse(HttpStatusCode.OK, "Not Delete");
        }
    }
}
