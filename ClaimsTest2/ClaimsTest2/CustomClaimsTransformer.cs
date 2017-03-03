using System;
using System.Collections.Generic;
using System.Security;
using System.Security.Claims;

namespace ClaimsTest2
{
  public class CustomClaimsTransformer : ClaimsAuthenticationManager
  {
    private ClaimsPrincipal CreatePrincipal(string userName)
    {
      var likesJavaToo = userName.IndexOf("gertj", StringComparison.InvariantCultureIgnoreCase) > -1;

      var claimsCollection = new List<Claim>()
      {
        new Claim(ClaimTypes.Name, userName),
        new Claim("http://www.mysite.com/likesjavatoo", likesJavaToo.ToString())
      };

      return new ClaimsPrincipal(new ClaimsIdentity(claimsCollection, "Custom"));
    }

    public override ClaimsPrincipal Authenticate(string resourceName, ClaimsPrincipal incomingPrincipal)
    {
      var nameClaimValue = incomingPrincipal.Identity.Name;

      if (string.IsNullOrEmpty(nameClaimValue))
      {
        throw new SecurityException("A user with no name???");
      }

      return CreatePrincipal(nameClaimValue);
    }
  }
}
