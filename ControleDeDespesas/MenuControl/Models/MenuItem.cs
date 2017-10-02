using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MenuControl.Models
{
    public class MenuItem
    {
        public virtual int Id { get; set; }
        public virtual string Code { get; set; }
        public virtual string Action { get; set; }
        public virtual string Controller { get; set; }
        public virtual string Description { get; set; }
        public virtual string UserRole { get; set; }

    }
}