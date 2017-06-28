using DT.UmbracoCustomizations.DataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Umbraco.Core.Models;
using Umbraco.Web.WebApi;

namespace DT.UmbracoCustomizations.Apis
{
    public class CustomPropertyPickerController : UmbracoApiController
    {
        [HttpGet]
        [Route("GetProperties")]
        public HttpResponseMessage GetProperties()
        {
            var repo = new UmbracoRepositories();
            var lst = repo.GetContentProperties();

            return Request.CreateResponse(HttpStatusCode.OK, lst);
        }
    }
}