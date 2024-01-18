using System.Security.Claims;
using System.Text.Json;
using WineTourism.Application.Common;

namespace WineTourism.WebAPI.Middlewares
{
    public class UserDataAccessMiddleware : IMiddleware
    {
        private readonly IUser _userData;

        public UserDataAccessMiddleware(IUser userData)
        {
            _userData = userData;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var userIdClaim = context.User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim is null)
            {

                await context.Response.WriteAsync(
                    JsonSerializer.Serialize(
                        new
                        {
                            error = "Unauthorized access"
                        })
                    );
            }
            else
            {
                _userData.Id = userIdClaim.Value;
                await next.Invoke(context);
            }
        }
    }
}
