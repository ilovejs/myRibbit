using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RibbitMVC.ViewModel
{
    public class LoginSignupViewModel
    {
        public LoginViewModel Login { get; set; }
        public SignupViewModel Signup { get; set; }

//        public LoginSignupViewModel(LoginViewModel login = null, SignupViewModel signup = null)
//        {
//            login = login ?? new LoginViewModel();
//            signup = signup ?? new SignupViewModel();
//        }
    }
}