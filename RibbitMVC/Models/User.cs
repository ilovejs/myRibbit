using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RibbitMVC.Models
{
    public class User
    {
        //GUID
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }
        //fk
        public int UserProfileId { get; set; }
        //lazy loaded Nav prop
        [ForeignKey("UserProfileId")]
        public virtual UserProfile Profile { get; set; }
    
        //api: user.Ribbits
        private ICollection<Ribbit> _ribbits; 
        public virtual ICollection<Ribbit> Ribbits { 
            get { return _ribbits ?? (_ribbits = new Collection<Ribbit>()); }  //if null
            set { _ribbits = value; }
        }
 
        //following
        private ICollection<User> _followings;
        public virtual ICollection<User> Followings
        {
            get { return _followings ?? ( _followings = new Collection<User>()); }  //if null
            set { _followings = value; }
        } 

        //followers
        private ICollection<User> _followers;
        public virtual ICollection<User> Followers
        {
            get { return _followers ?? (_followers = new Collection<User>()); }  //if null
            set { _followers = value; }
        } 
    }
}