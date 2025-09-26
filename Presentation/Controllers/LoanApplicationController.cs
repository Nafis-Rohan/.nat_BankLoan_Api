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
    [RoutePrefix("api/loanApp")]
    public class LoanApplicationController : ApiController
    {
        [HttpGet]
        [Route("all")]

        public HttpResponseMessage Get()
        {
            try
            {
                var data = LoanApplicationService.Get();
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
        [Route("request")]
        public HttpResponseMessage Create(LoanApplicationDTO l)
        {
            try
            {
                var data = LoanApplicationService.Create(l);
                if (!data)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Customer could not be created");
                }
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet]
        [Route("all/{id}")]

        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = LoanApplicationService.Get(id);
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
        [Route("update")]
        public HttpResponseMessage Update(LoanApplicationDTO c)
        {
            try
            {
                var data = LoanApplicationService.Update(c);
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
                var data = LoanApplicationService.Delete(id);
                if (!data)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Customer not found");
                }
                return Request.CreateResponse(HttpStatusCode.OK, "Delete successful");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpGet]
        [Route("interest/{id}")]
        public HttpResponseMessage CalculateInterest(int id)
        {
            try
            {
                var interest = LoanApplicationService.CalculateInterest(id); 
                return Request.CreateResponse(HttpStatusCode.OK, interest);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        [HttpGet]
        [Route("Emi/{id}")]
        public HttpResponseMessage CalculateEmi(int id)
        {
            try
            {
                var emi = LoanApplicationService.EmiCal(id);
                return Request.CreateResponse(HttpStatusCode.OK, emi);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("Approve/{id}")]
        public HttpResponseMessage ApproveLoan(int id)
        {
            try
            {
                var a = LoanApplicationService.ApproveLoan(id);
                return Request.CreateResponse(HttpStatusCode.OK, a);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }






    }

}

