using System;
using Microsoft.AspNetCore.Identity;
using Taigate.Core.Attributes;
using Taigate.Data.Data.Entities.Base;

namespace Taigate.Data.Data.Entities
{
    [MenuSite("Admin")]
    [MenuTitle("Sistem")]
    [MenuItemTitle("User")]
    public class User : IdentityUser
    {
        public string SystemName { get; set; }   
        public string Guid { get; set; }   
    }
}