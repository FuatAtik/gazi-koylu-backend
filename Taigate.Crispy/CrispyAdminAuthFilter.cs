﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Taigate.Crispy
{
    public class CrispyAdminAuthAttribute : TypeFilterAttribute
    {
        public CrispyAdminAuthAttribute() : base(typeof(CrispyAdminAuthFilter)) { }
    }

    public class  CrispyAdminAuthFilter : IAuthorizationFilter
    {
        private readonly IWebHostEnvironment environment;
        private readonly IList<CrispyAdminSecurityOptions> securityOptions;

        public CrispyAdminAuthFilter(IWebHostEnvironment environment, IEnumerable<CrispyAdminSecurityOptions> securityOptions)
        {
            this.environment = environment;
            this.securityOptions = securityOptions.ToList();
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            
            bool failedSecurityCheck = true;
            
            //
            // // in Development mode, allow bypassing security (shows a warning message)
            // if (environment.EnvironmentName == "Development" && !securityOptions.Any())
            // {
            //     failedSecurityCheck = false;
            // }
            // else
            // {
            //     
            // }
            foreach (var options in securityOptions)
            {
                if (options.RestrictToRoles != null && options.RestrictToRoles.Any())
                {
                    foreach (var role in options.RestrictToRoles)
                    {
                        if (context.HttpContext.User.IsInRole(role))
                        {
                            failedSecurityCheck = false;
                        }
                    }
                }
            }
            if (failedSecurityCheck) context.Result = new UnauthorizedResult();

        }
    }
}
