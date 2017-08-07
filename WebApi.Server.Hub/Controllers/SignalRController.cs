using System.Web.Http;
using WebApi.Server.Hub.Hub;

namespace WebApi.Server.Hub.Controllers
{
    [RoutePrefix("SignalR")]
    public class SignalRController : ApiController
    {
        [HttpPost]
        public int Data([FromBody]CustomData customData)
        {

            var x = new ChatHub();
            x.CustomData(customData);
            return 1;
        }
    }
}