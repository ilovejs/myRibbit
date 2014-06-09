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
    
        
        private ICollection<Message> _sentmessages;
        public virtual ICollection<Message> SentMessages
        {
            get { return _sentmessages ?? (_sentmessages = new Collection<Message>()); }  //if null
            set { _sentmessages = value; }
        }

        private ICollection<Message> _receivedmessages;
        public virtual ICollection<Message> ReceivedMessages
        {
            get { return _receivedmessages ?? (_receivedmessages = new Collection<Message>()); }  //if null
            set { _receivedmessages = value; }
        } 
    }
}