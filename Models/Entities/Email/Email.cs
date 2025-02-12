using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities.Email
{
    public class Email
    {
        public string EmailTo { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
