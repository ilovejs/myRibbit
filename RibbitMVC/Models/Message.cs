using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RibbitMVC.Models
{
    public class Message
    {
        public int Id;
        public int SenderId;
        public int ReceiverId;
        public DateTime SentDate;
        public bool IsRead;
        public string Body;


    }
}
