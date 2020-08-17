using Academy.EntityFramework.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;

namespace Acedemy.API.Filters
{
    public class ValidationFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                ErrorModel errorModel = new ErrorModel();
                errorModel.StatusCode = 400;
                IEnumerable<ModelError> modelErrors = actionContext.ModelState.Values.SelectMany(v => v.Errors);
                modelErrors.ToList().ForEach(x =>
                {
                    errorModel.Errors.Add(x.ErrorMessage);
                });



                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest,errorModel);

            }
        }
    }
}