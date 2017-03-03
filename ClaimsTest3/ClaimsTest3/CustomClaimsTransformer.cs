using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace ClaimsTest3
{
  public class CustomClaimsTransformer : ClaimsAuthenticationManager
  {
    private ClaimsPrincipal DressUpPrincipal(string userName)
    {
      var claims = new List<Claim>();

      if (userName.IndexOf("gertj", StringComparison.InvariantCultureIgnoreCase) > -1)
      {
        claims.Add(new Claim(ClaimTypes.Country, "Netherlands"));
        claims.Add(new Claim(ClaimTypes.GivenName, "Gert-Jan"));
        claims.Add(new Claim(ClaimTypes.Name, "Gert-Jan"));
        claims.Add(new Claim(ClaimTypes.Role, "IT"));
      }
      else
      {
        claims.Add(new Claim(ClaimTypes.GivenName, userName));
        claims.Add(new Claim(ClaimTypes.Name, userName));
      }

      return new ClaimsPrincipal(new ClaimsIdentity(claims, "Custom"));
    }

    public override ClaimsPrincipal Authenticate(string resourceName, ClaimsPrincipal incomingPrincipal)
    {
      if (!incomingPrincipal.Identity.IsAuthenticated)
      {
        return base.Authenticate(resourceName, incomingPrincipal);
      }

      return DressUpPrincipal(incomingPrincipal.Identity.Name);
    }
  }
}