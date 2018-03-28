using SignalR.Hub;
using System.Web.Http;


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