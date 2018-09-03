using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChimesPortal.Models
{
    public class ContactPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
    }
}