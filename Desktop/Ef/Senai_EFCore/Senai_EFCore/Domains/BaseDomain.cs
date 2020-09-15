﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_EFCore.Domains
{
    public abstract class BaseDomain
    {
        [Key]
        public Guid Id { get; set; }

        public BaseDomain()
        {
            Id = Guid.NewGuid();
        }
    }
}
