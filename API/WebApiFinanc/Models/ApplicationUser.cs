using Microsoft.AspNetCore.Identity;
using WebApiFinanc.Models.DTOs.Credito;

namespace WebApiFinanc.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
