using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranchiseMenu.BLL.Contants
{
    public static class Messages
    {
        public static string success = "success";
        public static string unknownError = "unknown_err";
        #region Food
        public static string food_already_exists = "food_already_exists";
        public static string food_available_but_not_active = "food_available_but_not_active";
        public static string food_not_found = "food_not_found";
        public static string food_status_changed = "food_status_changed";
        public static string food_of_the_same_name_exists = "food_of_the_same_name_exists ";
        #endregion
        #region Category
        public static string category_already_exists = "category_already_exists";
        public static string category_available_but_not_active = "category_available_but_not_active";
        public static string category_not_found = "category_not_found ";
        public static string category_status_changed = "category_status_changed";
        public static string category_of_the_same_name_exists = "category_of_the_same_name_exists";
        #endregion
        #region Admin
        public static string admin_already_exists = "admin_already_exists";
        public static string admin_not_found = "admin_not_found";
        public static string phone_number_already_exists = "phone_number_already_exists";
        public static string email_already_exists = "email_already_exists";
        public static string admin_wrong_password = "admin_wrong_password";
        public static string admin_password_changed = "admin_password_changed";
        public static string new_password_cannot_the_same_old_password = "new_password_cannot_the_same_old_password";
        public static string passwords_not_match = "passwords_not_match";
        #endregion

        #region Token
        public static string token_not_found = "token_not_found";
        public static string token_expired = "token_expired";
        #endregion
    }
}
