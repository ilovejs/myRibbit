using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class Buyer
    {
        [Key]
        public int BuyerId;
        public string Name;
        public string Bio;
    }
}