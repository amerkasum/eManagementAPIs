﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities.Dtos
{
    public class UserBasicDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
    }
}
