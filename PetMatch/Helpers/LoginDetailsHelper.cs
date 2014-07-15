using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PetMatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PetMatch.Helpers
{
    public static class LoginDetailsHelper
    {
        public static IEnumerable<LoginDetailViewMode> Build()
        {
            return AsyncHelper.RunSync<IEnumerable<LoginDetailViewMode>>(() => LoginDetailsHelper.BuildAsync());
        }

        public static async Task<IEnumerable<LoginDetailViewMode>> BuildAsync()
        {
            if (HttpContext.Current == null)
                throw new InvalidOperationException("Invalid HttpContext");

            if (!HttpContext.Current.User.Identity.IsAuthenticated)
                return null;

            List<LoginDetailViewMode> result = new List<LoginDetailViewMode>();

            if (HttpContext.Current == null)
                throw new InvalidOperationException("Invalid HttpContext");

            if (!HttpContext.Current.User.Identity.IsAuthenticated)
                return null;

            var userId = HttpContext.Current.User.Identity.GetUserId();

            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            IList<UserLoginInfo> logins = null;

            // Creating our own ApplicationUserManager instance.
            // We shouldn't persisting changes back to the database and changes made in another
            // instance are not reflected here.
            using (var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext())))
            {
                logins = await userManager.GetLoginsAsync(userId);

                foreach (var loginInfo in logins)
                {
                    // Add helpers here
                    var item = FacebookHelper.GetLoginDetails(loginInfo.ProviderKey);

                    if (item != null && !result.Contains(item))
                        result.Add(item);
                }

                // Is a 
                if (result.Count == 0)
                {
                    var user = userManager.FindById(userId);

                    result.Add(new LoginDetailViewMode
                    {
                        FirstName = user.FirstName,
                        Name = HttpContext.Current.User.Identity.Name
                    });
                }
            }

            return result;
        }
    }
}