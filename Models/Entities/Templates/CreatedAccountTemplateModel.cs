using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities.Templates
{
    public class CreatedAccountTemplateModel
    {
        public string FullName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
