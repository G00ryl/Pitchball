using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pitchball.Attributes
{
    public class CustomAuthorizeAttribute : ActionFilterAttribute, IAuthorizationFilter
    {
        public string Role { get; set; }

        public CustomAuthorizeAttribute(string role)
        {
            Role = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var role = context.HttpContext.Session.GetString("Role");

            if (!Role.ToLowerInvariant().Contains(role.ToLowerInvariant()))
                context.Result = new RedirectToActionResult("Index", "Home", null);
        }
    }
}
