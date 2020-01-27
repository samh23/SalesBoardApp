using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using SalesBoardApp.Areas.Identity.Data;
using SalesBoardApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesBoardApp.Authorization
{
    public class ProductAuthorizationHandler : AuthorizationHandler<UserAccessRequirement, Product>
    {
        UserManager<SalesBoardAppUser> _userManager;

        public ProductAuthorizationHandler(UserManager<SalesBoardAppUser> userManager)
        {
            _userManager = userManager;
        }

        //The HandleRequirementAsync method does the user access logic
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserAccessRequirement requirement, Product resource)
        {
            //if the product user id matches the current userid OR the current user is an administrator, then the requirement succeeds
            if ((resource.UserId == _userManager.GetUserId(context.User)) || context.User.IsInRole("Administrator"))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }

    //The requirement is an empty class because there are no additonal data parameters for the policy to use
    public class UserAccessRequirement : IAuthorizationRequirement { }
}
