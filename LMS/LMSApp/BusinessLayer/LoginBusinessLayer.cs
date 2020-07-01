using System.Collections.Generic;
using System.Linq;

using DataAccessLayer;
using BusinessEntities;

namespace BusinessLayer
{
    public class BusinessSettings
    {
        public static void SetBusiness()
        {
            DatabaseSettings.SetDatabase();
        }
    }

    public class LoginBusinessLayer
    {
        public List<User> GetUsers()
        {
            LMSAppDAL lmsDAL = new LMSAppDAL();
            return lmsDAL.Users.ToList();
        }

        public UserStatus GetUserValidity(User u)
        {
            List<User> UserList = GetUsers();
            string UserName = u.Name;
            User selectedUser = null;
            foreach (User uItem in UserList)
            {
                if (uItem.Name == UserName)
                {
                    selectedUser = uItem;
                    break;
                }
            }

            if (selectedUser != null)
            {
                if (selectedUser.IsAdmin == 1)
                    return UserStatus.AutheticatedAdmin;
                else if (selectedUser.IsLead == 1)
                    return UserStatus.AutheticatedLeader;
                else if (selectedUser.IsManager == 1)
                    return UserStatus.AutheticatedManger;
                else
                    return UserStatus.AutheticatedUser;
            }

            return UserStatus.NonAutheticatedUser;
        }
    }
}
