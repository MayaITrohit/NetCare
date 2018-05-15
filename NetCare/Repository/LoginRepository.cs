using NetCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetCare.Repository
{
    public static class LoginRepository
    {
        public static UserViewModel GetUserDetails(LoginViewModel obj)
        {
            using (JacEntities context = new JacEntities())
            {
                UserViewModel objUserView = new UserViewModel();
                var objUser = context.allusers.Where(u => u.username.ToLower() == obj.UserName.ToLower() && u.password == obj.Password).FirstOrDefault();

                if (objUser != null)
                {
                    objUserView.UserName = objUser.forenames;
                    objUserView.ID = objUser.ID;
                    objUserView.Roles = objUser.jobtitle;
                }
                else
                {
                    var objAdmin = context.superusers.Where(u => u.username.ToLower() == obj.UserName.ToLower() && u.password == obj.Password).FirstOrDefault();

                    if (objAdmin != null)
                    {
                        objUserView.UserName = objAdmin.forenames;
                        objUserView.ID = objAdmin.ID;                        
                        objUserView.Roles = "Admin";                 
                    }
                }
                return objUserView;
            }
        }
    }
}