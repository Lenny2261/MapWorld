using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MapWorld.Models
{
    public class Stores
    {

        public Stores()
        {
            this.ApplicationUsers = new HashSet<ApplicationUser>();
        }

        public int Id { get; set; }
        public string Location { get; set; }
        public string StoreName { get; set; }
        public string PictureUrl { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }

    }
}