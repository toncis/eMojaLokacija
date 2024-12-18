using System.Security.Claims;

namespace eMojaLokacijaApi.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetUserId(this IEnumerable<Claim> claims)
        {
            var userIdClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            return userIdClaim != null ? int.Parse(userIdClaim.Value) : 0;
        }
    }
}
