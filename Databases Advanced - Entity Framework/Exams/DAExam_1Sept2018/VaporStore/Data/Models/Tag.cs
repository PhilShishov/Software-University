﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaporStore.Data.Models
{
    public class Tag
    {
        public Tag()
        {
            this.GameTags = new HashSet<GameTag>();
        }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<GameTag> GameTags { get; set; }
    }
}
