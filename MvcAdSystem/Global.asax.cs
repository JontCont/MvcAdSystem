using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace MvcAdSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            // 取得 Forms Authentication 的 Cookie
            HttpCookie authCookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                // 解密 Cookie 中的票證
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                if (authTicket != null && !authTicket.Expired)
                {
                    // 從票證中取得用戶角色資訊
                    string[] roles = authTicket.UserData.Split(',');

                    // 建立 FormsIdentity 和 GenericPrincipal
                    FormsIdentity id = new FormsIdentity(authTicket);
                    GenericPrincipal principal = new GenericPrincipal(id, roles);

                    // 設定 HttpContext 的 User 屬性為新建的 GenericPrincipal
                    Context.User = principal;
                }
            }
        }
    }
}
