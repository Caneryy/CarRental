﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRental.WebUi.Models.Json
{
    public class LoginResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string userName { get; set; }
    }
}