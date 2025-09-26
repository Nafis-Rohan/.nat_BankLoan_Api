using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Presentation.Controllers
{
    [RoutePrefix("api/bankacc")]
    public class BankAccountController : ApiController
    {
        [HttpGet]
        [Route("all")]

        public HttpResponseMessage Get()
        {
            try
            {
                var data = BankAccountService.Get();
                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No data found");
                }
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("all/{id}")]

        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = BankAccountService.Get(id);
                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No data found");
                }
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("open")]
        public HttpResponseMessage Create(BankAccountDTO b)
        {
            try
            {
                var data = BankAccountService.Create(b);
                if (!data)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Bank Account could not be created");
                }
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(BankAccountDTO b)
        {
            try
            {
                var data = BankAccountService.Update(b);
                if (!data)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "update failed");
                }
                return Request.CreateResponse(HttpStatusCode.OK, "Update successful");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = BankAccountService.Delete(id);
                if (!data)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Bank Account not found");
                }
                return Request.CreateResponse(HttpStatusCode.OK, "Delete successful");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
