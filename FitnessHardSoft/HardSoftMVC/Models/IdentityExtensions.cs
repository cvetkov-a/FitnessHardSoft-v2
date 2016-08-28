using System.Security.Claims;
using System.Security.Principal;

namespace HardSoftMVC.Models.Extensions
{
    public static class IdentityExtensions
    {
        public static string getAvatar(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("Avatar");
            // Test for null to avoid issues during local testing
            return (claim.Value != null && claim != null) ? claim.Value : "noavatar.jpg";
        }
    }
}