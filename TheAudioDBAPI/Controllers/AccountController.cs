using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TheAudioDBAPI.Models;

namespace TheAudioDBAPI.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            var model = new UserLoginModel();
            if (string.IsNullOrEmpty(returnUrl))
            {
                //var RaizWeb = ConfigurationManager.AppSettings["Dominio"];
                //returnUrl = RaizWeb + "/Market/Mp/xxx"; // asi es como quedaria para mi local
            }
            model.ReturnUrl = returnUrl;
            return View(model);
        }

        //JAJG 15/10/2019 Se agrega código para reiniciar el tiempo de sesión en la cookie
        [HttpPost]
        [AllowAnonymous]
        public JsonResult Login(UserLoginModel model)
        {
            try
            {                

                if (!string.IsNullOrEmpty(model.Username) && !string.IsNullOrEmpty(model.Password))
                {                                                                                                                                   
                            Session["UserLoged"] = model;

                            model.RolUser = "ADMIN_YaVasLedger";
                            
                            switch (model.RolUser)
                            {
                                case "ADMIN_YaVasLedger":
                                    return Json(new { Error = false, Mensaje = "ok", Url = ConfigurationManager.AppSettings["Server"].ToString() + ConfigurationManager.AppSettings["UrlStartTI"].ToString() }, JsonRequestBehavior.AllowGet);

                                case "Manager1":
                                    return Json(new { Error = false, Mensaje = "ok", Url = ConfigurationManager.AppSettings["Server"].ToString() + ConfigurationManager.AppSettings["UrlStart"].ToString() }, JsonRequestBehavior.AllowGet);

                                case "FinalUser":
                                    return Json(new { Error = false, Mensaje = "ok", Url = ConfigurationManager.AppSettings["Server"].ToString() + ConfigurationManager.AppSettings["UrlStart"].ToString() }, JsonRequestBehavior.AllowGet);

                                default:
                                    return Json(new { Error = false, Mensaje = "ok", Url = "" }, JsonRequestBehavior.AllowGet);
                            }                                                                                        
                }
                else
                {
                    return Json(new { Error = true, Mensaje = "Usuario null || password null", Url = "" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception er)
            {
                return Json(new
                {
                    Error = true,
                    Mensaje = er.Message,
                    StackTrac = er.StackTrace,
                    Url = ""
                }, JsonRequestBehavior.AllowGet);
            }
        }

                              

        [HttpGet]
        public ActionResult Logout()
        {
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Session.Remove("UserLoged");
            Session.Remove("ASP.NET_SessionId");
            HttpContext.Request.Cookies.Remove("ASP.NET_SessionId");
            HttpContext.Response.Cookies.Remove(".ASPXAUTH");
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");

        }
    }
}