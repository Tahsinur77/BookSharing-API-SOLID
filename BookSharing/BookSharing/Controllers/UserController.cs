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
    public class UserController : ApiController
    {
        [Route("api/User/Add")]
        [HttpPost]
        public HttpResponseMessage Add(UserModel user)
        {
            if (ModelState.IsValid)
            {
                var flag = UserService.Add(user);

                if (flag) return Request.CreateResponse(HttpStatusCode.OK, "Added");
                else return Request.CreateResponse(HttpStatusCode.OK, "Not Added");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [Route("api/User/list")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var list = UserService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        [Route("api/User/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var list = UserService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        [Route("api/User/Edit")]
        [HttpPost]
        public HttpResponseMessage Edit(UserModel user)
        {
            if (ModelState.IsValid)
            {
                var flag = UserService.Edit(user);
                if (flag) return Request.CreateResponse(HttpStatusCode.OK, "Edited");
                else return Request.CreateResponse(HttpStatusCode.OK, "Not Edited");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [Route("api/User/Delete/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var flag = UserService.Delete(id);
            if (flag) return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
            else return Request.CreateResponse(HttpStatusCode.OK, "Not Delete");
        }

    }
}
