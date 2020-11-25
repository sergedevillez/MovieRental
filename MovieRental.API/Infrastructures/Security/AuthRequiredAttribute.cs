using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using MovielRental.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieRental.DAL.Models;

namespace MovielRental.Infrastructures.Security
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthRequiredAttribute : TypeFilterAttribute
    {
        public AuthRequiredAttribute() : base(typeof(AuthRequiredFilter))
        {
        }

        private class AuthRequiredFilter : IAuthorizationFilter
        {
            public void OnAuthorization(AuthorizationFilterContext context)
            {
                ITokenService tokenService = (ITokenService)context.HttpContext.RequestServices.GetService(typeof(ITokenService));
                IAuthService authService = (IAuthService)context.HttpContext.RequestServices.GetService(typeof(IAuthService));

                context.HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues authorizations);
                string token = authorizations.SingleOrDefault(authorization => authorization.StartsWith("Bearer "));

                if (token is null)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }

                Customer customer = tokenService.ValidateToken(token);

                if (customer is null)
                {
                    context.Result = new UnauthorizedResult();
                }
            }
        }
    }
}
