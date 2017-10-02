using FluentNHibernate.Mapping;
using MenuControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MenuControl.Mapping
{
    public class MenuItemMapping:ClassMap<MenuItem>
    {
        public MenuItemMapping()
        {
            Id(m => m.Id).GeneratedBy.Identity();
            Map(m => m.Code);
            Map(m => m.Action);
            Map(m => m.Controller);
            Map(m => m.Description);
            Map(m => m.UserRole);
        }
    }
}