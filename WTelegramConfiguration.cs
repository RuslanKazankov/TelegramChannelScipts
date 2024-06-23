﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramChannelScipts
{
    public class WTelegramConfiguration
    {
        public string? ApiId { get; set; }
        public string? ApiHash { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Config(string what)
        {
            switch (what)
            {
                case "api_id": return ApiId;
                case "api_hash": return ApiHash;
                case "phone_number": Console.Write("Phone number: "); return Console.ReadLine();
                case "verification_code": Console.Write("Code: "); return Console.ReadLine();
                case "first_name": return FirstName;      // if sign-up is required
                case "last_name": return LastName;        // if sign-up is required
                case "password": Console.Write("Password: "); return Console.ReadLine();     // if user has enabled 2FA
                default: return null;                  // let WTelegramClient decide the default config
            }
        }
    }
}
