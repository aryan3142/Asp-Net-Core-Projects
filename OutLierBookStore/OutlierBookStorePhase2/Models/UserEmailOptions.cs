﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutlierBookStorePhase2.Models
{
    public class UserEmailOptions
    {
        public List<string> ToEmails { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

    }
}
