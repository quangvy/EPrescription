using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Data.Helper
{
    class Security
    {
        /// <summary>
        /// Determines if the user is an admin user from Tips point of viww 
        /// </summary>
        /// <returns></returns>
        public static bool IsAdminUser()
        {
            
            return HttpContext.Current.User.IsInRole("Administrators");
        }

        /// <summary>
        /// Determines if the user is an account user (or higher) from the application point of viww.
        /// </summary>
        /// <returns></returns>

        public static bool IsInRole(string role)
        {
            return HttpContext.Current.User.IsInRole(role);
        }

        public static string CurrentLoggedInUserName => System.Web.HttpContext.Current.User.Identity.Name;
    }
}
