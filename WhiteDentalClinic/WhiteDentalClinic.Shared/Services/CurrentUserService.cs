using Microsoft.AspNetCore.Http;

namespace WhiteDentalClinic.Shared.Services
{
    public class CurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string UserId => _httpContextAccessor.HttpContext?.User?.FindFirst("id")?.Value;

        public string Role => _httpContextAccessor.HttpContext?.User?.FindFirst("Role")?.Value;
    }
}