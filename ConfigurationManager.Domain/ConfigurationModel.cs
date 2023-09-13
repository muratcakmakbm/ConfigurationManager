﻿using System;

namespace ConfigurationManager.Domain
{
    public class ConfigurationModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public bool IsActive { get; set; } = true;
        public string ApplicationName { get; set; }
    }
}
