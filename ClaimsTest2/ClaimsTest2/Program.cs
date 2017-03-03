using System;
using System.IdentityModel.Services;
using System.Security.Permissions;
using System.Security.Principal;
using System.Threading;

namespace ClaimsTest2
{
  class Program
  {
    [ClaimsPrincipalPermission(SecurityAction.Demand, Operation="Show", Resource="Code")]
    private static void ShowMeTheCode()
    {
      Console.WriteLine("Console.WriteLine");
    }

    private static void UseCurrentPrincipal()
    {
      ShowMeTheCode();
    }

    private static void SetCurrentPrincipal()
    {
      var incomingPrincipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());

      Thread.CurrentPrincipal =
        FederatedAuthentication.FederationConfiguration.IdentityConfiguration.ClaimsAuthenticationManager.Authenticate(
          "none", incomingPrincipal);
    }

    static void Main(string[] args)
    {
      SetCurrentPrincipal();
      UseCurrentPrincipal();
    }
  }
}
