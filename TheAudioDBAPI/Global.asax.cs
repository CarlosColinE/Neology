using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace TheAudioDBAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Session_Start(object sender, EventArgs e)
        {
            Session.Timeout = 120;
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                if (authTicket != null && !authTicket.Expired)
                {
                    var roles = authTicket.UserData.Split(',');
                    HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(new FormsIdentity(authTicket), roles);
                    FormsAuthenticationTicket authTicket2 = new FormsAuthenticationTicket(
                                                                            1,                                      //version
                                                                            authTicket.Name,                         //username
                                                                            DateTime.Now,                           //created
                                                                            DateTime.Now.AddMinutes(Convert.ToDouble(ConfigurationManager.AppSettings["TiempoSesion"])),            //expires
                                                                            true,                                   //persistent?
                                                                            authTicket.UserData                         //rol
                                                                            );
                    authCookie.Value = FormsAuthentication.Encrypt(authTicket2);
                    Response.Cookies.Add(authCookie);
                }
            }
        }
    }
}



