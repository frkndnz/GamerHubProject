﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.CommentDTOs
{
    public class CommentDTO
    {
        public DateTime CreatedAt { get; set; }
        public string? Content { get; set; }
        public string? UserName { get; set; }
    }
}
