using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace FileUploadServiceAPI_Demo.Controllers
{
    public class ValuesController : ApiController
    {

        public HttpResponseMessage Post()
        {
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count < 1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            foreach (string file in httpRequest.Files)
            {
                var postedFile = httpRequest.Files[file];
                var filePath = HttpContext.Current.Server.MapPath("~/Uploads/" + postedFile.FileName);
                postedFile.SaveAs(filePath);
            }
            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}
