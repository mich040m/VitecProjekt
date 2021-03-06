﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using VitecProjekt.Models;

namespace VitecProjekt.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the VitecUser class
    public class VitecUser : IdentityUser
    {
        //The Timestamp attribute specifies that this column will be included in the Where clause of Update and Delete commands sent to the database
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public bool IsFree { get; set; } = true;
        public int TryOutDaysLeft { get; set; } = 30;
        public int SubscriptionDaysLeft { get; set; }
        public Package Package { get; set; }
    }
}
