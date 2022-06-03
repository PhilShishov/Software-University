﻿
namespace Git.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Repository
    {
        public Repository()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Commits = new HashSet<Commit>();
        }


        public string Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Name { get; set; }


        public DateTime CreatedOn { get; set; }

        [Required]
        public bool IsPublic { get; set; }


        public string OwnerId { get; set; }

        public virtual User Owner { get; set; }


        public virtual ICollection<Commit> Commits { get; set; }






    }
}
