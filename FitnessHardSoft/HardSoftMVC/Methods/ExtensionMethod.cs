using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using HardSoftMVC.Models;

namespace HardSoftMVC.Methods
{
    public static class IdentityExtensions
    {
        public static string GetAvatar(this System.Security.Principal.IIdentity user)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var avatar = db.Users.Include(u => u.Avatar).ToString();

            return avatar;
        }
    }
}