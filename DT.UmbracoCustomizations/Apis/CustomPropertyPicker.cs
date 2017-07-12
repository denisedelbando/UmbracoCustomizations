using DT.UmbracoCustomizations.DataRepository;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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