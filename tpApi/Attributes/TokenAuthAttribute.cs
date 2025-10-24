using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace tpApi.Attributes;

public class TokenAuthAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var apiToken = Environment.GetEnvironmentVariable("API_TOKEN");

        if (string.IsNullOrEmpty(apiToken))
        {
            context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            
            return;
        }

        var authHeader = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();

        if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
        {
            context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
            
            return;
        }

        var token = authHeader.Substring("Bearer ".Length).Trim();

        if (token != apiToken)
        {
            context.Result = new ObjectResult(new { error = "Invalid Token" })
            {
                StatusCode = StatusCodes.Status403Forbidden
            };
            
            return;
        }
    }
}