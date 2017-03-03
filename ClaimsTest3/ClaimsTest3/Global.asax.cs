using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ClaimsTest3
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

    protected void Application_PostAuthenticateRequest()
    {
      var currentPrincipal = ClaimsPrincipal.Current;
      var customClaimsTransformer = new CustomClaimsTransformer();
      var transformedClaimsPrincipal = customClaimsTransformer.Authenticate(string.Empty, currentPrincipal);
      Thread.CurrentPrincipal = transformedClaimsPrincipal;
      HttpContext.Current.User = transformedClaimsPrincipal;
    }
  }
}
