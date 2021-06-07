using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loot_Lo_Client.Helper
{
    public class CookieHelper
    {
        public static void SetCookie(string key, string value)
        {
            CookieOptions options = new CookieOptions();

            options.Expires = DateTime.Now.AddDays(1);

            //Response.Cookies.Append(key, value, options);
        }
    }
}
