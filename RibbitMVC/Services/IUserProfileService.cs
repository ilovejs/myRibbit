using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RibbitMVC.Models;
using RibbitMVC.ViewModel;

namespace RibbitMVC.Services
{
    public interface IUserProfileService
    {
        UserProfile GetBy(int id);
        void Update(EditProfileViewModel model);
    }
}