using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;

namespace ClaimsTest
{
  class Program
  {
    private static void Setup()
    {
      var claimCollection = new List<Claim>
      {
        new Claim(ClaimTypes.Name, "Gert-Jan"),
        new Claim(ClaimTypes.Country, "Netherlands"),
        new Claim(ClaimTypes.Gender, "M"),
        new Claim(ClaimTypes.Surname, "Jaarsma"),
        new Claim(ClaimTypes.Email, "gertjan@bencom.nl"),
        new Claim(ClaimTypes.Role, "IT")
      };

      var claimsIdentity = new ClaimsIdentity(claimCollection, "Bencom.nl Site");

      Console.WriteLine(claimsIdentity.IsAuthenticated);

      var principal = new ClaimsPrincipal(claimsIdentity);

      Thread.CurrentPrincipal = principal;
    }

    private static void CheckCompatibility()
    {
      var currentPrincipal = Thread.CurrentPrincipal;
      Console.WriteLine(currentPrincipal.Identity.Name);
      Console.WriteLine(currentPrincipal.IsInRole("IT"));
    }

    private static void CheckNewClaimsUsage()
    {
      var currentClaimsPrincipal = ClaimsPrincipal.Current;
      var nameClaim = currentClaimsPrincipal.FindFirst(ClaimTypes.Name);
      Console.WriteLine(nameClaim.Value);

      foreach (var claimsIdentity in currentClaimsPrincipal.Identities)
      {
        Console.WriteLine(claimsIdentity.Name);
      }
    }

    static void Main(string[] args)
    {
      Setup();
      CheckCompatibility();
      CheckNewClaimsUsage();

      Console.ReadKey();
    }
  }
}
