using System.Configuration;
using System.Threading.Tasks;
using System.Web.Cors;
using Microsoft.Owin.Cors;

namespace WebApi.Server.Hub.Cors
{
    public class CorsHelpers
    {
        public static CorsOptions CorsOptions()
        {
            var corsPolicy = new CorsPolicy
            {
                AllowAnyMethod = true,
                AllowAnyHeader = true,
            };

            // Try and load allowed origins from web.config
            // If none are specified we'll allow all origins

            var origins = ConfigurationManager.AppSettings["AllowedDomains"];

            if (origins != null)
            {
                foreach (var origin in origins.Split(','))
                {
                    corsPolicy.Origins.Add(origin);
                }
            }
            else
            {
                corsPolicy.AllowAnyOrigin = true;
            }

            var httpVerb = ConfigurationManager.AppSettings["AllowedVerbs"];
            if (httpVerb != null)
            {
                foreach (var origin in httpVerb.Split(','))
                {
                    corsPolicy.Methods.Add(origin);
                }
            }
            else
            {
                corsPolicy.AllowAnyMethod = true;
            }

            return new CorsOptions
            {
                PolicyProvider = new CorsPolicyProvider
                {
                    PolicyResolver = context => Task.FromResult(corsPolicy)
                }
            };
        }
    }
}