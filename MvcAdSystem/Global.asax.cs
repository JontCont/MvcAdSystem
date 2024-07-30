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
            // ���o Forms Authentication �� Cookie
            HttpCookie authCookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                // �ѱK Cookie ��������
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                if (authTicket != null && !authTicket.Expired)
                {
                    // �q���Ҥ����o�Τᨤ���T
                    string[] roles = authTicket.UserData.Split(',');

                    // �إ� FormsIdentity �M GenericPrincipal
                    FormsIdentity id = new FormsIdentity(authTicket);
                    GenericPrincipal principal = new GenericPrincipal(id, roles);

                    // �]�w HttpContext �� User �ݩʬ��s�ت� GenericPrincipal
                    Context.User = principal;
                }
            }
        }
    }
}
